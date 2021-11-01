<template>
  <div>
    <v-card class="icard">
      <v-row>
        <v-col cols="12" sm="10">
          <v-row>
            <v-col cols="12" sm="10">
              {{ internship.name }}
            </v-col>
            <v-col cols="12" sm="2">
              <div class="stars">
                <star-rating
                  v-model="internship.rating"
                  :read-only="true"
                  :show-rating="false"
                  :inline="true"
                  :star-size="20"
                ></star-rating>
              </div>
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="12" sm="6">
              {{internship.company}}
            </v-col>
            <v-col cols="12" sm="6">
              {{internship.discipline}}
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="12" sm="6">
              {{internship.location}}
            </v-col>
            <v-col cols="12" sm="6">
              {{internship.duration}}
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="12" sm="12">
              <v-textarea
                v-model="internship.description"
                readonly
                outlined
                hide-details
                rows="5"
                auto-grow>
              </v-textarea>
            </v-col>
          </v-row>
        </v-col>
        <v-col cols="12" sm="2" class="vote-wrapper">
          <v-row class="vote">
            <v-col cols="12" md="12">
              <v-btn icon @click="upVote">
                <v-icon>mdi-arrow-up-bold-circle-outline</v-icon>
              </v-btn>
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="12" md="12"> {{ internship.vote }} </v-col>
          </v-row>
          <v-row>
            <v-col cols="12" md="12">
              <v-btn icon @click="downVote">
                <v-icon>mdi-arrow-down-bold-circle-outline</v-icon>
              </v-btn>
            </v-col>
          </v-row>
        </v-col>
      </v-row>
    </v-card>
  </div>
</template>

<script>
import StarRating from "vue-star-rating";
export default {
  name: "InternshipCard",
  data: () => ({}),
  props: {
    internship: Object,
  },
  components: {
    StarRating,
  },
  computed: {},
  methods: {
    upVote() {
      console.log(this.internship.vote++)
    },
    downVote() {
      console.log(this.internship.vote--)
    },
  },
  watch: {},
};
</script>

<style lang="scss" scoped>
.stars {
  float: right
}
.icard {
  padding: 20px;
}
.vote-wrapper {
  display: flex;
  flex-direction: column;
  text-align: center;
  justify-content: center;
}
</style>

