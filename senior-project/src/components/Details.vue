<template>
<div>
    <v-row>
        <v-col cols="12" sm="12" md="6">
            <v-text-field hide-details outlined label="Field" required  v-model="field"></v-text-field>
        </v-col>
        <v-col cols="12" sm="12" md="6">
            <v-text-field hide-details outlined label="Company" required  v-model="company"></v-text-field>
        </v-col>
    </v-row>
    <v-row>
        <v-col cols="12" sm ="12" md="5">
            <v-text-field hide-details outlined label="City" required  v-model="city"></v-text-field>
        </v-col>
        <v-col cols="12" sm="6" md="5">
            <v-autocomplete hide-details outlined :filter="customFilter"
                label="State" :items="states" item-text="name" v-model="state"></v-autocomplete>
        </v-col>
        <v-col cols="12" sm="6" md="2">
            <v-text-field hide-details outlined label="Zip Code" required  v-model="zipCode"></v-text-field>
        </v-col>
    </v-row>
    <v-row>
        <v-col cols="12" xs="12" sm="6">
            <v-select hide-details outlined label="Duration" :items="range" v-model="duration"></v-select>
        </v-col>
        <v-col cols="12" xs="12" sm="6"> 
            <v-text-field hide-details outlined label="Wage / hr" v-model="wage"></v-text-field>
        </v-col>
    </v-row>
    <v-row>
        <v-col cols="12" xs="12" sm="6">
        <v-menu
          v-model="menu1"
          :close-on-content-click="false"
          max-width="290">
            <template v-slot:activator="{ on, attrs }">
                <v-text-field hide-details outlined 
                :value="formatDate(startDate)"
                label="Start Date"
                readonly
                v-bind="attrs"
                v-on="on"
                @click:clear="startDate = null"></v-text-field>
            </template>
            <v-date-picker no-title @input="menu1 = false" v-model="startDate"></v-date-picker>
        </v-menu>
        </v-col>
        <v-col cols="12" xs="12" sm="6">  
            <v-menu
            v-model="menu1"
            :close-on-content-click="false"
            max-width="290">
                <template v-slot:activator="{ on, attrs }">
                    <v-text-field hide-details outlined 
                    :value="formatDate(endDate)"
                    label="End Date"
                    readonly
                    v-bind="attrs"
                    v-on="on"
                    @click:clear="endDate = null"></v-text-field>
                </template>
                <v-date-picker no-title @input="menu2 = false" v-model="endDate"></v-date-picker>
            </v-menu>
        </v-col>
    </v-row>
</div>
</template>

<script>
import moment from 'moment';
  import { format, parseISO } from 'date-fns';
import States from '@/assets/states_titlecase.json';
export default {
  name: "Details",
    data: () => ({
        field: "",
        company: "",
        city: "",
        state: "",
        zipCode: "",
        duration: "",
        wage: "",
        startDate: format(parseISO(new Date().toISOString()), 'yyyy-MM-dd'),
        endDate: format(parseISO(new Date().toISOString()), 'yyyy-MM-dd'),
        states: States,
        range: [
        "1 week","2 weeks","3 weeks","4 weeks","5 weeks","6 week","7 weeks","8 weeks","9 weeks","10 weeks","11 weeks","12 weeks"
        ],
        menu1: false,
        menu2: false,
    }),
    computed: {
    },
    methods: {
      customFilter(item, queryText) {
        const textOne = item.name.toLowerCase()
        const textTwo = item.abbreviation.toLowerCase()
        const searchText = queryText.toLowerCase()
        return textOne.indexOf(searchText) > -1 || textTwo.indexOf(searchText) > -1
      },
      formatDate (date) {
        return date ? moment(date).format('MM/DD/YYYY') : ''
      },
    },
}
</script>

<style lang="scss" scoped>

</style>