<template>
  <v-container class="explore">
    <h1 class="title">Explore experiences here!</h1>
    <div v-if="getInternships.length > 0">
      <div v-for="item in getInternships" :key="item.id">
        <v-row>
          <v-col cols="10" sm="10" class="remove-padding">
            <internship-card class="icard" :data="item" />
          </v-col>
          <v-col cols="2" sm="2" class="vote-wrapper remove-padding">
            <div class="wrapper">
              <v-btn large icon @click="upVote(item)" class="up">
                <v-icon>mdi-arrow-up-bold-circle-outline</v-icon>
              </v-btn>
              <div class="vote-text">{{ item.votes }}</div>
              <v-btn
                icon
                large
                :disabled="item.votes === 0"
                @click="downVote(item)"
                class="down"
              >
                <v-icon>mdi-arrow-down-bold-circle-outline</v-icon>
              </v-btn>
            </div>
          </v-col>
        </v-row>
      </div>
    </div>
    <div v-else>
      <v-row>
        <v-col cols="12" sm="12" class="center">
          <v-btn text x-large class="add-btn" @click="addPost"
            >No internships shared. Click here to be the first!</v-btn
          >
        </v-col>
      </v-row>
    </div>
  </v-container>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import InternshipCard from "../components/InternshipCard.vue";
import { EventBus } from '../event-bus';

export default {
  name: "Explore",
  data: () => ({
    filters: []
  }),
  props: {},
  components: {
    InternshipCard,
  },
  mounted() {
    EventBus.$on('filter', (val) => {
      this.filters = [...val]
    })
    EventBus.$on('clearFilter', () => {
      this.filters = []
    })
  },
  computed: {
    ...mapGetters(["getInternships"]),
    filteredInternships() {
      return this.getInternships.filter((x) => {
        console.log(this.filters.some((y) => x.includes(y)))
        return this.filters.some((y) => x.includes(y))
      })
    }
  },
  methods: {
    ...mapActions(["updateVote"]),
    addPost() {
      this.$router.push({ name: "Create" }).catch(() => {});
    },
    upVote(internship) {
      internship.votes += 1;
      this.updateVote({ internship: internship });
    },
    downVote(internship) {
      internship.votes -= 1;
      this.updateVote({ internship: internship });
    },
  },
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
.center {
  align-content: center;
  text-align: center;
  justify-content: center;
}
.add-btn::before {
  display: none;
}
</style>
