<template>
  <div>
    <v-row>
      <v-col cols="12" sm="6">
        <v-text-field
          :hide-details="positionErrors.length <= 0"
          dense
          outlined
          label="Position Name"
          required
          v-model="details.position"
          @input="$v.details.position.$touch()"
          @blur="$v.details.position.$touch()"
          :error-messages="positionErrors"
        />
      </v-col>
      <v-col cols="12" sm="6">
        <v-autocomplete
          :hide-details="majorErrors.length <= 0"
          dense
          outlined
          label="Major"
          :filter="customMajorFilter"
          :items="getMajors"
          item-text="majorName"
          v-model="details.major"
          @input="$v.details.major.$touch()"
          @blur="$v.details.major.$touch()"
          :error-messages="majorErrors"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12" sm="6">
        <v-text-field
          :hide-details="disciplineErrors.length <= 0"
          dense
          outlined
          label="Discipline"
          required
          v-model="details.discipline"
          @input="$v.details.discipline.$touch()"
          @blur="$v.details.discipline.$touch()"
          :error-messages="disciplineErrors"
        />
      </v-col>
      <v-col cols="12" sm="6">
        <v-text-field
          :hide-details="companyErrors.length <= 0"
          dense
          outlined
          label="Company"
          required
          v-model="details.company"
          @input="$v.details.company.$touch()"
          @blur="$v.details.company.$touch()"
          :error-messages="companyErrors"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12" sm="5">
        <v-text-field
          :hide-details="cityErrors.length <= 0"
          dense
          outlined
          label="City"
          required
          v-model="details.city"
          @input="$v.details.city.$touch()"
          @blur="$v.details.city.$touch()"
          :error-messages="cityErrors"
        />
      </v-col>
      <v-col cols="12" sm="3">
        <v-autocomplete
          :hide-details="stateErrors.length <= 0"
          dense
          outlined
          label="State"
          :filter="customStateFilter"
          :items="states"
          item-text="name"
          v-model="details.state"
          @input="$v.details.state.$touch()"
          @blur="$v.details.state.$touch()"
          :error-messages="stateErrors"
        />
      </v-col>
      <v-col cols="12" sm="4">
        <v-text-field
          :hide-details="zipCodeErrors.length <= 0"
          dense
          outlined
          label="Zip Code"
          required
          v-model="details.zipCode"
          @input="$v.details.zipCode.$touch()"
          @blur="$v.details.zipCode.$touch()"
          :error-messages="zipCodeErrors"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12" xs="12" sm="6">
        <v-checkbox
          hide-details
          dense
          outlined
          label="Provided Housing"
          v-model="details.hasHousing"
          :disabled="details.isRemote"
        />
      </v-col>
      <v-col cols="12" xs="12" sm="6">
        <v-checkbox
          hide-details
          dense
          outlined
          label="Remote Internship"
          v-model="details.isRemote"
          :disabled="details.hasHousing"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12" xs="12" sm="6">
        <v-select
          :hide-details="durationErrors.length <= 0"
          dense
          outlined
          label="Duration"
          :items="range"
          v-model="details.duration"
          @input="$v.details.duration.$touch()"
          @blur="$v.details.duration.$touch()"
          :error-messages="durationErrors"
        />
      </v-col>
      <v-col cols="12" xs="12" sm="6">
        <v-text-field
          :hide-details="wageErrors.length <= 0"
          dense
          outlined
          label="Wage / hr"
          v-model="details.wage"
          @input="$v.details.wage.$touch()"
          @blur="formatWage(details.wage)"
          :error-messages="wageErrors"
        />
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12">
        <v-textarea
          v-model="details.description"
          outlined
          label="Description"
          no-resize
          counter="500"
          rows="10"
          required
          hide-details
          @input="$v.details.description.$touch()"
          @blur="$v.details.description.$touch()"
        >
        </v-textarea>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12" xs="12">
        <div class="star-wrapper">
          <div class="star-text">{{ currentRating }}</div>
          <div @mouseleave="showCurrentRating(0)" class="stars">
            <star-rating
              v-model="details.number"
              :show-rating="false"
              @current-rating="showCurrentRating"
              :inline="true"
              :star-size="20"
              @rating-selected="setCurrentSelectedRating"
            ></star-rating>
          </div>
        </div>
      </v-col>
    </v-row>
  </div>
</template>

<script>
import StarRating from "vue-star-rating";
import { required, numeric, maxLength } from "vuelidate/lib/validators";
import { validationMixin } from "vuelidate";
import States from "@/assets/states_titlecase.json";
import { mapGetters } from "vuex";

