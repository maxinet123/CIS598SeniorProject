<template>
  <v-app>
    <app-bar />
    <v-main class="page">
      <router-view />
    </v-main>
  </v-app>
</template>

<script>
import { mapActions } from "vuex";

import AppBar from "./components/AppBar.vue";
export default {
  name: "App",
  components: {
    AppBar,
  },
  data: (vm) => ({
    initialDark: vm.$vuetify ? vm.$vuetify.theme.dark : false,
  }),
  mounted() {
    //this.fetchInternships();
  },
  methods: {
    ...mapActions(["fetchInternships"]),
  },
};
</script>

<style lang="scss" scoped>
.page {
  margin: 25px 150px;
}
// :root {
//   --background-color-primary: #ebebeb;
//   --background-color-secondary: #fafafa;
//   --accent-color: #cacaca;
//   --text-primary-color: #222;
//   --element-size: 4rem;
// }
// :root.dark-theme {
//   --background-color-primary: #1e1e1e;
//   --background-color-secondary: #2d2d30;
//   --accent-color: #3f3f3f;
//   --text-primary-color: #ddd;
// }
</style>
