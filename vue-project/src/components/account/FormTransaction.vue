<template>
  <div class="item__products">
    <div class="products__title">
      <h3>Creditos</h3>
      <span>Registro creditos</span>
    </div>
    <div class="products__form">
      <form v-on:submit.prevent="sendData">
        <div>
          <label>Tipo</label>
          <input type="text" v-model="action" disabled/>
        </div>
        <div>
          <label>Monto</label>
          <input type="number" v-model.number.trim="sendAccount.Amount"/>
        </div>
        <div>
          <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod</p>
        </div>
        <div>
          <button :disabled="!disabledBtn()">Realizar</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      action: null,
      sendAccount: {
        AccountId: null,
        Amount: null,
      },
    };
  },
  created() {
    this.action = this.$route.params.action;
    this.sendAccount.AccountId = Number(this.$route.params.id)
  },
  methods: {
    sendData() {
      this.$http
        .post(`/transaction/${this.action}`, this.sendAccount)
        .then((response) => {
          console.log(response)
          this.$router.push('/account/listaccount')
        })
        .catch((e) => {
          console.log(e);
        });
    },
    disabledBtn() {
      return this.sendAccount.Amount != null && this.sendAccount.Amount != ''
    }
  }
};
</script>

<style>
</style>