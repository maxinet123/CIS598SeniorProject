<template>
  <v-container>
    <v-row>

    </v-row>
    <v-row class="text-center">
      <v-col cols="12" md="6" sm="12">
        <v-card class="card-style" @click="create">
          Create Post
        </v-card>
      </v-col>
      <v-col cols="12" md="6" sm="12">
        <v-card class="card-style" @click="explore">
          Explore Posts
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>

export default {
  name: "Home",

  components: {
  },
  methods: {
    create() {
      console.log('create logic')
    },
    explore() {
      console.log('explore logic')
    },
  }
};
</script>
<style lang="scss" scoped>
.card-style {
  min-height: 100px;
}
</style>
