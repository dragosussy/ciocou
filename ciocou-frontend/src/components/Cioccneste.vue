<template>
  <div id="pagina-provocare">
    <div>
      <v-card class="d-flex justify-space-between align-stretch mb-6" flat tile>
        <v-card>
          <div class="ou-holder">
            <img src="~@/assets/ou-1.png" />
            <img
              v-if="linkObject.winner == 'Ciocnut'"
              class="winner-crown-left"
              src="~@/assets/crown.png"
            />

            <v-text-field
              label="Ciocnut"
              hide-details="auto"
              disabled
              v-model="linkObject.user1Name"
            ></v-text-field>
          </div>
        </v-card>

        <v-card>
          <div class="float-right ou-holder">
            <img src="~@/assets/ou-2.png" />
            <img
              v-if="linkObject.winner == 'Ciocnel'"
              class="winner-crown-right"
              src="~@/assets/crown.png"
            />

            <v-text-field
              label="Ciocnel"
              hide-details="auto"
              :disabled="linkObject.isDone"
              v-model="linkObject.user2Name"
            ></v-text-field>
          </div>
        </v-card>
      </v-card>
    </div>

    <div>
      <v-btn
        id="ciocc"
        v-if="!linkObject.isDone"
        @click="cioccneste"
        depressed
        color="error"
      >
        Ciocneste!
      </v-btn>
    </div>
  </div>
</template>

<script>
export default {
  name: "TeProvocLaCiocc",
  data() {
    return {
      linkObject: {},
    };
  },

  async mounted() {
    const provocareId = this.$route.query.id;
    const getLinkEndpoint = new URL(window.endpoints.getLink);
    const params = { guid: provocareId };

    Object.keys(params).forEach((key) =>
      getLinkEndpoint.searchParams.append(key, params[key])
    );

    const response = await fetch(getLinkEndpoint);
    this.linkObject = await response.json();
  },

  methods: {
    getRandomWinner: function () {
      const players = ["Ciocnel", "Ciocnut"];
      return players[Math.floor(Math.random() * players.length)];
    },

    cioccneste: async function () {
      const randomWinner = this.getRandomWinner();

      const response = await fetch(window.endpoints.updateLink, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          Guid: this.linkObject.guid,
          User2Name: this.linkObject.user2Name,
          Winner: randomWinner,
        }),
      });
      this.linkObject = await response.json();
    },
  },
};
</script>

<style scoped>
img {
  width: 150%;
}

#ciocc {
  position: absolute;
  bottom: 20%;
  left: 45%;
}

.winner-crown-left {
  position: absolute;
  width: 30%;
  top: 0;
  left: 110px;
}

.winner-crown-right {
  position: absolute;
  width: 28%;
  top: 0;
  right: 3px;
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
