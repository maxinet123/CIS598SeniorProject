<template>
      <v-navigation-drawer absolute permanent expand-on-hover>
        <v-list v-if="!$auth.loading && $auth.isAuthenticated">
            <v-list-item class="px-2">
            <v-list-item-avatar>
                <v-img src="https://randomuser.me/api/portraits/women/85.jpg"></v-img>
            </v-list-item-avatar>
            </v-list-item>

            <v-list-item link>
            <v-list-item-content>
                <v-list-item-title class="text-h6">
                {{$auth.user.name}}
                </v-list-item-title>
                <v-list-item-subtitle>{{$auth.user.email}}</v-list-item-subtitle>
            </v-list-item-content>
            </v-list-item>
        </v-list>

        <v-divider></v-divider>
        
        <v-list nav dense >

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
            <v-list-item-title>Create Post</v-list-item-title>
          </v-list-item>

          <v-list-item link @click="explore">
            <v-list-item-icon>
              <v-icon>mdi-compass</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Expore Posts</v-list-item-title>
          </v-list-item>

          <v-list-item link
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
      this.$auth.loginWithRedirect()
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
