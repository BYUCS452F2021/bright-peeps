<template>
  <div>
    <Navbar />

    <div class="w-prose mx-auto p-4 flex-col align-content-center justify-items-center text-center">
        <h1 class="text-5xl font-bold">Peep Profile</h1>
        <p class="mt-4 text-lg">Learn About This Wonderful Peep</p>

        <div class="flex-auto">
            <div class="flex-auto">
                <PeepCard />
            </div>
            <WorksCard />
        </div>

    </div>
  </div>
</template>

<script>
import PeepCard from '~/components/cards/PeepCard.vue'
import WorksCard from '~/components/cards/WorksCard.vue'
export default {
  components: { PeepCard, WorksCard },
}
</script>

<style scoped>
    
</style>