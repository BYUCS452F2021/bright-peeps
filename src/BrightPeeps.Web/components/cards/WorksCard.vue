<template>
  <div class="w-prose mx-auto p-4 flex-col text-center">
    <h1 class="mb-5 text-5xl font-bold">Works</h1>
    <div
      class="
        flex flex-col
        space-y-5
        justify-content-center
        align-items-center
        text-center
      "
    >
      <div v-for="w in works" :key="w.id" class="flex space-x-4">
        <p>
          <strong>{{ w.workTitle }}:</strong>
        </p>
        <p>
          <i>{{ w.workType }}</i>
        </p>
        <p>{{ w.workDescription }}</p>
        <p>
          <a :href="w.workUrl"> {{ w.workUrl }} </a>
        </p>
        <div class="flex-none m-w-[50px]">
          <button
            class="px-2 py-2 bg-gray-500 rounded-md"
            @click="deleteWork(w.id)"
          >
            Delete
          </button>
        </div>
      </div>
    </div>

    <div class="py-5 flex-row">
      <div
        class="py-3 flex-row rounded-md overflow-hidden shadow-md bg-gray-300"
      >
        <input v-model="title" class="px-2" placeholder="Title" />
        <input v-model="desc" class="px-2" placeholder="Description" />
        <input v-model="type" class="px-2" placeholder="Type" />
        <input v-model="url" class="px-2" placeholder="URL" />
        <button class="px-2 py-2 bg-gray-500 rounded-md" @click="addWork()">
          Add Work
        </button>
      </div>
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
  },
  data: () => {
    return {
      works: [],
      title: '',
      desc: '',
      type: '',
      url: '',
    }
  },
  async mounted() {
    const url =
      'https://bright-peeps-api.azurewebsites.net/work/peepId/' + this.id
    const response = await axios.get(url)
    if (response.status === 200) {
      //   console.log(response.data)
      this.works = response.data.result
    } else {
      alert('Failed to retrieve works of peep')
    }
  },
  methods: {
    async deleteWork(wId) {
      const url = 'https://bright-peeps-api.azurewebsites.net/work/id/' + wId
      await axios.delete(url)
      //   console.log(response)
      this.getWorks()
    },
    async getWorks() {
      const url =
        'https://bright-peeps-api.azurewebsites.net/work/peepId/' + this.id
      const response = await axios.get(url)
      if (response.status === 200) {
        // console.log(response.data)
        this.works = response.data.result
      } else {
        alert('Failed to retrieve works of peep')
      }
    },
    async addWork() {
      if (this.title !== '' && this.type !== '' && this.desc !== '') {
        const response = await axios.post(
          'https://bright-peeps-api.azurewebsites.net/work',
          null,
          {
            params: {
              peepId: this.id,
              workType: this.type,
              workDesc: this.desc,
              workUrl: this.url,
              workTitle: this.title,
            },
          }
        )
        if (response.status === 200) {
          console.log(response)
          this.getWorks()
        } else {
          console.log(response)
        }
      }
    },
  },
}
</script>

<style scoped>
.flexRow {
  display: flex;
  justify-content: space-evenly;
  align-content: space-between;
}
</style>
