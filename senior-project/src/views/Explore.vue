<template>
  <v-container class="explore">
    <div v-for="internship in getInternships" :key="internship.id.pid">
      <internship-card :internship="internship" />
    </div>
  </v-container>
</template>

<script>
import { mapGetters } from "vuex";
import InternshipCard from "../components/InternshipCard.vue";

export default {
  name: "Explore",
  data: () => ({
  }),
  props: {},
  components: {
    InternshipCard,
  },
  mounted() {
    console.log(this.getInternships)
  },
  computed: {
    ...mapGetters(["getInternships"]),
  },
  methods: {
  },
  watch: {},
};
</script>

<style lang="scss" scoped>
.v-card {
  padding: 20px;
}
</style>
