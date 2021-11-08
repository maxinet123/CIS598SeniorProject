<template>
  <v-container class="explore">
    <h1 class="title">Explore experiences here!</h1>
    <div v-if="getInternships.length > 0">
      <div v-for="internship in getInternships" :key="internship.id">
        <v-row>
          <v-col cols="10" sm="10" class="remove-padding"> 
            <internship-card class="icard" :internship="internship" />
          </v-col>
          <v-col cols="2" sm="2" class="vote-wrapper remove-padding">
            <div class="wrapper">
              <v-btn large icon @click="upVote(internship)" class="up">
                <v-icon>mdi-arrow-up-bold-circle-outline</v-icon>
              </v-btn>
              <div class="vote-text">{{ internship.vote }}</div>
              <v-btn icon large @click="downVote(internship)" class="down">
                <v-icon>mdi-arrow-down-bold-circle-outline</v-icon>
              </v-btn>
              </div>
          </v-col>
        </v-row>
      </div>
    </div>
    <div v-else>
      <h2>No internships shared. Be the first!</h2>
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
    upVote(internship) {
      console.log(internship.vote++)
    },
    downVote(internship) {
      console.log(internship.vote--)
    },
  },
  watch: {},
};
</script>

<style lang="scss" scoped>
.title {
  font-size: 2.5rem !important;
  text-align: center;
  margin-bottom: 25px;
}
.remove-padding {
  padding: 0px !important;
}
.vote-text {
  font-size: 18px;
}
.wrapper {
  text-align: center;
  align-content: center;
  max-width: 75px;
}
.vote-wrapper {
  display: flex;
  flex-direction: column;
  justify-content: center;
  //text-align: center;
  //align-items: center;
}
</style>
