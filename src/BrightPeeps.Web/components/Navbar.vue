<template>
  <div
    class="
      w-full
      min-h-[40px]
      max-h-[60px]
      py-3
      flex
      items-center
      space-x-3
      bg-gray-900
      border-b-2 border-green-300
      text-white
    "
  >
    <span class="px-2 flex-none text-3xl hover:text-green-400">
      <NuxtLink to="/">Bright Peeps</NuxtLink>
    </span>
    <div class="flex-auto align-text-bottom text-2xl space-x-3 text-gray-300">
      <NuxtLink to="/authenticate" class="hover:text-white"
        >authenticate</NuxtLink
      >
      <NuxtLink to="/explore" class="hover:text-white">explore</NuxtLink>
      <NuxtLink to="/about" class="hover:text-white">about</NuxtLink>
    </div>
    <span class="px-2 flex-none flex space-x-2">
      <input
        type="text"
        class="
          flex-auto
          appearance-none
          border
          rounded
          py-2
          px-3
          italic
          bg-gray-100
          focus:bg-white
          text-gray-400
          focus:text-gray-700
          leading-tight
          focus:outline-none
        "
        placeholder="Search anyone..."
      />
      <button
        class="
          p-2
          bg-gray-200
          hover:bg-gray-100
          active:bg-gray-300
          rounded
          text-gray-800
        "
        @click="alertGotcha"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          class="h-6 w-6"
          fill="none"
          viewBox="0 0 24 24"
          stroke="currentColor"
        >
          <path
            stroke-linecap="round"
            stroke-linejoin="round"
            stroke-width="2"
            d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z"
          />
        </svg>
      </button>
    </span>
    <span class="px-2 flex-none flex space-x-2">
      <button
        class="
          flex
          space-x-2
          p-2
          bg-gray-200
          hover:bg-gray-100
          active:bg-gray-300
          rounded
          text-gray-800
        "
        @click="alertUser"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          class="h-6 w-6"
          fill="none"
          viewBox="0 0 24 24"
          stroke="currentColor"
        >
          <path
            stroke-linecap="round"
            stroke-linejoin="round"
            stroke-width="2"
            d="M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z"
          />
        </svg>
        <p v-if="username">{{ username }}</p>
      </button>
    </span>
  </div>
</template>

<script>
export default {
  computed: {
    username() {
      return this.$store.state.username
    },
  },
  methods: {
    alertUser() {
      alert(`Welcome, ${this.username ? this.username : 'guest'}!`)
    },
    alertGotcha() {
      alert(
        `Gotcha! The search functionality isn't implemented in the front-end yet!`
      )
    },
  },
}
</script>