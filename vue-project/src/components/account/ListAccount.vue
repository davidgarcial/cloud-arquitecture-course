<template>
  <div class="item__credit">
    <div class="credit__title">
      <h3>Cuentas</h3>
      <span>Listado de cuentas</span>
    </div>
    <div class="credit__table">
      <table>
        <tr>
          <th>ID Credito</th>
          <th>Total</th>
          <th>Saldo</th>
          <th>Estado</th>
          <th>Descripcion</th>
          <th>Cliente</th>
          <th></th>
          <th></th>
          <th></th>
        </tr>
        <tr v-for="(item, index) in listAccount" :key="index">
          <td>{{ item.idAccount }}</td>
          <td>{{ item.totalAmount }}</td>
          <td>-</td>
          <td>-</td>
          <td>-</td>
          <td>{{ item.fullName }}</td>
          <td>
            <router-link
              class="ligth"
              :to="`/account/transaction/deposit/${item.idAccount}`"
              >Deposito</router-link
            >
          </td>
          <td>
            <router-link
              class="ligth"
              :to="`/account/transaction/withdrawal/${item.idAccount}`"
              >Retiro</router-link
            >
          </td>
          <td>
            <router-link
              class="full"
              :to="`/account/listhistory/${item.idAccount}`"
              >Ver Movimientos</router-link
            >
          </td>
        </tr>
      </table>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      listAccount: null,
    };
  },
  created() {
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
        .get(`account/account`, { headers: headers })
        .then((response) => {
          this.listAccount = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
    },
  },
};
</script>

<style></style>
