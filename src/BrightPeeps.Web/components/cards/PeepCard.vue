<template>
  <div class="max-w-[300px] rounded-md overflow-hidden shadow-md">
    <NuxtLink to="/profile" @click.native="setActiveId">
      <img class="w-full h-[250px]" :src="image" alt="Peep Profile Image" />
    </NuxtLink>
    <div class="px-6 py-4 bg-gray-700 text-gray-300">
      <NuxtLink to="/profile" @click.native="setActiveId">
        <div class="font-bold text-xl mb-2 hover:text-green-400">
          {{ name }}
        </div>
      </NuxtLink>
      <p>{{ description }}</p>
    </div>
    <div class="px-6 py-3 flex space-x-4 bg-gray-600">
      <button
        class="flex-auto py-2 hover:text-red-400 hover:bg-gray-500 rounded-md"
      >
        Like
      </button>
      <button
        class="flex-auto py-2 hover:text-blue-400 hover:bg-gray-500 rounded-md"
      >
        Follow
      </button>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
export default {
  props: {
    id: {
      type: Number,
      required: true,
      default: 4,
    },
    name: {
      type: String,
      required: true,
      default: 'A Bright Peep',
    },
    description: {
      type: String,
      required: true,
      default: 'A description about a bright peep',
    },
  },
  data: () => {
    return {
      image: '',
    }
  },
  async mounted() {
    const url =
      'https://bright-peeps-api.azurewebsites.net/image/peep/' + this.id
    const response = await axios.get(url)
    if (response.status === 200) {
      this.image = response.data.result[0]
        ? response.data.result[0].imageUrl
        : 'https://bhcoe.org/wp-content/uploads/2019/08/Profile-placeholder-300x300.png'
    } else {
      alert(`Failed to retrieve data of peep ${this.id}.`)
    }
  },
  methods: {
    setActiveId() {
      this.$store.state.id = this.id
    },
  },
}
</script>
