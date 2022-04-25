<template>
  <div id="pagina-provocare">
    <v-card class="d-flex justify-space-between align-stretch mb-6" flat tile>
      <v-card>
        <div class="ou-holder">
          <img src="~@/assets/ou-1.png" />
          <v-text-field
            label="Ciocnut"
            hide-details="auto"
            v-model="userName"
          ></v-text-field>
        </div>
      </v-card>

      <v-card>
        <div class="float-right ou-holder">
          <img src="~@/assets/ou-2.png" />
        </div>
      </v-card>
    </v-card>

    <div>
      <div class="provoaca-btn">
        <v-btn @click="generateLink" depressed color="error"> Provoaca! </v-btn>
      </div>

      <div class="link-textfield">
        <v-text-field v-model="link" disabled></v-text-field>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "TeProvocLaCiocc",
  data() {
    return {
      userName: "",
      link: "",
    };
  },
  methods: {
    generateLink: async function () {
      const generateLinkEndpoint = new URL(window.endpoints.generateLink);
      const params = { user1Name: this.userName };

      Object.keys(params).forEach((key) =>
        generateLinkEndpoint.searchParams.append(key, params[key])
      );

      const response = await fetch(generateLinkEndpoint);
      this.link = await response.text();
    },
  },
};
</script>

<style scoped>
img {
  width: 150%;
}

.provoaca-btn {
  position: absolute;
  bottom: 20%;
  left: 45%;
}

.link-textfield {
  position: absolute;
  text-align: center;
  left: 28%;
  bottom: 10%;
  width: 44%;
}
.link-textfield >>> .v-text-field__slot input {
  color: #20612c;
  background: #f5fa6e;
  text-align: center;
  border-radius: 15px;
}

.v-sheet.v-card {
  background: transparent;
  box-shadow: 0;
  padding: 0 20px 0 20px;
}
.v-sheet.v-card:not(.v-sheet--outlined) {
  box-shadow: 0px 3px 1px -2px rgb(0 0 0 / 0%), 0px 2px 2px 0px rgb(0 0 0 / 0%),
    0px 1px 5px 0px rgb(0 0 0 / 0%);
}
</style>
