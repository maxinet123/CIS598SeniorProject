<template>
<v-card class="spacing">
  <v-row class="align-right">
    <v-col cols="12">
      <v-btn icon @click="close">
        <v-icon>mdi-close</v-icon>
      </v-btn>
    </v-col>
  </v-row>
  <div v-show="getCompanies.length > 0">
    <v-card-subtitle class="subtitles">Companies:</v-card-subtitle>
    <v-card-actions>
      <v-combobox
        v-model="companies"
        :items="getCompanies"
        class="combobox"
        chips
        multiple
        outlined
        hide-details
        filled
      >
      </v-combobox>
    </v-card-actions>
  </div>
  <div v-show="getDisciplines.length > 0">
    <v-card-subtitle class="subtitles">Disciplines: </v-card-subtitle>
    <v-card-actions>
      <v-combobox
        v-model="disciplines"
        :items="getDisciplines"
        class="combobox"
        chips
        multiple
        outlined
        hide-details
        filled
      >
      </v-combobox>
    </v-card-actions>
  </div>
  <div v-show="getMajors.length > 0">
    <v-card-subtitle class="subtitles">Majors: </v-card-subtitle>
    <v-card-actions>
      <v-combobox
        v-model="majors"
        :items="getMajors"
        class="combobox"
        chips
        multiple
        outlined
        hide-details
        filled
      >
      </v-combobox>
    </v-card-actions>
  </div>
  <div v-show="getLocations.length > 0">
    <v-card-subtitle class="subtitles">Locations: </v-card-subtitle>
    <v-card-actions>
      <v-combobox
        v-model="locations"
        :items="getLocations"
        class="combobox"
        chips
        multiple
        outlined
        hide-details
        filled
      >
      </v-combobox>
    </v-card-actions>
  </div>
  <v-card-actions class="filter-btn">
    <v-btn color="#5f6aa0" dark secondary @click="clear">Clear</v-btn>
    <v-spacer />
    <v-btn color="#5f6aa0" dark @click="filterPosts">Filter</v-btn>
  </v-card-actions>
</v-card>
</template>

<script>
import { mapGetters } from "vuex";
import { EventBus } from "../event-bus";

export default {
  name: "Filters",
  data: () => ({
    majors: [],
    companies: [],
    disciplines: [],
    locations: [],
  }),
  mounted() {
    EventBus.$on("clearFilters", () => {
      this.clear();
    });
  },
  computed: {
    ...mapGetters([
      "getCompanies",
      "getDisciplines",
      "getLocations",
      "getRatings",
      "getMajors",
    ]),
    hasFilters() {
      if (
        this.majors.length > 0 ||
        this.companies.length > 0 ||
        this.disciplines.length > 0 ||
        this.locations.length > 0
      ) {
        return true;
      }
      return false;
    },
  },
  methods: {
    filterPosts() {
      const arr = [];
      if (this.majors.length > 0) {
        this.majors.forEach((x) => arr.push(x))
      }
      if (this.companies.length > 0) {
        this.companies.forEach((x) => arr.push(x))
      }
      if (this.disciplines.length > 0) {
        this.disciplines.forEach((x) => arr.push(x))
      }
      if (this.locations.length > 0) {
        this.locations.forEach((x) => arr.push(x))
      }
      let removeDupes = arr.filter((item, pos) => {
        return arr.indexOf(item) == pos;
      });
      EventBus.$emit("filter", removeDupes);
      EventBus.$emit("hasFilters", this.hasFilters);
      this.$emit("close", false);
    },
    close() {
      this.$emit("close", false);
    },
    clear() {
      this.majors.splice(0);
      this.companies.splice(0);
      this.disciplines.splice(0);
      this.locations.splice(0);
      EventBus.$emit("filter", []);
    },
  },
  watch: {
    '$route.params.searched': {
      immediate: true,
      deep: true,
      handler(val) {
        if (val) {
          var index = this.getCompanies.findIndex((x) => x.toLowerCase().includes(val.toLowerCase()))
          if (index !== -1){
            this.companies.push(this.getCompanies[index]);
          }
          index = this.getMajors.findIndex((x) => x.toLowerCase().includes(val.toLowerCase()))
          if (index !== -1){
            this.majors.push(this.getMajors[index]);
          }
          index = this.getDisciplines.findIndex((x) => x.toLowerCase().includes(val.toLowerCase()))
          if (index !== -1){
            this.disciplines.push(this.getDisciplines[index]);
          }
          index = this.getLocations.findIndex((x) => x.toLowerCase().includes(val.toLowerCase()))
          if (index !== -1){
            this.locations.push(this.getLocations[index]);
          }
        }
      }
    }
  }
};
</script>

<style lang="scss" scoped>
.align-right {
  float: right;
}
.combobox {
  overflow: hidden;
}
.spacing {
  min-width: 500px;
  padding: 10px;
  margin: 10px;
  border: 1px solid #545454;
}
.subtitles {
  padding: 10px;
}
.filter-btn {
  display: flex;
}
</style>
