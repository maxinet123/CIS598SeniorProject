<template>
    <div>
        <v-row>
            <v-col cols="12">
                <v-combobox
                v-model="majors"
                :items="getMajors"
                label="Choose a company"
                multiple
                chips
                >
                <template v-slot:selection="data">
                    <v-chip
                    :key="JSON.stringify(data.item)"
                    v-bind="data.attrs"
                    :input-value="data.selected"
                    :disabled="data.disabled"
                    @click:close="data.parent.selectItem(data.item)"
                    >
                    <v-avatar
                        class="accent white--text"
                        left
                        v-text="data.item.slice(0, 1).toUpperCase()"
                    ></v-avatar>
                    {{ data.item }}
                    </v-chip>
                </template>
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
        majors: []
    }),
    computed: {
        ...mapGetters(["getCompanies" , "getDisciplines", "getLocations", "getRatings", "getMajors"]),
    }
}
</script>

<style lang="scss" scoped>

</style>