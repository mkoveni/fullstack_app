<template>
  <v-card>
    <v-card-text>
      <h5>{{ person.name }}</h5>
      <p :style="{ color: person.eyeColor }">
        Birth Year: {{ person.birthYear }}
      </p>
    </v-card-text>
  </v-card>
</template>

<script>
export default {
  props: ["person"],
};
</script>

<style>
</style>