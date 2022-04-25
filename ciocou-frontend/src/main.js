import Vue from 'vue';
import App from './App.vue';
import VueRouter from 'vue-router';

import endpoints from './endpoints.json';
import TeProvocLaCiocc from './components/TeProvocLaCiocc.vue';
import Cioccneste from './components/Cioccneste.vue';
import vuetify from './plugins/vuetify'

Vue.config.productionTip = false;
Vue.use(VueRouter);
window.endpoints = endpoints;

const routes = [
  { path: '/', component: TeProvocLaCiocc },
  { path: '/home', component: TeProvocLaCiocc },
  { path: '/te-provoc-la-ciocc', component: TeProvocLaCiocc },
  { path: '/cioccneste', component: Cioccneste },
];
const router = new VueRouter({
  routes: routes,
  mode: 'history'
});

new Vue({
  router,

  components: {
    App
  },

  vuetify,
  render: h => h(App)
}).$mount('#app');
