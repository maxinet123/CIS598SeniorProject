<template>
  <div>
    <v-app-bar app color="#5f6aa0" fixed dark elevation="10">
      <v-app-bar-nav-icon @click="drawer = true"></v-app-bar-nav-icon>
      <v-btn v-show="$route.name !== 'Create' || $route.name !== 'Home'"
        text @click="create">
        Create
      </v-btn>
      <v-spacer></v-spacer>
      <v-btn v-show="!$auth.loading && !$auth.isAuthenticated"
        text @click="login">
        Login
      </v-btn>
      <v-btn v-show="!$auth.loading && $auth.isAuthenticated"
        text @click="logout">
        Logout
      </v-btn>
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

          <v-list-item link @click="explore">
            <v-list-item-icon>
              <v-icon>mdi-compass</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Explore</v-list-item-title>
          </v-list-item>

          <v-list-item link @click="profile" v-show="!$auth.loading && $auth.isAuthenticated">
            <v-list-item-icon>
              <v-icon>mdi-account</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Profile</v-list-item-title>
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
  },
};
</script>

<style lang="scss" scoped>
.menu {
  min-width: 90px;
  top: 60px;
  left: 600px;
  z-index: 5;
  text-align: center;
}

</style>
