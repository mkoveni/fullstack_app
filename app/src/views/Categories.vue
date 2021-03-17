
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

    <v-row v-else>
      <v-col>
        <h2>Get joke in category...</h2>
        <v-divider></v-divider>

        <v-row>
          <v-col v-for="category in categories" :key="category" sm="12" lg="3">
            <v-card elevation="2">
              <v-card-text>
                <div>Category</div>
                <p class="display-1 text--primary">{{ category }}</p>
                <p v-if="category"></p>
              </v-card-text>
              <v-card-actions>
                <v-btn class="primary" @click="getJoke(category)">
                  Get Joke
                </v-btn>
              </v-card-actions>
            </v-card>
          </v-col>
        </v-row>
      </v-col>
    </v-row>

    <v-dialog v-model="dialog" width="500">
      <v-card>
        <v-card-title class="headline primary lighten-2">
          {{ (joke.categories && joke.categories[0]) || "Joker" }}
        </v-card-title>

        <v-card-text>
          {{ joke.value }}
        </v-card-text>

        <v-divider></v-divider>

        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="primary" @click="dialog = false"> close </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-container>
</template>

<script>
import Bus from "../Bus";
import config from "../config";

export default {
  data: () => ({
    loading: false,
    dialog: false,
    categories: [],
    joke: {},
  }),
  methods: {
    async getCategories() {
      try {
        this.loading = true;
        let response = await fetch(`${config.api.baseUrl}/chuck/categories`, {
          method: "GET",
        });

        this.categories = await response.json();
      } catch (error) {
        Bus.$emit("fetch:error", "Failed while fetching data");
      }

      this.loading = false;
    },

    async getJoke(category) {
      try {
        let response = await fetch(
          `${config.api.baseUrl}/chuck/random/${category}`,
          {
            method: "GET",
          }
        );
        this.joke = await response.json();

        console.log(this.joke);

        this.dialog = true;
      } catch (e) {
        Bus.$emit("fetch:error", "Failed while fetching joke data");
      }
    },
  },

  mounted() {
    this.getCategories();
  },
};
</script>