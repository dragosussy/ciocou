<template>
  <v-row justify="center" align="end" no-gutters class="lg-row-bottom">
    <v-col cols="auto">
      <v-hover v-slot="{ hover }">
        <v-btn @click="ciocc" :width="200" :ripple="false" color="transparent">
          <v-img v-show="!hover" cover src="/butoane/cioc_button.png"></v-img>
          <v-img v-show="hover" cover src="/butoane/buton_cioc_hover.png"></v-img>
        </v-btn>
      </v-hover>
    </v-col>
  </v-row>
</template>

<script>
export default {
  name: 'IndexPage',
  data() {
    return {
      testImg: require("/static/titlu/title_simple.png")
    }
  },

  methods: {
    ciocc() {
      console.log("clicked ciocc")
    }
  }
}
</script>

<style>
.lg-row-bottom {
  height: 70%;
}
</style>