<template>
  <v-app>
    <app-bar />
    <nav-drawer />
    <v-main class="page">
      <router-view />
    </v-main>
  </v-app>
</template>

<script>
import { mapActions } from "vuex";
import NavDrawer from "./components/NavDrawer.vue";
import AppBar from "./components/AppBar.vue";

export default {
  name: "App",
  components: {
    AppBar,
    NavDrawer
  },
  data: (vm) => ({
    initialDark: vm.$vuetify ? vm.$vuetify.theme.dark : false,
  }),
  mounted() {
    setTimeout(() => {
      this.fetchInternships();
      this.fetchMajors();
    }, 5000);
  },
  methods: {
    ...mapActions(["fetchInternships", "fetchMajors"]),
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
