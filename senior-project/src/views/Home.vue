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
          <v-row>
            <v-col cols="12" md="12">
              <div class="icon-wrapper">
                <v-icon class="mdi-48px">mdi-compass</v-icon>
              </div>
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="12" md="12">
              <h2>Expore Posts</h2>
            </v-col>
          </v-row>
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
.icon-wrapper {
  min-height: 150px;
  max-width: 150px;
  border: 1px solid blue;
  border-radius: 75px;
  color: greenyellow;
}
</style>
