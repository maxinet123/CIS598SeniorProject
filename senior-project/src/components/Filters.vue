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
        item-text="companyName"
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
        item-text="disciplineName"
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
        item-text="majorName"
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
        item-text="fullLocation"
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
    EventBus.$on("remove", (val) => {
      if (this.majors.indexOf((x) => x.majorName === val) >= 0) {
        this.majors.splice(this.majors.indexOf((x) => x.majorName === val),1)
      }
      else if (this.companies.indexOf((x) => x.companyName === val) >= 0) {
        this.companies.splice(this.companies.indexOf((x) => x.companyName === val),1)
      }
      else if (this.disciplines.indexOf((x) => x.disciplineName === val) >= 0) {
        this.disciplines.splice(this.disciplines.indexOf((x) => x.disciplineName === val),1)
      }
      else if (this.locations.indexOf((x) => x.locations === val) >= 0) {
        this.locations.splice(this.locations.indexOf((x) => x.fullLocation === val),1)
      }
    });
    if (this.$route.params.searched) {
      if (this.majors.indexOf(x => x.majorName === this.$route.params.searched) < 0 ){
        this.majors.push(this.$route.params.searched);
      }
      if (this.companies.indexOf(x => x.companyName === this.$route.params.searched) < 0 ){
        this.companies.push(this.$route.params.searched);
      }
      if (this.disciplines.indexOf(x => x.disciplineName === this.$route.params.searched) < 0 ){
        this.disciplines.push(this.$route.params.searched);
      }
      if (this.locations.indexOf(x => x === this.$route.params.searched) < 0 ){
        this.locations.push(this.$route.params.searched);
      }
    }
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
        this.majors.forEach((x) => arr.push(x.majorName))
      }
      if (this.companies.length > 0) {
        this.companies.forEach((x) => arr.push(x.companyName))
      }
      if (this.disciplines.length > 0) {
        this.disciplines.forEach((x) => arr.push(x.disciplineName))
      }
      if (this.locations.length > 0) {
        this.locations.forEach((x) => arr.push(x.fullLocation))
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
