<template>
  <div>
    <v-card class="icard">
      <v-row>
        <v-col cols="6" md="10" sm="8" class="text-title">
          {{ data.position }}
        </v-col>
        <v-col cols="6" md="2" sm="4">
          <div class="right-col">
            <star-rating
              v-model="data.rating"
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
          {{ data.company }}
        </v-col>
        <v-col cols="6" sm="4" class="center-col text-info">
          {{ formatWage(data.wage) }} / hr
        </v-col>
        <v-col cols="12" sm="4" class="right-col text-info">
          {{ data.discipline }}
        </v-col>
      </v-row>
      <v-row class="row-details">
        <v-col cols="6" sm="4" class="text-info">
          {{ data.city }}, {{ data.state }}
        </v-col>
        <v-col cols="6" sm="4" class="center-col text-info">
          {{ data.duration }}
        </v-col>
        <v-col
          cols="12"
          sm="4"
          v-show="data.hasHousing && !data.isRemote"
          class="right-col text-info"
        >
          Provide Housing
        </v-col>
        <v-col
          cols="12"
          sm="4"
          v-show="!data.hasHousing && data.isRemote"
          class="right-col text-info"
        >
          Remote
        </v-col>
        <v-col
          cols="12"
          sm="4"
          v-show="!data.hasHousing && !data.isRemote"
          class="right-col text-info"
        ></v-col>
      </v-row>
      <v-row>
        <v-col cols="12">
          <v-textarea
            v-model="data.description"
            readonly
            outlined
            hide-details
            rows="5"
            auto-grow
          >
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
    data: Object,
  },
  components: {
    StarRating,
  },
  computed: {},
  methods: {
    formatWage(wage) {
      return new Intl.NumberFormat("en-US", {
        style: "currency",
        currency: "USD",
      }).format(wage);
    },
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
  font-size: 0.9rem;
  padding: 7px 12px !important;
}
.icard {
  border: 1px solid #545454;
  padding: 20px;
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
