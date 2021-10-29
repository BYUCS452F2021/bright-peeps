<template>
  <div class="max-h-500px my-2 py-3 px-1">
    <div
      class="
        mt-2
        mb-4
        pb-3
        text-left text-3xl
        font-bold
        border-b-2 border-gray-600
      "
    >
      {{ title }}
    </div>
    <ul class="px-4 pb-6 flex overflow-y-scroll space-x-4">
      <li v-for="p in peeps" :key="p.id" class="flex-none">
        <PeepCard
          :id="p.id"
          :name="p.fullName"
          :description="p.shortDescription"
        />
      </li>
    </ul>
    <div class="mt-2 mb-4 border-t-2 border-gray-600"></div>
  </div>
</template>

<script>
import PeepCard from '~/components/cards/PeepCard.vue'
export default {
  components: { PeepCard },
  props: {
    title: {
      type: String,
      required: true,
      default: 'Peeps',
    },
    peeps: [],
  },
}
</script>