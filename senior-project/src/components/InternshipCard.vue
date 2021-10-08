<template>
  <div>
    <v-card>
      {{ internship.name }}
    </v-card>
  </div>
</template>

<script>
export default {
  name: "InternshipCard",
  data: () => ({}),
  props: {
    internship: Object,
  },
  components: {},
  computed: {},
  methods: {},
  watch: {},
};
</script>

<style lang="scss" scoped>
.v-card {
  padding: 20px;
}
</style>
