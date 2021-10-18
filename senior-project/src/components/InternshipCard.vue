<template>
  <div>
    <v-card>
      <v-row>
        <v-col cols="12" sm="10">
          <v-card>
            <v-card-title>
              {{ internship.name }}
            </v-card-title>
            <v-card-subtitle> </v-card-subtitle>
            <v-card-actions>
              <v-textarea
                v-model="internship.description"
                readonly
                outlined
                rows="5"
                auto-grow
              >
              </v-textarea>
            </v-card-actions>
          </v-card>
        </v-col>
        <v-col cols="12" sm="2">
          <v-row class="vote">
            <v-col cols="12" md="12">
              <v-btn icon>
                <v-icon>mdi-arrow-up-bold-circle-outline</v-icon>
              </v-btn>
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="12" md="12"> Upvote </v-col>
          </v-row>
          <v-row>
            <v-col cols="12" md="12">
              <v-btn icon>
                <v-icon>mdi-arrow-down-bold-circle-outline</v-icon>
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
.vote {
  display: flex;
  vertical-align: middle;
  align-content: center;
}
</style>
