<template>
  <div>
    <v-app-bar app color="deep-purple" fixed dense dark elevate-on-scroll>
      <v-app-bar-nav-icon @click="drawer = true"></v-app-bar-nav-icon>
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
    <v-navigation-drawer v-model="drawer" absolute temporary>
      <v-list nav dense>
        <v-list-item-group
          v-model="group"
          active-class="deep-purple--text text--accent-4"
        >
          <v-list-item @click="home">
            <v-list-item-icon>
              <v-icon>mdi-home</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Home</v-list-item-title>
          </v-list-item>

          <v-list-item @click="create">
            <v-list-item-icon>
              <v-icon>mdi-square-edit-outline</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Create Post</v-list-item-title>
          </v-list-item>

          <v-list-item @click="explore">
            <v-list-item-icon>
              <v-icon>mdi-compass</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Expore Posts</v-list-item-title>
          </v-list-item>

          <v-list-item @click="login" v-show="false">
            <v-list-item-icon>
              <v-icon>mdi-account</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Login</v-list-item-title>
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
      this.$router.push({ name: "Home" });
    },
    create() {
      this.$router.push({ name: "Create" });
    },
    explore() {
      this.$router.push({ name: "Explore" });
    },
    login() {
      this.$router.push({ name: "Login" });
    },
    account() {
      this.$router.push({ name: "Explore" });
    },
  },
};
</script>

<style lang="scss" scoped>
.sunny-theme {
  padding-right: 15px;
}
</style>
