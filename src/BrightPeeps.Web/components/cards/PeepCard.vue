<template>
  <div class="max-w-[300px] rounded-md overflow-hidden shadow-md">
    <a href="/profile">
      <img
        class="w-full max-h-[250px]"
        src="https://bhcoe.org/wp-content/uploads/2019/08/Profile-placeholder-300x300.png"
        alt="Sunset in the mountains"
      />
    </a>
    <div class="px-6 py-4 bg-gray-700 text-gray-300">
      <a href="#">
        <div class="font-bold text-xl mb-2 hover:text-green-400">Peep Name</div>
      </a>
      <p>Peep description</p>
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
export default {}
</script>
