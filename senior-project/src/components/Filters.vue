<template>
    <div>
        <v-card class="spacing">
            <v-card-actions class="filter-btn">
                <v-btn icon @click="close">
                    <v-icon>mdi-close</v-icon>
                </v-btn>
            </v-card-actions>
            <v-card-subtitle class="subtitles" v-show="getCompanies.length > 0">Companies:</v-card-subtitle>
            <v-card-actions v-show="getCompanies.length > 0">
                <v-combobox v-model="companies" :items="getCompanies" class="combobox"
                    chips multiple outlined item-text="companyName" hide-details>
                </v-combobox>
            </v-card-actions>
            <v-card-subtitle class="subtitles"  v-show="getDisciplines.length > 0">Disciplines: </v-card-subtitle>
            <v-card-actions  v-show="getDisciplines.length > 0">
                <v-combobox v-model="disciplines" :items="getDisciplines" class="combobox"
                    chips multiple outlined item-text="disciplineName" hide-details>
                </v-combobox>
            </v-card-actions>
            <v-card-subtitle class="subtitles" v-show="getMajors.length > 0">Majors: </v-card-subtitle>
            <v-card-actions  v-show="getMajors.length > 0">
                <v-combobox v-model="majors" :items="getMajors" class="combobox"
                    chips multiple outlined item-text="majorName" hide-details>
                </v-combobox>
            </v-card-actions>
            <v-card-subtitle class="subtitles"  v-show="getLocations.length > 0">Locations: </v-card-subtitle>
            <v-card-actions  v-show="getLocations.length > 0">
                <v-combobox v-model="locations" :items="getLocations" class="combobox"
                    chips multiple outlined item-text="fullLocation" hide-details>
                </v-combobox>
            </v-card-actions>
            <v-card-actions class="filter-btn">
                <v-btn  color="purple" @click="filterPosts">Filter</v-btn>
            </v-card-actions>
        </v-card>
    </div>
</template>

<script>
import { mapGetters } from "vuex";

export default {
    name: "Filters",
    data: () => ({
        majors: [],
        companies: [],
        disciplines: [],
        locations: [],
        arrays: [],
    }),
    components: {
    },
    computed: {
        ...mapGetters(["getCompanies" , "getDisciplines", "getLocations", "getRatings", "getMajors"]),
    },
    methods: {
        filterPosts() {
            this.majors.forEach((x) => {
                this.arrays.append(x)
            })
            // this.companies.forEach((x) => {
            //     this.arrays.append(x)
            // })
            // this.disciplines.forEach((x) => {
            //     this.arrays.append(x)
            // })
            // this.locations.forEach((x) => {
            //     this.arrays.append(x)
            // })
            this.$emit('filter', this.arrays)
        },
        close() {
            this.$emit('close', true)
        }
    }
}
</script>

<style lang="scss" scoped>
.align-right {
    float: right;
}
.combobox {
    overflow: hidden;
}
.spacing {
    min-width: 500px;
    padding: 10px;
    margin: 10px;
    border: 1px solid #545454
}
.subtitles {
    padding: 10px;
}
.filter-btn {
    display: flex;
    flex-direction: row-reverse;
}
</style>