<template>
  <v-overlay :value="overlay" :z-index="6" :opacity=".75"> 
      <lottie :options="defaultOptions" :height="150" :width="150" class="loader"
        @animCreated="handleAnimation"/>
  </v-overlay>
</template>

<script>
import animationData from '../assets/loader.json';
import Lottie from "vue-lottie";

export default {
  name: "LoadOverlay",
  data: () => ({
    overlay: true,
    defaultOptions: {animationData: animationData},
  }),
  components: {
    Lottie,
  },
  methods: {
    handleAnimation(anim) {
      this.anim = anim;
    },
  }
};
</script>
<style lang="scss" scoped>
.loader > svg > g > g > g > path {
  fill: transparent !important;
}
</style>
