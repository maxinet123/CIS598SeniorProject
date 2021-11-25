<template>
    <v-overlay :value="overlay" :z-index="2">
        Loading
        <lottie-animation
            path="./assets/loading.json"
            :loop="false"
            :autoPlay="true"
            :loopDelayMin="2.5"
            :loopDelayMax="5"
            :speed="1"
        />
    </v-overlay>
</template>

<script>
import LottieAnimation from "lottie-vuejs/src/LottieAnimation.vue";

export default {
    name: "LoadOverlay",
    data: () => ({
        overlay: true,
    }),
    components: {
        LottieAnimation
    },
}
</script>

<style lang="scss" scoped>

</style>