<template>
  <div class="section1__header">
    <div class="item__list">
      <div class="item">
        <ul>
          <li>
            <router-link to="/">Home</router-link>
          </li>
          <li>
            <a id="supplier">Proveedores</a>
            <ul>
              <li>
                <a href="#">Listado</a>
              </li>
              <li>
                <a href="#">Registro</a>
              </li>
            </ul>
          </li>
          <li>
            <a id="account">Cuentas</a>
            <ul>
              <li>
                <router-link to="/account/listaccount">Listado</router-link>
              </li>
            </ul>
          </li>
          <li>
            <a href="#">Clientes</a>
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>

<script>
export default {}
</script>

<style>
</style>