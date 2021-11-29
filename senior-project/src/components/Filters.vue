<template>
    <div>
        <v-row>
            <v-col cols="12" sm="4" v-show="getCompanies.length > 0">
                <v-combobox v-model="companies" :items="getCompanies" class="combobox"
                    chips multiple outlined persistent-placeholder
                    placeholder="Companies" item-text="companyName" hide-details>
                </v-combobox>
            </v-col>
            <v-col cols="12" sm="4" v-show="getDisciplines.length > 0">
                <v-combobox v-model="disciplines" :items="getDisciplines" class="combobox"
                    chips multiple outlined persistent-placeholder
                    placeholder="Disciplines" item-text="disciplineName" hide-details>
                </v-combobox>
            </v-col>
            <v-col cols="12" sm="4" v-show="getMajors.length > 0">
                <v-combobox v-model="majors" :items="getMajors" class="combobox"
                    chips multiple outlined persistent-placeholder
                    placeholder="Majors" item-text="majorName" hide-details>
                </v-combobox>
            </v-col>
            <v-col cols="12" sm="4" v-show="getLocations.length > 0">
                <v-combobox v-model="locations" :items="getLocations" class="combobox"
                    chips multiple outlined persistent-placeholder
                    placeholder="Locations" item-text="fullLocation" hide-details>
                </v-combobox>
            </v-col>
        </v-row>
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
        locations: []
    }),
    components: {
    },
    computed: {
        ...mapGetters(["getCompanies" , "getDisciplines", "getLocations", "getRatings", "getMajors"]),
    },
    methods: {
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
</style>