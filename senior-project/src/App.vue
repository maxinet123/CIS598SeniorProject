<template>
  <v-app class="inspire">
    <load-overlay v-show="loading || $auth.isLoading" />
    <v-overlay :opacity="0.75" v-show="showFilters">
      <filters @close="close" @hasFilters="setHasFilters" />
    </v-overlay>
    <app-bar />
    <v-main class="page">
      <router-view />
    </v-main>
    <div>
      <v-tooltip left>
        <template v-slot:activator="{ on, attrs }">
          <v-btn
            v-bind="attrs"
            v-on="on"
            v-show="
              $route.name === 'Explore' &&
              getInternships.length > 0 &&
              hasFilters
            "
            color="primary"
            absolute
            class="clear-btn"
            fab
            @click="clearFilters"
          >
            <v-icon>mdi-close</v-icon>
          </v-btn>
        </template>
        <span>Clear Filters</span>
      </v-tooltip>
      <v-tooltip left>
        <template v-slot:activator="{ on, attrs }">
          <v-btn
            v-bind="attrs"
            v-on="on"
            v-show="$route.name === 'Explore' && getInternships.length > 0"
            color="primary"
            absolute
            class="filter-btn"
            fab
            @click="showFilters = true"
          >
            <v-icon>mdi-filter-outline</v-icon>
          </v-btn>
        </template>
        <span>Filter Options</span>
      </v-tooltip>
    </div>
  </v-app>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
import LoadOverlay from "./components/LoadOverlay.vue";
import AppBar from "./components/AppBar.vue";
import Filters from "./components/Filters.vue";
import { EventBus } from "./event-bus";

export default {
  name: "App",
  data: (vm) => ({
    initialDark: vm.$vuetify ? vm.$vuetify.theme.dark : false,
    loading: true,
    showFilters: false,
    hasFilters: false,
  }),
  components: {
    LoadOverlay,
    AppBar,
    Filters,
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
    ...mapGetters(["getInternships"]),
  },
  methods: {
    ...mapActions([
      "fetchInternships",
      "fetchMajors",
      "fetchCompanies",
      "fetchDisciplines",
      "fetchLocations",
      "fetchRatings",
    ]),
    logout() {
      this.$auth.logout();
      this.$router.push({ path: "/" }).catch(() => {});
    },
    close(val) {
      this.showFilters = val;
    },
    clearFilters() {
      EventBus.$emit("clearFilters");
      this.hasFilters = false;
    },
    setHasFilters(val) {
      this.hasFilters = val;
    },
  },
  // created() {
  //   window.addEventListener("beforeunload", this.logout);
  // },
};
</script>

<style lang="scss" scoped>
.inspire {
  min-height: 100%;
}
.page {
  margin: 25px 0px;
  @media all and (max-width: 960px) {
    margin: 35px 0px 35px;
  }
}
.filter-btn {
  bottom: 25px;
  right: 25px;
}
.clear-btn {
  bottom: 95px;
  right: 25px;
}
</style>
