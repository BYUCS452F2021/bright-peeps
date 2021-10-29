<template>
  <div>
    <Navbar />

    <div
      class="
        w-prose
        mx-auto
        p-4
        flex-col
        align-content-center
        justify-items-center
        text-center
      "
    >
      <h1 class="text-5xl font-bold">Peep Profile</h1>
      <p class="mt-4 text-lg">Learn About This Wonderful Peep</p>

      <div class="flex-auto">
        <div class="flex-auto">
          <PeepCard
            :id="id"
            :name="peep.fullName"
            :image="peep.imageUrl"
            :description="peep.shortDescription"
          />
        </div>
        <WorksCard :id="id" />
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
import PeepCard from '~/components/cards/PeepCard.vue'
import WorksCard from '~/components/cards/WorksCard.vue'

export default {
  components: { PeepCard, WorksCard },
  data: () => {
    return {
      peep: {},
    }
  },
  computed: {
    id() {
      return this.$store.state.id
    },
  },
  async mounted() {
    const url = 'https://bright-peeps-api.azurewebsites.net/peep/' + this.id
    const response = await axios.get(url)
    if (response.status === 200) {
      console.log(response.data.result[0])
      this.peep = response.data.result[0]
    } else {
      alert(`Failed to retrieve data of peep ${this.id}.`)
    }
  },
  methods: {},
}
</script>

<style scoped>
</style>