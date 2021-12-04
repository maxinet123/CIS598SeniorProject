<template>
  <div>
    <div v-if="getInternships.length > 0">
      <v-row v-for="item in getInternships" :key="item.id">
        <v-col cols="10" sm="8" offset-sm="2" class="remove-padding">
          <internship-card :data="item" />
        </v-col>
        <v-col cols="2" sm="2" class="vote-wrapper remove-padding">
          <div class="wrapper">
            <v-tooltip right>
              <template v-slot:activator="{ on, attrs }">
                  <v-btn v-bind="attrs" v-on="on"
                    large icon
                    @click="upVote(item)"
                    class="up"
                    :disabled="!$auth.isAuthenticated"
                    :loading="!isSaved"
                  >
                    <v-icon>mdi-arrow-up-bold-circle-outline</v-icon>
                  </v-btn>
              </template>
              <span>Helpful</span>
            </v-tooltip>
            <div class="vote-text">{{ item.votes }}</div>
            <v-tooltip right>
              <template v-slot:activator="{ on, attrs }">
                  <v-btn v-bind="attrs" v-on="on"
                    icon
                    large
                    @click="downVote(item)"
                    class="down"
                    :disabled="!$auth.isAuthenticated || item.votes === 0"
                    :loading="!isSaved"
                  >
                  <v-icon>mdi-arrow-down-bold-circle-outline</v-icon>
                </v-btn>
              </template>
              <span>Unhelpful</span>
            </v-tooltip>
          </div>
        </v-col>
      </v-row>
    </div>
    <div v-else>
      <v-row>
        <v-col cols="12" sm="12" class="center">
          <v-btn text x-large class="add-btn" @click="addPost">
            No internships shared. Click here to be the first!
          </v-btn>
        </v-col>
      </v-row>
    </div>
  </div>
</template>

<script>
import { mapActions } from "vuex";
import InternshipCard from "./InternshipCard.vue";
import { EventBus } from "../event-bus";

export default {
  name: "Postings",
  data: () => ({
    filters: [],
    isSaved: true,
  }),
  props: {
    getInternships: Array,
  },
  components: {
    InternshipCard,
  },
  mounted() {
    EventBus.$on("filter", (val) => {
      this.filters = [...val];
    });
    EventBus.$on("clearFilter", () => {
      this.filters = [];
    });
  },
  computed: {
    filteredInternships() {
      if (this.filters.length > 0) {
        this.getInternships.filter((x) => {
          console.log(this.filters.some((y) => x.includes(y)))
          return this.filters.some((y) => x.includes(y))
        }, [])
      }
      return this.getInternships;
    },
  },
  methods: {
    ...mapActions(["upVote", "downVote"]),
    addPost() {
      this.$router.push({ name: "Create" }).catch(() => {});
    },
    upVote(internship) {
      this.isSaved = false;
      this.upVote({ id: internship.id, total: internship.votes }).finally(
        () => {
          this.isSaved = true;
        }
      );
    },
    downVote(internship) {
      this.isSaved = false;
      this.downVote({ id: internship.id, total: internship.votes }).finally(
        () => {
          this.isSaved = true;
        }
      );
    },
  },
};
</script>

<style lang="scss" scoped>
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
