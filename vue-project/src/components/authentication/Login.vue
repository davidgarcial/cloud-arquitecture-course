<template>
  <div class="page loader">
    <div class="page1__login">
      <section class="section1">
        <div class="section1__align">
          <div class="section1__header">
            <div class="item__list">
              <div class="item">
                <div class="item__image">
                  <img src="@/assets/images/logohome.svg" />
                </div>
                <form v-on:submit.prevent="sendData">
                  <div>
                    <label>Nombre</label>
                    <input type="text" v-model.trim="user.Email" />
                  </div>
                  <div>
                    <label>Contraseña</label>
                    <input type="password" v-model.trim="user.Password" />
                  </div>
                  <div>
                    <button :disabled="validDisabled()">Acceder</button>
                  </div>
                </form>
              </div>
            </div>
          </div>
        </div>
      </section>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      user: {
        Email: "icuadros@aforo255.com",
        Password: "Aforo255#",
      },
    };
  },
  methods: {
    sendData() {
      const headers = {
        headers: {
          "content-type": "application/json",
          "Ocp-Apim-Subscription-Key": this.$global.key,
        },
      };

      this.$http
        .post("security/auth", this.user, headers)
        .then((response) => {
          localStorage.setItem("user", JSON.stringify(response.data));
          localStorage.setItem("token", response.data.token);
          this.$emit("login");
        })
        .catch((e) => {
          console.log(e);
        });
    },
    validDisabled() {
      return !(this.user.Email && this.user.Password);
    },
  },
};
</script>

<style></style>
