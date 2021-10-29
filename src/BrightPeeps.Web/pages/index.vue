<template>
  <div>
    <Navbar />

    <div class="w-prose mx-auto p-4 flex-col text-center">
      <h1 class="text-5xl font-bold">Welcome to Bright Peeps</h1>
      <p class="mt-4 text-lg">This is Home.</p>

      <PeepCardHorizontalList title="All Peeps" :peeps="peeps" />
    </div>
  </div>
</template>

<script>
import axios from 'axios'
import PeepCardHorizontalList from '~/components/lists/PeepCardHorizontalList.vue'
export default {
  components: { PeepCardHorizontalList },
  data: () => {
    return {
      peeps: [],
    }
  },
  async mounted() {
    const url = 'https://bright-peeps-api.azurewebsites.net/peep/'
    const response = await axios.get(url)
    if (response.status === 200) {
      //   console.log(response.data)
      this.peeps = response.data.result
    } else {
      alert(`Failed to retrieve data of peep ${this.id}.`)
    }
  },
}
</script>
