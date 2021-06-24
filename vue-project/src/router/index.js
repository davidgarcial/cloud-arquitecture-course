import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: () => import('@/components/home')
  },
  {
    path: '/account/listaccount',
    name: 'ListAccount',
    component: () => import('@/components/account/ListAccount')
  },
  {
    path: '/account/listhistory/:id',
    name: 'ListHistory',
    component: () => import('@/components/account/ListHistory')
  },
  {
    path: '/account/transaction/:action/:id',
    name: 'FormTransaction',
    component: () => import('@/components/account/FormTransaction')
  },
  {
    path: '',
    redirect: '/',
  },
  {
    path: '*',
    redirect: '/',
  },
  {
    path: '**',
    redirect: '/',
  }
  // {
  //   path: '/about',
  //   name: 'About',
  //   // route level code-splitting
  //   // this generates a separate chunk (about.[hash].js) for this route
  //   // which is lazy-loaded when the route is visited.
  //   component: () => import('../views/About.vue')
  // }
]

const router = new VueRouter({
  linkActiveClass: 'is-active',
  mode: 'hash',
  base: process.env.BASE_URL,
  routes
})

export default router
