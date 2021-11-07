<template>
  <v-container class="explore">
    <h1 class="title">Explore experiences here!</h1>
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
        description: "It was fun!! All the IT Interns worked on a team together. We worked with product manager and we assigned two technical mentors.",
        rating: 5,
        duration: "11 weeks",
        wage: "$$$",
        vote: 5,
        city: 'Kansas City',
        state: 'MO'
      },
      {
        id: 2,
        name: "Electrical Engineering Intern",
        company: "Smith and Boucher",
        description: "Fun place and people. Interesting work.",
        rating: 4,
        duration: "8 weeks",
        wage: "$$$",
        vote: 2,
        city: 'Olathe',
        state: 'KS'
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
.title {
  font-size: 2.5rem !important;
  text-align: center;
  margin-bottom: 25px;
}
.icard {
  padding: 20px;
  margin: 10px;
}
</style>
