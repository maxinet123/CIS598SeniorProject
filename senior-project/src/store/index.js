import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    internships: [],
  },
  getters: {
    getInternships: (state) => state.internships,
  },
  mutations: {
    setInternships: (state, data) => {
      state.internships = data;
    },
  },
  actions: {
    fetchInternships() {
        axios
          .get("http://localhost:44386/IntershipApp/GetInternships")
          .then((response) => {
            console.log(response.data);
            //resolve();
          })
          .catch((error) => {
            console.log(error);
            //reject();
          });
    },
  },
  modules: {},
});
