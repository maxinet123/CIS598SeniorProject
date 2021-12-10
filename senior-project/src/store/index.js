import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";

const APP_URL = process.env.VUE_APP_API;
Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    user: {},
    internships: [],
    internshipsByUserId: [],
    companies: [],
    disciplines: [],
    locations: [],
    ratings: [],
    majors: [],
  },
  getters: {
    getUser: (state) => state.user,
    getInternships: (state) => state.internships,
    getInternshipsByUserId: (state) => state.internshipsByUserId,
    getCompanies: (state) => state.companies,
    getDisciplines: (state) => state.disciplines,
    getLocations: (state) =>
      state.locations.map((x) => ({
        ...x,
        fullLocation: `${x.city}, ${x.state}`,
      })),
    getRatings: (state) => state.ratings,
    getMajors: (state) =>
      state.majors.sort((a, b) => {
        if (a.majorName < b.majorName) {
          return -1;
        }
        if (a.majorName > b.majorName) {
          return 1;
        }
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
    setInternshipsByUserId: (state, data) => {
      state.internshipsByUserId = data;
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
            reject(error);
          });
      });
    },
    fetchInternshipsByUser: ({ commit }, {id}) => {
      return new Promise((resolve, reject) => {
        axios
          .get(`${APP_URL}/Internship/GetInternshipsByUserId`, {id})
          .then((response) => {
            commit("setInternshipsByUserId", response.data.$values);
            resolve();
          })
          .catch((error) => {
            reject(error);
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
            reject(error);
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
            reject(error);
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
            reject(error);
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
            reject(error);
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
            reject(error);
          });
      });
    },
    addInternship: ({ dispatch }, { internshipHeaders }) => {
      return new Promise((resolve, reject) => {
        axios
          .post(`${APP_URL}/Internship/AddInternship`, internshipHeaders)
          .then(() => {
            dispatch("fetchInternships");
            resolve();
          })
          .catch((error) => {
            reject(error);
          });
      });
    },
    addUser: ({ commit }, { user }) => {
      return new Promise((resolve, reject) => {
        axios
          .post(`${APP_URL}/Internship/AddUser`, user)
          .then((response) => {
            console.log('getuser', response)
            commit("setUser", response.data);
            //commit("setUser", response.data.$values);
            resolve();
          })
          .catch(() => {
            reject();
          });
      });
    },
    // upVote: ({ dispatch }, { id, total }) => {
    //   return new Promise((resolve, reject) => {
    //     axios
    //       .post(`${APP_URL}/Internship/UpVote`, {
    //         id,
    //         total,
    //       })
    //       .then(() => {
    //         dispatch("fetchInternships");
    //         resolve();
    //       })
    //       .catch((error) => {
    //         console.log(error);
    //         reject();
    //       });
    //   });
    // },
    // downVote: ({ dispatch }, { id, total }) => {
    //   return new Promise((resolve, reject) => {
    //     axios
    //       .post(
    //         `${APP_URL}/Internship/DownVote`,
    //         {},
    //         {
    //           headers: {
    //             id,
    //             total,
    //           },
    //         }
    //       )
    //       .then(() => {
    //         dispatch("fetchInternships");
    //         resolve();
    //       })
    //       .catch((error) => {
    //         console.log(error);
    //         reject();
    //       });
    //   });
    // },
  },
  modules: {},
});
