<template>
  <v-container fluid>
    <v-row>
      <v-col>
        <h2>Find jokes, people...</h2>
        <v-form ref="form" @submit.prevent="submitSearch">
          <v-text-field v-model="query" label="Search" required></v-text-field>
        </v-form>
      </v-col>
    </v-row>

    <template v-if="searching">
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
          <v-row v-if="data.swapi && data.swapi.length > 0">
            <v-col>
              <h5>People</h5>
              <v-row>
                <v-col
                  v-for="person in data.swapi"
                  :key="person.name"
                  lg="3"
                  sm="12"
                >
                  <person :person="person" />
                </v-col>
              </v-row>
              <v-divider></v-divider>
            </v-col>
          </v-row>

          <v-row v-if="data.chuck && data.chuck.length > 0">
            <v-col>
              <h5>Jokes</h5>
              <v-row>
                <v-col
                  v-for="joke in data.chuck"
                  :key="joke.value"
                  lg="3"
                  sm="12"
                >
                  <v-card>
                    <v-card-text>
                      {{ joke.value }}
                    </v-card-text>
                  </v-card>
                </v-col>
              </v-row>
            </v-col>
          </v-row>
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
    searching: false,
    query: "",
    data: {},
  }),

  methods: {
    async submitSearch() {
      if (this.query.length >= 3) {
        try {
          this.searching = true;
          let response = await fetch(
            `https://localhost:5001/search?query=${this.query}`
          );
          this.data = await response.json();
        } catch (error) {
          Bus.$emit("fetch:error", "Failed while fetching data.");
        }

        this.searching = false;
      }
    },
  },
};
</script>

<style>
</style>