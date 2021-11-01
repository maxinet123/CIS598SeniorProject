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
    internships: [ //.sort((a,b)=> {})
      {
        id: 1,
        name: "IT Intern",
        company: "Commerce Bank",
        description: "It was fun!!",
        rating: 5,
        duration: "11 weeks",
        vote: 100,
        city: 'Shawnee',
        state: 'KS'
      },
      {
        id: 2,
        name: "IT Intern",
        company: "Commerce Bank",
        description: "It was fun!!",
        rating: 2,
        duration: "5 weeks"
      },
    ],
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
  methods: {},
  watch: {},
};
</script>

<style lang="scss" scoped>
.icard {
  padding: 20px;
  margin: 10px;
}
</style>
