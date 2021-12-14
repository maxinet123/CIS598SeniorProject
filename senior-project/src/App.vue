<template>
  <v-app class="inspire">
    <load-overlay v-show="loading || $auth.isLoading" />
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
            color="#5f6aa0"
            fixed
            class="clear-btn"
            fab dark
            @click="clear"
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
            color="#5f6aa0"
            fixed dark
            class="filter-btn"
            fab 
            @click="showOverlay"
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
import { EventBus } from "./event-bus";

export default {
  name: "App",
  data: () => ({
    loading: true,
    hasFilters: false,
  }),
  components: {
    LoadOverlay,
    AppBar,
  },
  mounted() {
    setTimeout(() => {
      this.fetchInternships()
        .finally(() => {
          this.loading = false;
        });
    }, 5000);
    EventBus.$on("hasFilters", (val) => {
      this.hasFilters = val
    });
  },
  computed: {
    ...mapGetters(["getInternships"]),
  },
  methods: {
    ...mapActions([
      "fetchInternships",
      "addUser"
    ]),
    logout() {
      this.$auth.logout();
      this.$router.push({ path: "/" }).catch(() => {});
    },
    clear() {
      EventBus.$emit("clearFilters");
      EventBus.$emit("clearFilterChips");
      this.hasFilters = false;
    },
    showOverlay() {
      EventBus.$emit('show', true)
    }
  },
  watch: {
    '$auth.user': {
      deep: true,
      handler() {
        if (this.$auth.user) {
          this.addUser({ user: {...this.$auth.user}})
        }
      }
    }
  },
  created() {
    window.addEventListener("beforeunload", this.logout);
  },
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
.overlay {
  z-index: 6 !important;
}
</style>
