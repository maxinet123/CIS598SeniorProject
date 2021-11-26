<template>
    <v-overlay :value="overlay" :z-index="2">
        <v-progress-circular
            :size="50"
            color="purple"
            indeterminate
            ></v-progress-circular>
        <!-- <lottie-animation
            path="https://lottiefiles.com/9629-loading"
            :loop="true"
            :autoPlay="true"
            :loopDelayMin="2.5"
            :loopDelayMax="5"
            :speed="1"
        /> -->
    </v-overlay>
</template>

<script>
// import LottieAnimation from "lottie-vuejs";

export default {
    name: "LoadOverlay",
    data: () => ({
        overlay: true,
    }),
    components: {
        // LottieAnimation
    },
}
</script>

<style lang="scss" scoped>

</style>