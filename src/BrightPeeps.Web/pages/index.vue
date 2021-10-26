<template>
  <div>
    <Navbar />

    <div class="w-prose mx-auto p-4 flex-col text-center">
      <h1 class="text-5xl font-bold">Welcome to Bright Peeps</h1>
      <p class="mt-4 text-lg">This is Home.</p>

      <PeepCardHorizontalList />
      <PeepCardHorizontalList />
      <PeepCardHorizontalList />
    </div>
  </div>
</template>

<script>
import PeepCardHorizontalList from '~/components/lists/PeepCardHorizontalList.vue'
export default {
  components: { PeepCardHorizontalList },
}
</script>
