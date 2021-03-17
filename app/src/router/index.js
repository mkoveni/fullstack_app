import Vue from 'vue'
import VueRouter from 'vue-router'
import Categories from '../views/Categories.vue'
import Discover from '../views/Discover.vue'
import People from '../views/People.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Categories',
    component: Categories
  },

  {
    path: '/search',
    name: 'Discover',
    component: Discover
  },

  {
    path: '/people',
    name: 'People',
    component: People
  },
]

const router = new VueRouter({
  mode: 'history',
  routes
})

export default router
