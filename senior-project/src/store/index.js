import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";
//import variables from "../variables.js";

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
    fetchInternships: ({ commit }) => {
      axios
        .get(`https://localhost:44386/api/Internship/GetInternships`)
        .then((response) => {
          commit("setInternships", response.data);
          //resolve();
        })
        .catch((error) => {
          console.log(error);
          //reject();
        });
    },
    AddInternship: ({ dispatch }, { internship }) => {
      axios
        .get(`https://localhost:44386/api/Internship/AddInternship`, internship)
        .then(() => {
          dispatch("fetchInternships");
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
