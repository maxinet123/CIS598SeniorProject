<template>
  <div>
    <v-card>
      <v-row>
        <v-col cols="12" md="10">
          <v-card>
        <v-card-title>
          {{ internship.name }}
        </v-card-title>
        <v-card-subtitle>
        </v-card-subtitle>
        <v-card-actions>
        </v-card-actions>
          </v-card>
        </v-col>
        <v-col cols="12" md="2">
          <v-row>
            <v-col cols="12" md="12">
              <v-btn icon>
                <v-icon>arrow-up-bold-circle-outline</v-icon>
              </v-btn>
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="12" md="12">
              Upvote
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="12" md="12">
              <v-btn icon>
                <v-icon>arrow-down-bold-circle-outline</v-icon>
                </v-btn>
            </v-col>
          </v-row>
        </v-col>
      </v-row>
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
