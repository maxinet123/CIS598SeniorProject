<template>
  <v-container class="create">
    <div>
      <h1 class="title">Share your experience!</h1>
      <v-card class="card-shadow">
        <v-card-subtitle class="sub-title"
          >***All information will be kept anonymous.***</v-card-subtitle
        >
        <Details @details="setDetails" @v="setV" />
      </v-card>
      <v-row class="btn-wrapper">
        <v-col cols="12" xs="12">
          <v-btn class="submit-btn" @click="submit" :loading="loading">
            Submit
          </v-btn>
        </v-col>
      </v-row>
    </div>
  </v-container>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
import Details from "@/components/Details.vue";
export default {
  name: "Create",
  data: () => ({
    loading: false,
    data: {
      internship: {
        position: "",
        duration: "",
        wage: "",
        major: "",
        hasHousing: false,
        isRemote: false,
        description: "",
      },
      company: {
        companyName: "",
      },
      discipline: {
        disciplineName: "",
      },
      location: {
        city: "",
        state: "",
        zipCode: "",
      },
      rating: {
        stars: "0 stars",
        number: 0,
      },
      // vote: {
      //   total: 0,
      // },
      user: {
        userName: "",
        email: "",
      },
    },
    v: {},
  }),
  props: {},
  components: {
    Details,
  },
  computed: {
    ...mapGetters(["getUser"]),
  },
  methods: {
    ...mapActions(["addInternship"]),
    setV(val) {
      this.v = val;
    },
    setDetails(val) {
      if (val) {
        this.data = {
          internship: {
            position: val.position,
            duration: val.duration,
            wage: Number(val.wage.replace(/\$|,/g, "")),
            hasHousing: val.hasHousing,
            isRemote: val.isRemote,
            description: val.description,
          },
          company: {
            companyName: val.company,
          },
          discipline: {
            disciplineName: val.discipline,
          },
          location: {
            city: val.city,
            state: val.state,
            zipCode: val.zipCode,
            fullLocation: `${val.city}, ${val.state}`,
          },
          major: {
            majorName: val.major,
          },
          rating: {
            stars:
              val.number === 1 ? val.number + " star" : val.number + " stars",
            number: val.number,
          },
          // vote: {
          //   total: 0,
          // },
        };
      }
    },
    submit() {
      this.loading = true;
      this.v.$touch();
      if (!this.v.$invalid) {
        this.data.user = { ...this.getUser }
        this.addInternship({ internshipHeaders: this.data }).finally(() => {
          //add modal?
          this.loading = false;
          this.$router.push({ name: "Explore" });
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
  font-size: 2.5rem !important;
  text-align: center;
  margin-bottom: 25px;
}
.sub-title {
  text-align: center;
  margin: -20px -10px 5px;
}
.card-shadow {
  box-shadow: 0px 6px 6px -3px rgb(0 0 0 / 20%), 0px 10px 14px 1px rgb(0 0 0 / 14%), 0px 4px 18px 3px rgb(0 0 0 / 12%) !important;
}
</style>
