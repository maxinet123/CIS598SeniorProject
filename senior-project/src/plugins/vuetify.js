import Vue from "vue";
import Vuetify from "vuetify/lib/framework";
// import colors from "vuetify/lib/util/colors";
//import Vuelidate from 'vuelidate';
Vue.use(Vuetify);
//Vue.use(Vuelidate);

export default new Vuetify({
  options: {
    customerProperties: true,
  },
  theme: {
    dark: true,
    themes: {
      light: {
        primary: "#5f6aa0",
        secondary: "#A05F6A",
        grey: "#FFFFFF",
      },
      dark: {
        primary: "#a2b5d2",
        secondary: "#D2A2B5",
        grey: "#272727",
      },
    },
  },
});
