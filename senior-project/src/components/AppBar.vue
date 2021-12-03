<template>
  <div>
    <v-app-bar app class="primary" fixed dark elevation="10">
      <v-app-bar-nav-icon @click="drawer = true"></v-app-bar-nav-icon>
      <v-btn v-show="$route.name !== 'Create'" text @click="create">Create</v-btn>
      <v-spacer></v-spacer>
      <!-- <v-icon class="sunny-theme">mdi-weather-sunny</v-icon>
      <v-switch v-model="$vuetify.theme.dark"
        hide-details inset type="button" />
      <v-icon>mdi-weather-night</v-icon> -->
      <v-menu left bottom>
        <template v-slot:activator="{ on, attrs }">
          <v-btn
            v-bind="attrs"
            v-on="on"
            small
            fab
            outlined
            v-show="!$auth.loading"
          >
            <v-icon>mdi-account</v-icon>
          </v-btn>
        </template>
        <v-list>
          <v-list-item
            link
            @click="login"
            v-show="!$auth.loading && !$auth.isAuthenticated"
          >
            <v-list-item-title>Login</v-list-item-title>
          </v-list-item>
          <v-list-item
            link
            @click="profile"
            v-show="!$auth.loading && $auth.isAuthenticated"
          >
            <v-list-item-title>Profile</v-list-item-title>
          </v-list-item>
          <v-list-item
            @click="logout"
            v-show="!$auth.loading && $auth.isAuthenticated"
          >
            <v-list-item-title>Logout</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>
    </v-app-bar>
    <v-navigation-drawer v-model="drawer" absolute temporary>
      <v-list nav dense>
        <v-list-item-group v-model="group" active-class="text--accent-4">
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
            <v-list-item-title>Explore</v-list-item-title>
          </v-list-item>

          <v-list-item
            link
            href="https://docs.google.com/forms/d/e/1FAIpQLSc9ksFU16noxq8qh3cCZ-gZM4VkJWx6eDtlf2RyuFN0SGtlPw/viewform?embedded=true"
            target="_blank"
            rel="noreferrer noopener"
          >
            <v-list-item-icon>
              <v-icon>mdi-message-draw</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Feedback</v-list-item-title>
          </v-list-item>
        </v-list-item-group>
      </v-list>
    </v-navigation-drawer>
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
