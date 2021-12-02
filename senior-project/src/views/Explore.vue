<template>
  <v-container class="explore">
    <h1 class="title">Explore experiences here!</h1>
    <postings :getInternships="getInternships" />
  </v-container>
</template>

<script>
import { mapGetters } from "vuex";
import Postings from "../components/Postings.vue"
export default {
  name: "Explore",
  data: () => ({}),
  components: {
    Postings
  },
  computed: {
    ...mapGetters(["getInternships"]),
  },
  methods: {},
};
</script>

<style lang="scss" scoped>
.title {
  font-size: 2.5rem !important;
  text-align: center;
  margin-bottom: 25px;
}
</style>
