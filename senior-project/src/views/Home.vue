<template>
    <div id="app">
        <img class="background" src="../assets/background.png">
        <img class="title" src="../assets/Internshare.png">
        <v-card class="intro">
          <v-card-actions>
            <v-text-field v-model="searched"
              label="Search to start exploring! (ex. Company Name)"
              single-line
              solo hide-details
              @click:append="explore"
              append-icon="mdi-magnify"
            ></v-text-field>
          </v-card-actions>
        </v-card>
    </div>
</template>

<script>
import { EventBus } from "../event-bus";
export default {
  name: "Home",
  data: () => ({
    searched: "",
  }),
  components: {},
  computed: {},
  methods: {
    explore() {
      EventBus.$emit("hasFilters", true);
      this.$router.push({
        name: "Explore",
        params: { searched: this.searched }
      }).catch(() => {})
    },
  },
  mounted() {},
};
</script>
<style lang="scss" scoped>
.title {
  top: 20%;
  left: 50%;
  position: fixed;
  transform: translate(-50%, -20%);
  justify-content: center;
  width: 500px;
}
.background {
  position: absolute;
  width: 100%;
  justify-content: center;
  align-content: center;
  top: 50%;
  transform: translateY(-50%);
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
  background:rgb(95,106,160,0.80);
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
