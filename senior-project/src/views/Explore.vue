<template>
  <v-container class="explore">
    <div v-for="internship in internships" :key="internship.id">
      <internship-card class="icard" :internship="internship" />
    </div>
  </v-container>
</template>

<script>
import { mapGetters } from "vuex";
import InternshipCard from "../components/InternshipCard.vue";

export default {
  name: "Explore",
  data: () => ({
    internships: [
      {
        id: 1,
        name: 'IT Intern',
        company: 'Commerce Bank',
        description: 'It was fun!!',
      },
      {
        id: 2,
        name: 'IT Intern',
        company: 'Commerce Bank',
        description: 'It was fun!!',
      }
    ]
  }),
  props: {},
  components: {
    InternshipCard,
  },
  mounted() {
    //console.log(this.getInternships)
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
.icard {
  padding: 20px;
  margin: 10px;
}
</style>
