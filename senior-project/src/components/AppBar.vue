<template>
  <div>
    <v-app-bar app class="purple" fixed dense dark elevate-on-scroll>
      <h2 class="logo">Internshare.com</h2>
      <v-spacer></v-spacer>
      <v-icon class="sunny-theme">mdi-weather-sunny</v-icon>
      <v-switch
        v-model="$vuetify.theme.dark"
        hide-details
        inset
        type="button"
      />
      <v-icon>mdi-weather-night</v-icon>
    </v-app-bar>
  </div>
</template>

<script>
export default {
  name: "AppBar",
  data: () => ({
    drawer: false,
    group: null,
  }),
  components: {},
  computed: {},
  methods: {
    home() {
      this.$router.push({ name: "Home" }).catch(() => {});
    },
    create() {
      this.$router.push({ name: "Create" }).catch(() => {});
    },
    explore() {
      this.$router.push({ name: "Explore" }).catch(() => {});
    },
    login() {
      this.$auth.loginWithRedirect();
    },
    logout() {
      this.$auth.logout();
      this.$router.push({ path: "/" }).catch(() => {});
    },
    profile() {
      this.$router.push({ name: "Profile" }).catch(() => {});
    },
  },
};
</script>

<style lang="scss" scoped>
.sunny-theme {
  padding-right: 15px;
}
</style>