export default {
  name: "Details",
  data: () => ({
    details: {
      position: "",
      discipline: "",
      company: "",
      major: "",
      city: "",
      state: "",
      zipCode: "",
      duration: "",
      wage: "",
      hasHousing: false,
      isRemote: false,
      description: "",
      //vote: "",
      number: 0,
    },
    currentRating: "No Rating",
    states: States,
    range: [
      "1 week",
      "2 weeks",
      "3 weeks",
      "4 weeks",
      "5 weeks",
      "6 week",
      "7 weeks",
      "8 weeks",
      "9 weeks",
      "10 weeks",
      "11 weeks",
      "12 weeks",
      "13+ weeks",
    ],
  }),
  components: {
    StarRating,
  },
  mixins: [validationMixin],
  validations: {
    details: {
      position: { required },
      discipline: { required },
      major: { required },
      company: { required },
      city: { required },
      state: { required },
      wage: {
        isNumber(value) {
          var modifiedVal = Number(value.replace(/\$|,/g, ""));
          return !isNaN(modifiedVal);
        },
      },
      zipCode: {
        required,
        numeric,
        maxLength: maxLength(5),
      },
      duration: { required },
      description: { required },
    },
  },
  computed: {
    ...mapGetters(["getMajors"]),
    positionErrors() {
      const errors = [];
      if (!this.$v.details.position.$dirty) {
        return errors;
      }
      if (!this.$v.details.position.required) {
        errors.push("Position title is required. Ex. IT Intern");
      }
      return errors;
    },
    disciplineErrors() {
      const errors = [];
      if (!this.$v.details.discipline.$dirty) {
        return errors;
      }
      if (!this.$v.details.discipline.required) {
        errors.push("Discipline is required. Ex. Information Technology");
      }
      return errors;
    },
    companyErrors() {
      const errors = [];
      if (!this.$v.details.company.$dirty) {
        return errors;
      }
      if (!this.$v.details.company.required) {
        errors.push("Company name is required.");
      }
      return errors;
    },
    cityErrors() {
      const errors = [];
      if (!this.$v.details.city.$dirty) {
        return errors;
      }
      if (!this.$v.details.city.required) {
        errors.push("City is required.");
      }
      return errors;
    },
    stateErrors() {
      const errors = [];
      if (!this.$v.details.state.$dirty) {
        return errors;
      }
      if (!this.$v.details.state.required) {
        errors.push("State is required.");
      }
      return errors;
    },
    zipCodeErrors() {
      const errors = [];
      if (!this.$v.details.zipCode.$dirty) {
        return errors;
      }
      if (!this.$v.details.zipCode.required) {
        errors.push("Zip code is required.");
      }
      return errors;
    },
    durationErrors() {
      const errors = [];
      if (!this.$v.details.duration.$dirty) {
        return errors;
      }
      if (!this.$v.details.duration.required) {
        errors.push("Duration is required.");
      }
      return errors;
    },
    descriptionErrors() {
      const errors = [];
      if (!this.$v.details.description.$dirty) {
        return errors;
      }
      if (!this.$v.details.description.required) {
        errors.push("Description is required.");
      }
      return errors;
    },
    majorErrors() {
      const errors = [];
      if (!this.$v.details.major.$dirty) {
        return errors;
      }
      if (!this.$v.details.major.required) {
        errors.push("Major is required.");
      }
      return errors;
    },
    wageErrors() {
      const errors = [];
      if (!this.$v.details.wage.$dirty) {
        return errors;
      }
      if (!this.$v.details.wage.isNumber) {
        errors.push("Wage must be a number.");
      }
      return errors;
    },
  },
  methods: {
    showCurrentRating(number) {
      this.currentRating =
        number === 0
          ? this.currentSelectedRating
          : number !== 1
          ? number + " stars"
          : number + " star";
    },
    formatWage(wage) {
      this.$v.details.wage.$touch();
      let newValue = parseFloat(wage.replace(/[^\d.]/g, ""));
      if (isNaN(newValue)) {
        this.details.wage = "$0.00";
      } else {
        this.details.wage = new Intl.NumberFormat("en-US", {
          style: "currency",
          currency: "USD",
        }).format(wage);
      }
    },
    customStateFilter(item, queryText) {
      const textOne = item.name.toLowerCase();
      const textTwo = item.abbreviation.toLowerCase();
      const searchText = queryText.toLowerCase();
      return (
        textOne.indexOf(searchText) > -1 || textTwo.indexOf(searchText) > -1
      );
    },
    customMajorFilter(item, queryText) {
      const textOne = item.majorName.toLowerCase();
      const searchText = queryText.toLowerCase();
      return textOne.indexOf(searchText) > -1;
    },
    setCurrentSelectedRating(number) {
      this.currentSelectedRating =
        number !== 1 ? number + " stars" : number + " star";
    },
  },
  watch: {
    details: {
      deep: true,
      handler(val) {
        this.$emit("details", val);
      },
    },
    $v: {
      immediate: true,
      deep: true,
      handler(val) {
        this.$emit("v", val);
      },
    },
  },
};
</script>

<style lang="scss" scoped>
.star-wrapper {
  display: block;
  float: right;
}
.stars {
  display: inline-block;
}
.star-text {
  display: inline-block;
  margin: 0px 10px 0px 0px;
}
.v-input--selection-controls {
  margin: 0px;
}
</style>
