<template>
  <div class="theme-wrapper">
    <v-btn-toggle v-model="userTheme">
      <v-btn @click="toggleTheme">
        Dark
        <v-icon>mdi-weather-night</v-icon>
      </v-btn>
      <v-btn @click="toggleTheme">
        Light
        <v-icon>mdi-weather-sunny</v-icon>
      </v-btn>
    </v-btn-toggle>
  </div>
</template>

<script>
export default {
  name: "ThemeButton",
  data: () => ({
    userTheme: "light-theme",
  }),

  methods: {
    toggleTheme() {
      const activeTheme = localStorage.getItem("user-theme");
      if (activeTheme === "light-theme") {
        this.setTheme("dark-theme");
      } else {
        this.setTheme("light-theme");
      }
    },

    setTheme(theme) {
      localStorage.setItem("user-theme", theme);
      this.userTheme = theme;
      document.documentElement.className = theme;
    },

    getMediaPreference() {
      const hasDarkPreference = window.matchMedia(
        "(prefers-color-scheme: dark)"
      ).matches;
      if (hasDarkPreference) {
        return "dark-theme";
      } else {
        return "light-theme";
      }
    },
  },
  mounted() {
    const initUserTheme = this.getMediaPreference();
    this.setTheme(initUserTheme);
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style lang="scss" scoped>
.theme-wrapper {
  display: flex;
  justify-content: center;
}
</style>
