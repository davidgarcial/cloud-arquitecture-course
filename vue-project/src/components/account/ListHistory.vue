<template>
  <div class="item__credit">
    <div class="credit__title">
      <h3>Movimientos</h3>
      <span>Listado de movimientos</span>
    </div>
    <div class="credit__table">
      <table>
        <tr>
          <th>ID Credito</th>
          <th>Total</th>
          <th>Tipo</th>
          <th>Fecha</th>
          <th>Cuenta</th>
        </tr>
        <tr v-for="(item, index) in listHistory" :key="index">
          <td>{{ item.idTransaction }}</td>
          <td>{{ item.amount }}</td>
          <td>{{ item.type }}</td>
          <td>{{ item.creationDate }}</td>
          <td>{{ item.accountId }}</td>
        </tr>
      </table>

      <!-- {{listHistory | Json}} -->
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      id: null,
      listHistory: null,
    };
  },
  created() {
    this.id = this.$route.params.id;
    this.getList();
  },
  methods: {
    getList() {
      const headers = {
        "content-type": "application/json",
        "Ocp-Apim-Subscription-Key": this.$global.key,
        Authorization: `Bearer ${localStorage.getItem("token")}`,
      };

      this.$http
        .get(`report/GetById/${this.id}`, { headers: headers })
        .then((response) => {
          this.listHistory = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
    },
  },
};
</script>

<style></style>
