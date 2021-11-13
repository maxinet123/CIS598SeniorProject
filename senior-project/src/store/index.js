import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";
//import variables from "../variables.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    internships: [],
    companies: [],
    disciplines: [],
    locations: [],
    ratings: [],
  },
  getters: {
    getInternships: (state) => state.internships,
    getCompanies: (state) => state.companies,
    getDisciplines: (state) => state.disciplines,
    getLocations: (state) => state.locatins,
    getRatings: (state) => state.ratings,
  },
  mutations: {
    setInternships: (state, data) => {
      state.internships = data;
    },
    setCompanies: (state, data) => {
      state.companies = data;
    },
    setDisciplines: (state, data) => {
      state.disciplines = data;
    },
    setLocations: (state, data) => {
      state.locations = data;
    },
    setRatings: (state, data) => {
      state.ratings = data;
    },
  },
  actions: {
    fetchInternships: ({ commit }) => {
      return new Promise((resolve, reject) => {
        axios
          .get(`https://localhost:44386/api/Internship/GetInternships`)
          .then((response) => {
            commit("setInternships", response.data.$values);
            resolve();
          })
          .catch((error) => {
            console.log(error);
            reject();
          });
      });
    },
    fetchCompanies: ({ commit }) => {
      return new Promise((resolve, reject) => {
        axios
          .get(`https://localhost:44386/api/Internship/GetCompanies`)
          .then((response) => {
            commit("setCompanies", response.data.$values);
            resolve();
          })
          .catch((error) => {
            console.log(error);
            reject();
          });
      });
    },
    fetchDisciplines: ({ commit }) => {
      return new Promise((resolve, reject) => {
        axios
          .get(`https://localhost:44386/api/Internship/GetDisciplines`)
          .then((response) => {
            commit("setDisciplines", response.data.$values);
            resolve();
          })
          .catch((error) => {
            console.log(error);
            reject();
          });
      });
    },
    fetchLocations: ({ commit }) => {
      return new Promise((resolve, reject) => {
        axios
          .get(`https://localhost:44386/api/Internship/GetLocations`)
          .then((response) => {
            commit("setLocations", response.data.$values);
            resolve();
          })
          .catch((error) => {
            console.log(error);
            reject();
          });
      });
    },
    fetchRatings: ({ commit }) => {
      return new Promise((resolve, reject) => {
        axios
          .get(`https://localhost:44386/api/Internship/GetRatings`)
          .then((response) => {
            commit("setRatings", response.data.$values);
            resolve();
          })
          .catch((error) => {
            console.log(error);
            reject();
          });
      });
    },
    fetchMajors: ({ commit }) => {
      return new Promise((resolve, reject) => {
        axios
          .get(`https://localhost:44386/api/Internship/GetMajors`)
          .then((response) => {
            commit("setMajors", response.data.$values);
            resolve();
          })
          .catch((error) => {
            console.log(error);
            reject();
          });
      });
    },
    addInternship: ({ dispatch }, { internship }) => {
      return new Promise((resolve, reject) => {
        axios
          .get(
            `https://localhost:44386/api/Internship/AddInternship`,
            internship
          )
          .then(() => {
            dispatch("fetchInternships");
            resolve();
          })
          .catch((error) => {
            console.log(error);
            reject();
          });
      });
    },
    updateVote: ({ commit, getters }, { internship }) => {
      return new Promise((resolve, reject) => {
        axios
          .post(`https://localhost:44386/api/Internship/UpdateVote`, internship)
          .then((response) => {
            console.log(response)
            var internships = getters.getInternships;
            // var index = internships.indexOf((x) => x.id === internship.id)
            // if (index !== -1) {
            //   internships[index] = response.data
               commit('setInternships', internships)
            // }
            resolve();
          })
          .catch((error) => {
            console.log(error);
            reject();
          });
      });
    },
  },
  modules: {},
});
