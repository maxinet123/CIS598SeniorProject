<template>
  <div>
    <v-row>
      <v-col cols="12" sm="12">
        <v-text-field
          dense outlined label="Position Name"
          required v-model="details.name"
          @input="$v.details.name.$touch()"
          @blur="$v.details.name.$touch()"
          :error-messages="nameErrors"/>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12" sm="12" md="6">
        <v-text-field
          dense outlined label="Discipline"
          required v-model="details.discipline"
          @input="$v.details.details.discipline.$touch()"
          @blur="$v.details.discipline.$touch()"
          :error-messages="disciplineErrors"/>
      </v-col>
      <v-col cols="12" sm="12" md="6">
        <v-text-field
          dense outlined label="Company"
          required v-model="details.company"
          @input="$v.details.company.$touch()"
          @blur="$v.details.company.$touch()"
          :error-messages="companyErrors"/>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12" sm="12" md="5">
        <v-text-field
          dense outlined
          label="City"
          required v-model="details.city"
          @input="$v.details.city.$touch()"
          @blur="$v.details.city.$touch()"
          :error-messages="cityErrors"/>
      </v-col>
      <v-col cols="12" sm="6" md="5">
        <v-autocomplete
          dense outlined label="State" 
          :filter="customFilter" :items="states"
          item-text="name" v-model="details.state"
          @input="$v.details.state.$touch()"
          @blur="$v.details.state.$touch()"
          :error-messages="stateErrors"/>
      </v-col>
      <v-col cols="12" sm="6" md="2">
        <v-text-field
          dense outlined label="Zip Code"
          required v-model="details.zipCode"
          @input="$v.details.zipCode.$touch()"
          @blur="$v.details.zipCode.$touch()"
          :error-messages="zipCodeErrors"/>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12" xs="12" sm="6">
        <v-checkbox
          dense outlined label="Provided Housing"
          v-model="details.hasHousing" :disabled="details.isRemote"/>
      </v-col>
      <v-col cols="12" xs="12" sm="6">
        <v-checkbox
          dense outlined label="Remote Internship"
          v-model="details.isRemote" :disabled="details.hasHousing"/>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12" xs="12" sm="6">
        <v-select
          dense outlined label="Duration"
          :items="range" v-model="details.duration"
          @input="$v.details.duration.$touch()"
          @blur="$v.details.duration.$touch()"
          :error-messages="durationErrors"/>
      </v-col>
      <v-col cols="12" xs="12" sm="6">
        <v-text-field
          dense outlined label="Wage / hr" 
          v-model="details.wage"
          v-mask="'$##.##'" 
          @input="$v.details.wage.$touch()"
          @blur="formatWage(details.wage)"/>
      </v-col>
    </v-row>
    <v-row>
        <v-col cols="12">
            <v-textarea v-model="details.description" outlined label="Description"
                no-resize counter="500" rows="10" required>
            </v-textarea>
        </v-col>
    </v-row>
  </div>
</template>

<script>
import moment from "moment";
import {required, numeric, maxLength} from 'vuelidate/lib/validators';
import { validationMixin } from 'vuelidate';
import States from "@/assets/states_titlecase.json";
export default {
  name: "Details",
  data: () => ({
    details: {
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
        vote: "",
    },
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
    ],
    menu1: false,
    menu2: false,
  }),
  mixins: [ validationMixin ],
  validations: {
      details: {
        name: { required },
        discipline: { required },
        company: { required },
        city: { required },
        state: { required },
        zipCode: {
            required,
            numeric,
            maxLength: maxLength(5),
        },
        duration: { required },
        description: { required },
        wage: {},
      },
  },
  computed: {
      nameErrors() {
          const errors = [];
          if(!this.$v.details.name.$dirty) {
              return errors;
          }
          if(!this.$v.details.name.required) {
              errors.push('Position name is required. Ex. IT Intern')
          }
          return errors;
      },
      disciplineErrors() {
          const errors = [];
          if(!this.$v.details.discipline.$dirty) {
              return errors;
          }
          if(!this.$v.details.discipline.required) {
              errors.push('Discipline is required. Ex.Information Technology')
          }
          return errors;
      },
      companyErrors() {
          const errors = [];
          if(!this.$v.details.company.$dirty) {
              return errors;
          }
          if(!this.$v.details.company.required) {
              errors.push('Company name is required.')
          }
          return errors;
      },
      cityErrors() {
          const errors = [];
          if(!this.$v.details.city.$dirty) {
              return errors;
          }
          if(!this.$v.details.city.required) {
              errors.push('City is required.')
          }
          return errors;
      },
      stateErrors() {
          const errors = [];
          if(!this.$v.details.state.$dirty) {
              return errors;
          }
          if(!this.$v.details.state.required) {
              errors.push('State is required.')
          }
          return errors;
      },
      zipCodeErrors() {
          const errors = [];
          if(!this.$v.details.zipCode.$dirty) {
              return errors;
          }
          if(!this.$v.details.zipCode.required) {
              errors.push('Zip code is required.')
          }
          return errors;
      },
      durationErrors() {
          const errors = [];
          if(!this.$v.details.duration.$dirty) {
              return errors;
          }
          if(!this.$v.details.duration.required) {
              errors.push('Duration is required.')
          }
          return errors;
      },
      descriptionErrors() {
          const errors = [];
          if(!this.$v.details.description.$dirty) {
              return errors;
          }
          if(!this.$v.details.description.required) {
              errors.push('Description is required.')
          }
          return errors;
      },
  },
  methods: { 
    formatWage(wage) {
        this.$v.wage.touch
        var modifyVal = wage.replace('$.', '')
        return Number(modifyVal).toFixed(2)
    },
    customFilter(item, queryText) {
      const textOne = item.name.toLowerCase();
      const textTwo = item.abbreviation.toLowerCase();
      const searchText = queryText.toLowerCase();
      return (
        textOne.indexOf(searchText) > -1 || textTwo.indexOf(searchText) > -1
      );
    },
    formatDate(date) {
      return date ? moment(date).format("MM/DD/YYYY") : "";
    },
  },
  watch: {
      details: {
          deep: true,
          handler(val) {
            this.$emit('details', val);
          }
      },
      $v: {
        immediate: true,
        deep: true,
        handler(val) {
          this.$emit('v', val)
        }
      },
  },
};
</script>

<style lang="scss" scoped>
.v-input--selection-controls {
  margin: 0px;
}
</style>
