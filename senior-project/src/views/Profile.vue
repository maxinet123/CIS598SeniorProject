<template>
  <div v-if="getInternshipsByUserId.length > 0">
    <div v-for="item in getInternshipsByUserId" :key="item.id">
      <postings :item="item" />
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions} from "vuex";
export default {
  name: "Profile",
  computed: {
    ...mapGetters(["getInternshipsByUserId", "getUser"]),
  },
  methods: {
    ...mapActions(["fetchInternshipsByUserId"])
  },
  mounted() {
    this.fetchInternshipsByUserId({id: this.getUser.id})
  },
};
</script>

<style lang="scss" scoped></style>
