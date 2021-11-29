<template>
  <v-app>
    <load-overlay v-show="loading || $auth.isLoading"/>
    <app-bar />
    <nav-drawer />
    <v-main class="page">
      <router-view />
    </v-main>
  </v-app>
</template>

<script>
import { mapActions } from "vuex";
import LoadOverlay from "./components/LoadOverlay.vue";
import NavDrawer from "./components/NavDrawer.vue";
import AppBar from "./components/AppBar.vue";
      // <v-icon>mdi-filter-outline</v-icon>

export default {
  name: "App",
  components: {
    LoadOverlay,
    AppBar,
    NavDrawer,
  },
  data: (vm) => ({
    initialDark: vm.$vuetify ? vm.$vuetify.theme.dark : false,
    loading: true,
  }),
  mounted() {
    setTimeout(() => {
      this.fetchInternships()
      .then(() => {
        this.fetchCompanies();
        this.fetchDisciplines();
        this.fetchLocations();
        this.fetchRatings();
        this.fetchMajors();
      })
      .finally(() => {
        this.loading = false;
      });
    }, 5000);
  },
  methods: {
    ...mapActions(["fetchInternships", "fetchMajors", "fetchCompanies", "fetchDisciplines", 
      "fetchLocations", "fetchRatings"]),
    logout() {
      this.$auth.logout();
      this.$router.push({ path: "/" }).catch(() => {});
    },
  },
  created() {
    window.addEventListener("beforeunload", this.logout);
  },
};
</script>

<style lang="scss" scoped>
.page {
  margin: 25px 150px;
  @media all and (max-width: 960px) {
    margin: 35px 10px 35px 68px;
  }
}
</style>
