import Vue from "vue";
import App from "./App.vue";
import axios from "axios";
import VueAxios from "vue-axios";
import router from "./router";
import store from "./store";
import vuetify from "./plugins/vuetify";
import { VueMaskDirective } from 'v-mask';
//import GoogleAuth from 'vue-google-authenticator'

Vue.directive('mask', VueMaskDirective)
Vue.use(VueAxios, axios);
Vue.config.productionTip = false;

//Vue.use(GoogleAuth, { client_id: 'xxxxxxxxxx-xxxxxxxxxxxxxxxxxxxxxxxxxx.apps.googleusercontent.com' })
//Vue.googleAuth().load()

new Vue({
  router,
  store,
  vuetify,
  render: (h) => h(App),
}).$mount("#app");
