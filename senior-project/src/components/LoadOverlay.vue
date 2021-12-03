<template>
  <v-overlay :value="overlay" :z-index="6" :opacity="0.75">
    <lottie
      :options="defaultOptions"
      :height="150"
      :width="150"
      class="loader"
      @animCreated="handleAnimation"
    />
  </v-overlay>
</template>

<script>
import animationData from "../assets/loader.json";
import Lottie from "vue-lottie";

export default {
  name: "LoadOverlay",
  data: () => ({
    overlay: true,
    defaultOptions: {
      animationData: animationData,
      loop: true,
      autoplay: true
    },
  }),
  components: {
    Lottie,
  },
  methods: {
    handleAnimation(anim) {
      this.anim = anim;
    },
  },
};
</script>
<style lang="scss" scoped>
</style>
