<template>
  <v-navigation-drawer absolute permanent expand-on-hover class="nav-drawer">
    <v-list v-if="!$auth.loading && $auth.isAuthenticated">
      <v-list-item>
        <v-list-item-content>
          <v-list-item-title class="text-h6">
            {{ $auth.user.nickname }}
          </v-list-item-title>
          <v-list-item-subtitle>{{ $auth.user.email }}</v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>
    </v-list>

    <v-divider></v-divider>

    <v-list nav dense>
      <v-list-item link @click="home">
        <v-list-item-icon>
          <v-icon>mdi-home</v-icon>
        </v-list-item-icon>
        <v-list-item-title>Home</v-list-item-title>
      </v-list-item>

      <v-list-item link @click="create">
        <v-list-item-icon>
          <v-icon>mdi-square-edit-outline</v-icon>
        </v-list-item-icon>
        <v-list-item-title>Create</v-list-item-title>
      </v-list-item>

      <v-list-item link @click="explore">
        <v-list-item-icon>
          <v-icon>mdi-compass</v-icon>
        </v-list-item-icon>
        <v-list-item-title>Expore</v-list-item-title>
      </v-list-item>

      <v-list-item
        link
        @click="login"
        v-show="!$auth.loading && !$auth.isAuthenticated"
      >
        <v-list-item-icon>
          <v-icon>mdi-account</v-icon>
        </v-list-item-icon>
        <v-list-item-title>Login</v-list-item-title>
      </v-list-item>

      <v-list-item
        @click="logout"
        v-show="!$auth.loading && $auth.isAuthenticated"
      >
        <v-list-item-icon>
          <v-icon>mdi-share</v-icon>
        </v-list-item-icon>
        <v-list-item-title>Logout</v-list-item-title>
      </v-list-item>
    </v-list>
  </v-navigation-drawer>
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
.nav-drawer {
  margin-top: 48px;
}
</style>
