import Vue from "vue";
import Vuetify from "vuetify/lib/framework";
import colors from "vuetify/lib/util/colors";
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
        primary: "#000000",
        secondary: colors.blue,
        grey: "#FFFFFF",
        purple: "#5f6aa0",
      },
      dark: {
        primary: "#FFFFFF",
        secondary: "#FFFFFF",
        grey: "#272727",
        purple: "#a2b5d2",
      },
    },
  },
});
