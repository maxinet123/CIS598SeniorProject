import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";

const APP_URL = process.env.VUE_APP_API
Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    user: {},
    internships: [],
    companies: [],
    disciplines: [],
    locations: [],
    ratings: [],
    majors: [],
  },
  getters: {
    getUser: (state) => state.user,
    getInternships: (state) => state.internships,
    getCompanies: (state) => state.companies,
    getDisciplines: (state) => state.disciplines,
    getLocations: (state) => state.locations.map((x) => ({
      ...x,
      fullLocation: `${x.city}, ${x.state}`
    })),
    getRatings: (state) => state.ratings,
    getMajors: (state) => state.majors.sort((a,b) => { 
      if (a.majorName < b.majorName) {
        return -1;
      }
      if (a.majorName > b.majorName) {
        return 1;
      }
      // a must be equal to b
      return 0;

    }),
  },
  mutations: {
    setUser: (state, data) => {
      state.user = data;
    },
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
    setMajors: (state, data) => {
      state.majors = data;
    },
  },
  actions: {
    fetchInternships: ({ commit }) => {
      return new Promise((resolve, reject) => {
        axios
          .get(`${APP_URL}/Internship/GetInternships`)
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
          .get(`${APP_URL}/Internship/GetCompanies`)
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
          .get(`${APP_URL}/Internship/GetDisciplines`)
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
          .get(`${APP_URL}/Internship/GetLocations`)
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
          .get(`${APP_URL}/Internship/GetRatings`)
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
          .get(`${APP_URL}/Internship/GetMajors`)
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
    addInternship: ({ dispatch }, { internshipHeaders }) => {
      return new Promise((resolve, reject) => {
        axios
          .post(
            `${APP_URL}/Internship/AddInternship`,
            internshipHeaders
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
    upVote: ({ dispatch }, { id, total }) => {
      return new Promise((resolve, reject) => {
        axios
          .post(`${APP_URL}/Internship/UpVote`, {
            id,
            total
          })
          .then(() => {
            dispatch('fetchInternships')
            resolve();
          })
          .catch((error) => {
            console.log(error);
            reject();
          });
      });
    },
    down: ({ dispatch }, { id, total }) => {
      return new Promise((resolve, reject) => {
        axios
          .post(`${APP_URL}/Internship/DownVote`, {}, {
            headers: {
              id,
              total
            }
          })
          .then(() => {
            dispatch('fetchInternships')
            resolve();
          })
          .catch((error) => {
            console.log(error);
            reject();
          });
      });
    },
    addUser: ({ commit }, { user }) => {
      return new Promise((resolve, reject) => {
        axios
          .post(`${APP_URL}/Internship/AddUser`, user)
          .then((response) => {
            commit("setUser", response.data);
            resolve();
          })
          .catch(() => {
            reject();
          });
      });
    },
  },
  modules: {},
});
