<template>
  <v-row >
    <v-col cols="8" offset-sm="2" class="remove-padding">
      <internship-card :data="item" />
    </v-col>
    <!-- <v-col cols="2" sm="2" class="vote-wrapper remove-padding">
      <div class="wrapper">
        <v-tooltip right>
          <template v-slot:activator="{ on, attrs }">
              <v-btn v-bind="attrs" v-on="on"
                large icon
                @click="upVote(item)"
                class="up"
                :disabled="!$auth.isAuthenticated"
                :loading="!isSavedUp"
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
                :loading="!isSavedDown"
              >
              <v-icon>mdi-arrow-down-bold-circle-outline</v-icon>
            </v-btn>
          </template>
          <span>Unhelpful</span>
        </v-tooltip>
      </div>
    </v-col> -->
  </v-row>
</template>

<script>
import { mapActions } from "vuex";
import InternshipCard from "./InternshipCard.vue";

export default {
  name: "Postings",
  data: () => ({
    isSavedUp: true,
    isSavedDown: true,
  }),
  props: {
    item: Object,
  },
  components: {
    InternshipCard,
  },
  mounted() {
  },
  methods: {
    ...mapActions(["upVote", "downVote"]),
    upVote(internship) {
      this.isSavedUp = false;
      this.upVote({ id: internship.id, total: internship.votes }).finally(
        () => {
          this.isSavedUp = true;
        }
      );
    },
    downVote(internship) {
      this.isSavedDown = false;
      this.downVote({ id: internship.id, total: internship.votes }).finally(
        () => {
          this.isSavedDown = true;
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
