<template>
  <div>
    <v-row>
      <v-col cols="12" sm="12">
        <h1 class="title">Welcome to Internshare!</h1>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12" md="6" sm="6">
        <v-card class="card-style grey" @click="create">
          <v-card-actions>
            <div class="circle primary">
              <v-icon class="icon icon_color">mdi-pencil</v-icon>
            </div>
          </v-card-actions>
          <v-card-title> Create </v-card-title>
        </v-card>
      </v-col>
      <v-col cols="12" md="6" sm="6">
        <v-card class="card-style grey" @click="explore">
          <v-card-actions>
            <div class="circle primary">
              <v-icon class="icon">mdi-compass</v-icon>
            </div>
          </v-card-actions>
          <v-card-title> Explore </v-card-title>
        </v-card>
      </v-col>
    </v-row>
  </div>
</template>

<script>
export default {
  name: "Home",
  components: {},
  computed: {},
  methods: {
    create() {
      this.$router.push({ name: "Create" });
    },
    explore() {
      this.$router.push({ name: "Explore" });
    },
  },
  mounted() {},
};
</script>
<style lang="scss" scoped>
.title {
  font-size: 2.5rem !important;
  text-align: center;
  margin: 10px 0px 25px 0px;
}
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
  min-height: 150px;
  min-width: 150px;
  border-radius: 150px;
  display: flex;
  align-content: center;
  justify-content: center;
  // @media all and (max-width: 1263px) {
  //   height: 100px;
  //   width: 100px;
  // }
  @media all and (max-width: 959px) {
    min-height: 150px;
    min-width: 150px;
  }
}
.icon {
  z-index: 0;
  font-size: 64px;
  color: white;
}
</style>
