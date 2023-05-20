<template>
    <v-hover v-slot="{ hover }">
        <v-btn @click="$router.push({ name: redirectPage })" :width="width" :ripple="false" color="transparent">
            <v-img v-show="!hover" cover :src="imagePath"></v-img>
            <v-img v-show="hover" cover :src="hoverImagePath"></v-img>
        </v-btn>
    </v-hover>
</template>

<script>
export default {
    name: "HoverButton",
    props: ["redirectPage", "width", "imagePath", "hoverImagePath"]
}
</script>