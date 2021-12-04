<template>
  <v-container class="explore">
    <h1 class="title">Explore!</h1>
    <v-row>
      <v-col cols="8" offset-sm="2">
        <div v-for="(filter,index) in filters" :key="index">
        <v-chip class="ma-2" close>
          {{filter}}
        </v-chip>
        </div>
      </v-col>
    </v-row>
    <postings :getInternships="getInternships" />
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
  },
  methods: {},
  mounted() {
    EventBus.$on("filter", (val) => {
      console.log('hello')
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
