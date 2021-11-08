<template>
  <div>
    <v-card class="icard">
      <v-row>
        <v-col cols="6" md="10" sm="8" class="text-title">
          {{ internship.name }}
        </v-col>
        <v-col cols="6" md="2" sm="4">
          <div class="right-col">
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
        <v-col cols="6" sm="4" class="text-info">
          {{internship.company}}
        </v-col>
        <v-col cols="6" sm="4" class="center-col text-info">
          {{internship.wage}} / hr
        </v-col>
        <v-col cols="12" sm="4" class="right-col text-info">
          {{internship.discipline}}
        </v-col>
      </v-row>
      <v-row class="row-details">
        <v-col cols="6" sm="4" class="text-info">
          {{internship.city}}, {{internship.state}}
        </v-col>
        <v-col cols="6" sm="4" class="center-col text-info">
          {{internship.duration}}
        </v-col>
        <v-col cols="12" sm="4" v-if="internship.hasHousing" class="right-col text-info">
          Provide Housing
        </v-col>
        <v-col cols="12" sm="4" v-else class="right-col text-info">
          Remote
        </v-col>
      </v-row>
      <v-row>
        <v-col cols="12">
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
  },
  watch: {},
};
</script>

<style lang="scss" scoped>
.text-title {
  font-size: 1.25rem;
  font-weight: bold;
}
.text-info {
  font-size: .9rem;
  padding: 7px 12px !important;
}
.icard {
  padding: 20px;
}
.divider {
  border: 1px solid grey;
}
.right-col {
  text-align: end;
  float: right;
  @media all and (max-width: 600px) {
    text-align: left;
  }
}
.center-col {
  text-align: center;
  @media all and (max-width: 600px) {
    text-align: end;
    float: right;
  }
}
</style>

