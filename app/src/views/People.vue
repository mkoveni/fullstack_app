<template>
  <v-container fluid>
    <template v-if="loading">
      <v-row class="fill-height" justify="center">
        <v-col justify="center" lg="1">
          <v-progress-circular
            indeterminate
            color="primary"
          ></v-progress-circular>
        </v-col>
      </v-row>
    </template>

    <template v-else>
      <v-row>
        <v-col>
          <h2>Star Wars Characters</h2>
        </v-col>
      </v-row>

      <v-row>
        <v-col v-for="person in people" :key="person.name" lg="3" sm="2">
          <person :person="person" />
        </v-col>
      </v-row>
    </template>
  </v-container>
</template>

<script>
import Person from "../components/Person";
import Bus from "../Bus";
export default {
  components: { Person },
  data: () => ({
    loading: false,
    people: [],
  }),
  methods: {
    async getPeople() {
      try {
        this.loading = true;
        let response = await fetch("https://localhost:5001/swapi/people");
        this.people = await response.json();
      } catch (e) {
        Bus.$emit("fetch:error", "Failed while fetching data");
      }
      this.loading = false;
    },
  },

  mounted() {
    this.getPeople();
  },
};
</script>

<style>
</style>