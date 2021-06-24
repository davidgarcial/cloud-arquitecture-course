<template>
  <div class="page loader">
    <div v-if="auth">
      <app-header @logout='logout'/>
      <div class="page1__main">
        <section class="section1">
          <div class="section1__align">
            <app-nav />
            <div class="section1__main">
              <div class="item__list">
                <router-view />
              </div>
            </div>
          </div>
        </section>
      </div>
      <app-footer v-if="auth" />
    </div>
    <login v-else @login='login'></login>
  </div>
</template>

<script>
import * as main from "@/assets/js/main.js"
import AppHeader from "@/components/layout/AppHeader"
import AppFooter from "@/components/layout/AppFooter"
import AppNav from "@/components/layout/AppNav"
import Login from "@/components/authentication/Login"
export default {
  components: {
    AppHeader,
    AppNav,
    Login,
    AppFooter,
  },
  data() {
    return {
      auth: null
    }
  },
  created() {
    this.login()
  },
  methods: {
    login() {
      if (localStorage.getItem('user')) {
        this.$http.defaults.headers.common['Authorization'] = 'Bearer ' + JSON.parse(localStorage.getItem('user')).token
        this.auth = true
      }
    },
    logout() {
      this.auth = false
      localStorage.clear()
      delete this.$http.defaults.headers.common['Authorization']
      console.log(this.$route)
      this.$route.path != '/' ? this.$router.push('/') : ''
    }
  },
  watch: {
    'auth': function() {
      this.$nextTick(()=>{
        main.jsanima()
      })
    }
  }
};
</script>
<style>
</style>