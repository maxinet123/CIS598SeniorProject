<template>
  <div>
    <v-row>
      <h1>Welcome!</h1>
    </v-row>
    <v-row>
      <v-col cols="12" md="6" sm="6">
        <v-card class="text-center card-style" @click="create">
          <v-card-actions>
              <div class="circle">
                <v-icon class="icon">mdi-pencil</v-icon>
              </div>
          </v-card-actions>
          <v-card-title>
            Create Post
          </v-card-title>
        </v-card>
      </v-col>
      <v-col cols="12" md="6" sm="6">
        <v-card class="card-style" @click="explore">
          <v-card-actions>
            <div class="circle">
              <v-icon class="icon">mdi-compass</v-icon>
            </div>
          </v-card-actions>
          <v-card-title>
            Explore Posts
          </v-card-title>
        </v-card>
      </v-col>
    </v-row>
  </div>
</template>

<script>
export default {
  name: "Home",
  components: {},
  methods: {
    create() {
      this.$router.push({ name: "Create"})
    },
    explore() {
      this.$router.push({ name: "Explore"})
    },
  },
};
</script>
<style lang="scss" scoped>
.card-style {
  display: flex;
  flex-direction: column;
  padding: 50px;
  align-content: center;
  text-align: center;
  .v-card__actions {
    justify-content: center;
  }
  .v-card__title {
    justify-content: center;
    word-break: normal;
  }
}
.circle {
  height: 150px;
  width: 150px;
  border-radius: 150px;
  border: 1px solid #673ab7;
  background: #673ab77d;
  display: flex;
  align-content: center;
  justify-content: center;
  // @media all and (max-width: 1263px) {
  //   height: 100px;
  //   width: 100px;
  // }
  @media all and (max-width: 959px) {
    height: 150px;
    width: 150px;
  }
}
.icon {
  z-index: 1;
  font-size: 64px;
  color: #673ab7;
}
</style>
