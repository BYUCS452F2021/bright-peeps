<template>
  <div class="max-h-500px my-2 py-3 px-1">
    <div class="mt-2 mb-4 pb-3 text-left text-3xl font-bold border-b-2 border-gray-600">List Title</div>
    <ul class="px-4 pb-6 flex overflow-y-scroll space-x-4">
      <li v-for="i in 15" :key="i" class="flex-none">
        <PeepCard />
      </li>
    </ul>
    <div class="mt-2 mb-4 border-t-2 border-gray-600"></div>
  </div>
</template>

<script>
import PeepCard from '~/components/cards/PeepCard.vue'
export default {
  components: { PeepCard },
}
</script>