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
        primary: "#FFFFFF",
        secondary: "#FFFFFF",
        grey: colors.grey,
        loadingText: colors.black,
      },
      dark: {
        primary: "#FFFFFF",
        secondary: "#FFFFFF",
        grey: "#272727",
        loadingText: colors.white,
      },
    },
  },
});
