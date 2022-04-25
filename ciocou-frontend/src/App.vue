<template>
  <v-app>
    <v-main>
      <router-view></router-view>
    </v-main>
  </v-app>
</template>

<script>
export default {
  created() {
    document.title = "Ciocou";
  },
};
</script>

<style>
html,
body {
  height: 100%;
  margin: 0;
}

#app {
  height: 100%;
  background-image: url("./assets/global_background.jpg");
  background-size: cover;
}

.ou-holder {
  width: 45%;
}
</style>