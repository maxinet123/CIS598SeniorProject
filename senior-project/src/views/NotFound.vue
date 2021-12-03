<template>
  <v-container class="explore">
    <lottie
      :options="defaultOptions"
      :height="500"
      :width="500"
      @animCreated="handleAnimation"
    />
  </v-container>
</template>

<script>
import animationData from "../assets/404.json";
import Lottie from "vue-lottie";

export default {
  name: "NotFound",
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
