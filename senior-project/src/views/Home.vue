<template>
    <div id="app">
        <img class="background" src="../assets/background.png">
        <!-- <img  src="../assets/Internshare.png"> -->
        <v-card class="intro">
          <v-card-actions>
            <v-text-field
              label="Search for a company to start exploring!"
              single-line
              solo hide-details
              append-icon="mdi-magnify"
            ></v-text-field>
          </v-card-actions>
          <v-card-actions class="center-btn">
            <v-btn text small class="add-btn" @click="addPost">
              I'd like to create a post
            </v-btn>
          </v-card-actions>
        </v-card>
        <!-- </div> -->
    </div>
</template>

<script>

export default {
  name: "Home",
  components: {},
  computed: {},
  methods: {
    addPost() {
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
@import url('https://fonts.googleapis.com/css2?family=Rammetto+One&display=swap');
.title {
  font-size: 2.5rem !important;
  text-align: center;
  font-family: 'Rammetto One', cursive;
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
.background {
  position: absolute;
  width: 100%;
}
.add-btn {
  color: white;
}
.add-btn::before {
  display: none;
}
.home-wrapper {
  text-align: center;
  justify-content: center;
}
.center-btn {
  justify-content: center;
}
.intro {
  text-align:center;
  justify-content: center;
  background:rgb(95,106,160,0.85);
  padding: 50px 30px;
  position: fixed;
  top: 50%;
  left: 50%;
  min-width: 500px;
  min-height: 200px;
  transform: translate(-50%, -50%);
  box-shadow: 0px 6px 6px -3px rgb(0 0 0 / 20%), 0px 10px 14px 1px rgb(0 0 0 / 14%), 0px 4px 18px 3px rgb(0 0 0 / 12%) !important;
}
</style>
