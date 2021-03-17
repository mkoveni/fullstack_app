<template>
  <v-app id="inspire">
    <v-navigation-drawer
      v-model="drawer"
      app
      class="pt-4"
      color="grey lighten-3"
    >
      <v-list>
        <v-list-item>
          <v-btn to="/search">
            Discover
            <v-icon right>mdi-compass-outline</v-icon>
          </v-btn>
        </v-list-item>

        <v-list-item>
          <v-btn to="/">
            Categories
            <v-icon right>mdi-group</v-icon>
          </v-btn>
        </v-list-item>

        <v-list-item>
          <v-btn to="/people">
            People
            <v-icon right>mdi-account-group</v-icon>
          </v-btn>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-main>
      <router-view />
    </v-main>

    <v-snackbar
      v-model="snackbar"
      :timeout="timeout"
      color="deep-purple accent-4"
      elevation="24"
    >
      {{ notification }}

      <template v-slot:action="{ attrs }">
        <v-btn color="blue" text v-bind="attrs" @click="snackbar = false">
          Close
        </v-btn>
      </template>
    </v-snackbar>
  </v-app>
</template>

<script>
import Bus from "./Bus";
export default {
  data: () => ({
    timeout: 10000,
    drawer: true,
    snackbar: false,
    notification: "",
  }),

  mounted() {
    Bus.$on("fetch:error", (message) => {
      this.notification = message;
      this.snackbar = true;
    });
  },
};
</script>
