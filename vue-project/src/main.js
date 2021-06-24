import Vue from 'vue'
import App from './App.vue'
import router from './router'
import axios from 'axios'
Vue.prototype.$http = axios
axios.defaults.baseURL = 'http://microservicesnetazurebase.azurewebsites.net/api'
require('@/assets/css/common.css')
Vue.config.productionTip = false
new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
