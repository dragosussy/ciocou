<template>
  <v-app dark>
    <v-main>
      <v-container fill-height fluid>
        <Nuxt />
      </v-container>
    </v-main>
    <v-footer app>
      <span>&copy; {{ new Date().getFullYear() }}</span>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  name: 'DefaultLayout',
  data() {
    return {}
  }
}
</script>

<style>
html {
  overflow-y: auto
}

.container {
  height: 100%;
}

#app {
  background: url("/background/fundal/lg_meadow.png") no-repeat center center fixed;
  -webkit-background-size: cover;
  -moz-background-size: cover;
  -o-background-size: cover;
  background-size: cover;
}
</style>