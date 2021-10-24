<template>
  <v-container class="create">
    <div>
      <h1 class="title">Share your experience!</h1>
      <v-card>
        <v-card-subtitle class="sub-title"
          >***All information with be kept anonymous.***</v-card-subtitle
        >
        <Details @details="setDetails" @v="setV" />
      </v-card>
      <v-row class="btn-wrapper">
        <v-col cols="12" xs="12">
          <v-btn class="submit-btn" @click="submit"> Submit </v-btn>
        </v-col>
      </v-row>
    </div>
  </v-container>
</template>

<script>
import { mapActions } from "vuex";
import Details from "@/components/Details.vue";
export default {
  name: "Create",
  data: () => ({
    details: {
      position: "",
      duration: "",
      wage: "",
      hasHousing: false,
      isRemote: false,
      description: "",
      vote: "",
      rating: "",
    },
    company: {
      name: "",
    },
    discipline: {
      name: "",
    },
    location: {
      city: "",
      state: "",
      zipCode: "",
    },
    v: {},
  }),
  props: {},
  components: {
    Details,
  },
  computed: {},
  methods: {
    ...mapActions(["AddInternship"]),
    setV(val) {
      this.v = val;
    },
    setDetails(val) {
      if (val) {
        this.details.position = val.position;
        this.details.duration = val.duration;
        this.details.wage = val.wage;
        this.details.rating = val.rating;
        this.details.hasHousing = val.hasHousing;
        this.details.isRemote = val.isRemote;
        this.details.description = val.description;
        this.company.name = val.company;
        this.discipline.name = val.discipline;
        this.location.city = val.city;
        this.location.state = val.state;
        this.location.zipCode = val.zipCode;
      }
    },
    submit() {
      this.v.$touch();
      if (this.v.$invalid) {
        this.AddInternship({
          internship: this.details,
          company: this.company,
          discipline: this.discipline,
          location: this.location,
        });
      }
    },
  },
  watch: {},
};
</script>

<style lang="scss" scoped>
.btn-wrapper {
  margin: 20px 10px 10px;
}
.v-card {
  padding: 30px 20px 20px;
  margin: 10px;
}
.submit-btn {
  float: right;
  margin: 0px -12px;
}
.title {
  font-size: 2rem !important;
  text-align: center;
  margin-bottom: 15px;
}
.sub-title {
  text-align: center;
  margin: -20px -10px 5px;
}
</style>
