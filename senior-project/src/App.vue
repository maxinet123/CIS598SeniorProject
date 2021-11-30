<template>
  <v-app>
    <load-overlay v-show="loading || $auth.isLoading"/>
    <v-overlay :opacity=".75" v-show="showFilters" >
      <filters @filter="closeFilters"/>
    </v-overlay>
    <app-bar />
    <nav-drawer />
    <v-main class="page">
      <router-view />
      <v-btn v-show="$route.name === 'Explore' && getInternships.length > 0" color="purple"
        absolute bottom right fab @click="showFilters = true">
        <v-icon>mdi-filter-outline</v-icon>
      </v-btn>
    </v-main>
  </v-app>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
import LoadOverlay from "./components/LoadOverlay.vue";
import NavDrawer from "./components/NavDrawer.vue";
import AppBar from "./components/AppBar.vue";
import Filters from "./components/Filters.vue";

export default {
  name: "App",
  data: (vm) => ({
    initialDark: vm.$vuetify ? vm.$vuetify.theme.dark : false,
    loading: true,
    showFilters: false
  }),
  components: {
    LoadOverlay,
    AppBar,
    NavDrawer,
    Filters
  },
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
  computed: {
    ...mapGetters(['getInternships'])
  },
  methods: {
    ...mapActions(["fetchInternships", "fetchMajors", "fetchCompanies", "fetchDisciplines", 
      "fetchLocations", "fetchRatings"]),
    logout() {
      this.$auth.logout();
      this.$router.push({ path: "/" }).catch(() => {});
    },
    closeFilters(val) {
      this.showFilters = false
      console.log(val)
    }
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
