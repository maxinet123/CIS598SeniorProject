<template>
  <v-container class="create">
    <div>
      <h1>Spill the deets</h1>
      <v-card>
        <Details/>
      </v-card>
      <v-card>
        <Description/>
      </v-card>
      <v-row class="btn-wrapper">
        <v-col cols="12" sm="6">
          <v-btn>
            Back
          </v-btn>
        </v-col>
        <v-col cols="12" sm="6">
          <v-btn>
            Next
          </v-btn>
        </v-col>
      </v-row>
    </div>
  </v-container>
</template>

<script>
import Details from '@/components/Details.vue';
import Description from '@/components/Description.vue';
export default {
  name: "Create",
  data: () => ({
  }),
  props: {},
  components: {
    Details,
    Description,
  },
  computed: {},
  methods: {},
  watch: {},
};
</script>

<style lang="scss" scoped>
.btn-wrapper {
  margin: 20px;
}
.v-card {
  padding: 20px;
  margin: 10px;
}
</style>
