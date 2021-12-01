<template>
    <div>
        <v-card class="spacing">
            <v-row class="align-right">
                <v-col cols="12">
                    <v-btn icon @click="close">
                        <v-icon>mdi-close</v-icon>
                    </v-btn>
                </v-col>
            </v-row>
            <div v-show="getCompanies.length > 0">
                <v-card-subtitle class="subtitles">Companies:</v-card-subtitle>
                <v-card-actions >
                    <v-combobox v-model="companies" :items="getCompanies" class="combobox"
                        chips multiple outlined item-text="companyName" hide-details filled>
                    </v-combobox>
                </v-card-actions>
            </div>
            <div v-show="getDisciplines.length > 0" >
                <v-card-subtitle class="subtitles">Disciplines: </v-card-subtitle>
                <v-card-actions>
                    <v-combobox v-model="disciplines" :items="getDisciplines" class="combobox"
                        chips multiple outlined item-text="disciplineName" hide-details filled>
                    </v-combobox>
                </v-card-actions>
            </div>
            <div v-show="getMajors.length > 0" >
                <v-card-subtitle class="subtitles">Majors: </v-card-subtitle>
                <v-card-actions>
                    <v-combobox v-model="majors" :items="getMajors" class="combobox"
                        chips multiple outlined item-text="majorName" hide-details filled>
                    </v-combobox>
                </v-card-actions>
            </div>
            <div v-show="getLocations.length > 0">
            <v-card-subtitle class="subtitles">Locations: </v-card-subtitle>
            <v-card-actions>
                <v-combobox v-model="locations" :items="getLocations" class="combobox"
                    chips multiple outlined item-text="fullLocation" hide-details filled>
                </v-combobox>
            </v-card-actions>
            </div>
            <v-card-actions class="filter-btn">
                <v-btn color="purple" secondary @click="clear">Clear</v-btn>
                <v-spacer />
                <v-btn color="purple" primary @click="filterPosts">Filter</v-btn>
            </v-card-actions>
        </v-card>
    </div>
</template>

<script>
import { mapGetters } from "vuex";
import { EventBus } from '../event-bus';

export default {
    name: "Filters",
    data: () => ({
        majors: [],
        companies: [],
        disciplines: [],
        locations: [],
    }),
    mounted() {
        EventBus.$on('clearFilters', () => {
            this.clear()
        })
    },
    computed: {
        ...mapGetters(["getCompanies" , "getDisciplines", "getLocations", "getRatings", "getMajors"]),
        hasFilters() {
            if (this.majors.length > 0 || this.companies.length > 0 || this.disciplines.length > 0 || this.locations.length > 0) {
                return true
            }
            return false
        }
    },
    methods: {
        filterPosts() {
            let arrays = []
            if (this.majors.length > 0) {
                arrays.concat(this.majors)
            }
            if (this.companies.length > 0) {
                arrays.concat(this.companies)
            }
            if (this.disciplines.length > 0) {
                arrays.concat(this.disciplines)
            }
            if (this.locations.length > 0) {
                arrays.concat(this.locations)
            }
            let removeDupes = arrays.filter((item, pos) => {
                return arrays.indexOf(item) == pos;
            })
            EventBus.$emit('filter', removeDupes)
            this.$emit('hasFilters', this.hasFilters)
            this.$emit('close', false)
        },
        close() {
            this.$emit('close', false)
        },
        clear() {
            this.$emit('hasFilters', false)
            this.majors = []
            this.companies = []
            this.disciplines = []
            this.locations = []
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
}
</style>