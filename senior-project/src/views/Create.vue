<template>
  <v-container class="create">
    <div>
      <h1>Share your experience!</h1>
      <v-card>
        <Details @details="setDetails" @v="setV"/>
      </v-card>
      <v-row class="btn-wrapper">
        <v-col cols="12" xs="12">
          <v-btn class="submit-btn" @click="submit">
            Submit
          </v-btn>
        </v-col>
      </v-row>
    </div>
  </v-container>
</template>

<script>
import Details from "@/components/Details.vue";
export default {
  name: "Create",
  data: () => ({
    intershipData: {
      name: "",
      discipline: "",
      company: "",
      city: "",
      state: "",
      zipCode: "",
      duration: "",
      wage: "",
      hasHousing: false,
      isRemote: false,
      description: "",
    },
    v: {},
  }),
  props: {},
  components: {
    Details,
  },
  computed: {},
  methods: {
    setV(val) {
      this.v = val;
    },
    setDetails(val) {
      this.internshipData.name = val.name;
      this.internshipData.discipline = val.discipline;
      this.internshipData.company = val.company;
      this.internshipData.city = val.city;
      this.internshipData.state = val.state;
      this.internshipData.zipCode = val.zipCode;
      this.internshipData.hasHousing = val.hasHousing;
      this.internshipData.isRemote = val.isRemote;
      this.internshipData.duration = val.duration;
      this.internshipData.wage = val.wage,
      this.internshipData.description = val.description;
    },
    submit() {
      this.v.$touch();
      if(this.v.$invalid) {
        console.log('submit');
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
</style>
