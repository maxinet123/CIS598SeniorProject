<template>
  <v-container class="explore">
    <h1 class="title">Explore!</h1>
    <v-row>
      <v-col cols="8" offset-sm="2">
        <div v-for="(filter,index) in filters" :key="index">
        <v-chip class="ma-2" close @click="removeFilter(filter)">
          {{filter}}
        </v-chip>
        </div>
      </v-col>
    </v-row>
    <div v-if="getInternships.length > 0">
      <div v-for="item in filteredInternships" :key="item.id">
        <postings :item="item" />
      </div>
    </div>
    <div v-else>
      <v-row>
        <v-col cols="12" sm="12" class="center">
          <v-btn text x-large class="add-btn" @click="addPost">
            No internships shared. Click here to be the first!
          </v-btn>
        </v-col>
      </v-row>
    </div>
  </v-container>
</template>

<script>
import { mapGetters } from "vuex";
import Postings from "../components/Postings.vue"
import { EventBus } from "../event-bus";
export default {
  name: "Explore",
  data: () => ({
    filters: []
  }),
  components: {
    Postings
  },
  computed: {
    ...mapGetters(["getInternships"]),
    filteredInternships() {
      if (this.filters.length > 0) {
        console.log(this.filters)
        return this.getInternships.filter((obj) => {
          console.log(obj, this.filters.indexOf(obj.company) >= 0, this.filters.indexOf(obj.discipline) >= 0, this.filters.indexOf(obj.major) >= 0)
          return this.filters.indexOf(obj.company) >= 0 ||
          this.filters.indexOf(obj.discipline) >= 0 ||
          this.filters.indexOf(obj.major) >= 0
        }, [])

      }
      return this.getInternships
    },
  },
  methods: {
    addPost() {
      this.$router.push({ name: "Create" }).catch(() => {});
    },
    removeFilter(filter) {
      let index = this.filters.indexOf(filter)
      if (index !== -1) {
        this.filters.splice(index,1)
        EventBus.$emit('removeFilter', filter)
      }
    }
  },
  mounted() {
    EventBus.$on("filter", (val) => {
      this.filters = [...val];
    });
    EventBus.$on("clearFilter", () => {
      this.filters = [];
    });
  },
};
</script>

<style lang="scss" scoped>
.title {
  font-size: 2.5rem !important;
  text-align: center;
  margin-bottom: 45px;
}
</style>
