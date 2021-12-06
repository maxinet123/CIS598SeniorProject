<template>
  <v-container>
    <div>
      <lottie
        :options="defaultOptions"
        class="explore"
        @animCreated="handleAnimation"
      />
    </div>
    <v-row>
      <v-col class="chip-wrapper" cols="8" offset-sm="2">
        <div v-for="(filter,index) in filters" :key="index">
        <v-chip class="ma-2" close @click:close="removeFilter(filter)">
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
import animationData from "../assets/explore.json";
import Lottie from "vue-lottie";
export default {
  name: "Explore",
  data: () => ({
    filters: [],
    defaultOptions: {
      animationData: animationData,
      loop: true,
      autoplay: true
    },
  }),
  components: {
    Postings,
    Lottie,
  },
  computed: {
    ...mapGetters(["getInternships"]),
    filteredInternships() { 
      if (this.filters.length > 0) {
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
      console.log(filter)
      let index = this.filters.indexOf(filter)
      if (index !== -1) {
        this.filters.splice(index,1)
        EventBus.$emit('removeFilter', filter)
      }
    },
    handleAnimation(anim) {
      this.anim = anim;
    },
  },
  mounted() {
    EventBus.$on("filter", (val) => {
      this.filters = [...val];
    });
    EventBus.$on("searched", (val) => {
      console.log('before push', val)
      var index = this.filters.indexOf(x => x === val)
      if (index < 0 ){
        this.filters.push(val);
      }
      console.log('after push', this.filters)
    });
    EventBus.$on("clearFilter", () => {
      this.filters = [];
    });
  },
  created (){    
    window.addEventListener('beforeunload', () => {
      this.filters = []
      return null
    })
  },
  watch: {
    filters: {
      immediate: true,
      deep: true,
      handler(val) {
        if (val.length > 0) {
          EventBus.$emit("hasFilters", true)
        } else {
          EventBus.$emit("hasFilters", false)
        }

      }
    }
  }
};
</script>

<style lang="scss" scoped>
.explore {
  margin: -130px auto !important;
  width: 50% !important;
}
.chip-wrapper {
  display: flex;
  margin: 10px auto;
  padding: 12px 0px;
}
</style>
