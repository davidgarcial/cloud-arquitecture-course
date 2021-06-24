<template>
  <div class="page1__header">
    <section class="section1">
      <div class="section1__align">
        <div class="section1__main">
          <div class="item__list">
            <div class="item"><a href="index.html"><img src="@/assets/images/logo.svg"></a></div>
            <div class="item">
              <h2>Usuario</h2><span id="logout">US</span>
              <div class="item__close" id="out" @click="logout"><a>Cerrar sesión</a></div>
            </div>
          </div>
        </div>
      </div>
    </section>
    <section class="section2" id="bg"></section>
  </div>
</template>

<script>
export default {
  methods: {
    logout() {
      this.$emit('logout')
    }
  }
}
</script>

<style>

</style>