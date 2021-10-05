<template>
    <div>
    <v-app-bar app color="deep-purple" dark elevate-on-scroll>
        <v-app-bar-nav-icon @click="drawer = true"></v-app-bar-nav-icon>
        <v-spacer></v-spacer>
        <v-btn icon @click="account">
            <v-icon>mdi-account</v-icon>
        </v-btn>
    </v-app-bar>
    <v-navigation-drawer v-model="drawer" absolute temporary >
      <v-list nav dense >
        <v-list-item-group v-model="group" active-class="deep-purple--text text--accent-4">
          <v-list-item>
            <v-list-item-icon>
              <v-icon>mdi-home</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Home</v-list-item-title>
          </v-list-item>

          <v-list-item>
            <v-list-item-icon>
              <v-icon>mdi-square-edit-outline</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Create Post</v-list-item-title>
          </v-list-item>

          <v-list-item>
            <v-list-item-icon>
              <v-icon>mdi-compass</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Expore Posts</v-list-item-title>
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
    methods: {
        account() {
            console.log('stuff')
        }
    },
}
</script>

<style lang="scss" scoped>

</style>