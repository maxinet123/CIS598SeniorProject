<template>
  <v-container>
    <v-overlay :dark="false" class="overlay" :opacity="0.75" v-show="showFilters">
      <filters @close="close"/>
    </v-overlay>
    <div>
      <lottie
        :options="defaultOptions"
        class="explore"
        @animCreated="handleAnimation"
      />
    </div>
    <v-row>
      <v-col class="chip-wrapper" cols="8" offset-sm="2" v-show="filters.length > 0">
        <div v-for="(filter,index) in filters" :key="index">
        <v-chip class="ma-2">
          {{titleCasing(filter)}}
        </v-chip>
        </div>
      </v-col>
      <v-col class="chip-wrapper" cols="8" offset-sm="2" v-show="!(filters.length > 0)">
        <v-chip class="ma-2">
          No filters applied
        </v-chip>
      </v-col>
    </v-row>
    <div v-if="filteredInternships.length > 0">
      <div v-for="item in filteredInternships" :key="item.id">
        <postings :item="item" />
      </div>
    </div>
    <div v-else-if="!(filteredInternships.length > 0) && filters.length > 0">
      <v-row>
        <v-col cols="12" sm="12" class="center">
          <v-btn text large class="add-btn" @click="addPost">
            No internships shared with the filter(s). Click here to be the first!
          </v-btn>
        </v-col>
      </v-row>
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
import { mapGetters, mapActions } from "vuex";
import Postings from "../components/Postings.vue"
import { EventBus } from "../event-bus";
import animationData from "../assets/explore.json";
import Lottie from "vue-lottie";
import Filters from "../components/Filters.vue";
export default {
  name: "Explore",
  data: () => ({
    filters: [],
    defaultOptions: {
      animationData: animationData,
      loop: true,
      autoplay: true
    },
    showFilters: false,
  }),
  components: {
    Postings,
    Lottie,
    Filters
  },
  computed: {
    ...mapGetters(["getInternships"]),
    filteredInternships() { 
      if (this.filters.length > 0) {
        return this.getInternships.filter((obj) => this.filters.every((x) => {
            return obj.company.toLowerCase().includes(x.toLowerCase())
            || obj.discipline.toLowerCase().includes(x.toLowerCase())
            || obj.major.toLowerCase().includes(x.toLowerCase())
            || obj.fullLocation.toLowerCase().includes(x.toLowerCase())
        }), [])
      }
      return this.getInternships
    },
  },
  methods: {
    ...mapActions(["fetchInternships"]),
    addPost() {
      this.$router.push({ name: "Create" }).catch(() => {});
    },
    handleAnimation(anim) {
      this.anim = anim;
      this.anim.addEventListener('complete', () => {
        setTimeout(() => {
          this.anim.goToAndPlay(0);
        }, 5000
      );
      })
    },
    close(val) {
      this.showFilters = val;
    },
    titleCasing(str) {
      str = str.toLowerCase().split(' ');
      for (var i = 0; i < str.length; i++) {
        str[i] = str[i].charAt(0).toUpperCase() + str[i].slice(1); 
      }
      return str.join(' ');
    }
  },
  mounted() {
    this.fetchInternships()
    var index = this.filters.indexOf(x => {
      return x === this.$route.params.searched})
    if (index < 0 && this.$route.params.searched) {
      this.filters.push(this.$route.params.searched);
    }
    EventBus.$on("filter", (val) => {
      this.filters = [...val];
    });
    EventBus.$on("clearFilterChips", () => {
      this.filters.splice(0);
    });
    EventBus.$on("show", (val) => {
      this.showFilters = val
    });
  },
  created (){    
    window.addEventListener('beforeunload', () => {
      EventBus.$emit('clearFilters')
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
  @media all and (min-width: 770px) {
    margin: -160px auto !important;
  }
  @media all and (min-width: 1264px) {
    margin: -220px auto !important;
  }
}
.chip-wrapper {
  justify-content: center;
  display: flex;
  margin: 10px auto;
  padding: 12px 0px;
}
.center {
  display: flex;
  justify-content: center;
}
</style>
