<template>
  <v-container class="login">
    <v-card>
      <v-card-title> Login </v-card-title>
      <v-card-actions>
        <v-text-field v-model="email" outlined label="Email"></v-text-field>
      </v-card-actions>
      <v-card-actions>
        <v-btn block @click="okay" :loading="loading"> Okay </v-btn>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script>
export default {
  name: "Login",
  data: () => ({
    loading: false,
    email: "",
  }),
  props: {},
  components: {},
  computed: {},
  methods: {
    okay() {
      this.loading = true;
      setTimeout(() => {
        this.loading = false;
      }, 5000);
    },
  },
  watch: {},
};
</script>

<style lang="scss" scoped>

</style>
