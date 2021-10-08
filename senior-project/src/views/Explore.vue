<template>
  <v-container class="explore">
    <div v-for="internship in internships" :key="internship.name">
      <internship-card :internship="internship" />
    </div>
  </v-container>
</template>

<script>
import InternshipCard from "../components/InternshipCard.vue";
export default {
  name: "Explore",
  data: () => ({
    internships: [
      {
        name: "Commerce Bank",
      },
    ],
  }),
  props: {},
  components: {
    InternshipCard,
  },
  computed: {},
  methods: {},
  watch: {},
};
</script>

<style lang="scss" scoped>
.v-card {
  padding: 20px;
}
</style>
