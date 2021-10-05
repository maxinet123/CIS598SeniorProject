<template>
  <div>
    <v-row>
      <h1>Welcome!</h1>
    </v-row>
    <v-row class="text-center">
      <v-col cols="12" md="6" sm="6">
        <v-card class="card-style" @click="create">
          <v-row>
            <v-col cols="12" md="12">
              <div class="icon-wrapper">
                <v-icon class="icon">mdi-pencil</v-icon>
              </div>
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="12" md="12">
              <h2>Create Post</h2>
            </v-col>
          </v-row>
        </v-card>
      </v-col>
      <v-col cols="12" md="6" sm="6">
        <v-card class="card-style" @click="explore">
          <v-row>
            <v-col cols="12" md="12">
              <div class="icon-wrapper">
                <v-icon class="icon">mdi-compass</v-icon>
              </div>
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="12" md="12">
              <h2>Explore Posts</h2>
            </v-col>
          </v-row>
        </v-card>
      </v-col>
    </v-row>
  </div>
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
  min-width: 250px;
  min-height: 300px;
  padding: 50px;
}
.icon-wrapper {
  display: flex;
  justify-content: center;
  text-align: center;
  min-height: 150px;
  max-width: 150px;
  border: 1px solid lightgray;
  border-radius: 75px;
  background: #673ab77d;
  padding: 50px;
  z-index: 0;
}
.icon {
  z-index: 1;
  font-size: 48px;
  color: #673ab7;
}
</style>
