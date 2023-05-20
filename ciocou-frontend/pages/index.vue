<template>
  <v-row justify="center" align="end" no-gutters class="lg-row-bottom">
    <v-col cols="auto">
      <HoverButton image-path="/butoane/cioc_button.png" hover-image-path="/butoane/buton_cioc_hover.png"
        redirect-page="provoaca" width="200" />
    </v-col>
  </v-row>
</template>

<script>
import HoverButton from '../components/HoverButton.vue';

export default {
  name: "IndexPage",
  components: { HoverButton }
}
</script>

<style>
.lg-row-bottom {
  height: 70%;
}
</style>