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
    setTimeout(() => {
      this.fetchInternships();
    }, 5000);
  },
  methods: {
    ...mapActions(["fetchInternships"]),
    logout() {
      this.$auth.logout();
      this.$router.push({ path: "/" }).catch(() => {});
    }
  },
  created() {
    window.addEventListener('beforeunload', this.logout)
  },
};
</script>

<style lang="scss" scoped>
.page {
  margin: 25px 150px;
  @media all and (max-width: 960px) {
    margin: 10px;
  }
}
</style>
