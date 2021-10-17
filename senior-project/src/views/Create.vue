<template>
  <v-container class="create">
    <div>
      <h1>Spill the deets</h1>
      <v-card>
        <v-row>
          <v-col cols="12" md="12">
            <v-text-field outlined label="Field" required></v-text-field>
          </v-col>
        </v-row>
        <v-row>
          <v-col cols="12" md="12">
            <v-text-field outlined label="Company" required></v-text-field>
          </v-col>
        </v-row>
        <v-row>
          <v-col cols="12" md="12">
            <v-text-field outlined label="Location" required></v-text-field>
          </v-col>
        </v-row>
        <v-row>
          <v-col cols="12" md="12">
            <v-select outlined label="Duration" :items="range"></v-select>
          </v-col>
        </v-row>
      </v-card>
      <v-row>
        <v-cols cols="12" sm="6">
          <v-btn>
            Back
          </v-btn>
        </v-cols>
        <v-cols cols="12" sm="6">
          <v-btn>
            Next
          </v-btn>
        </v-cols>
      </v-row>
    </div>
  </v-container>
</template>

<script>
export default {
  name: "Create",
  data: () => ({
    range: [
      "1 week","2 weeks","3 weeks","4 weeks","5 weeks","6 week","7 weeks","8 weeks","9 weeks","10 weeks","11 weeks","12 weeks"
    ]
  }),
  props: {},
  components: {},
  computed: {},
  methods: {},
  watch: {},
};
</script>

<style lang="scss" scoped>
.v-card {
  padding: 20px;
  margin: 10px;
}
</style>
