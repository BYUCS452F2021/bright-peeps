<template>
    <div class= "py-5">
        <div class="py-3 rounded-md overflow-hidden shadow-md bg-gray-400">
            <div class="w-75 px-6 py-3 flex-col space-x-4 bg-gray-400">
                <div class="w-prose mx-auto p-4 flex-col text-center">
                    <h1 class="text-5xl font-bold">Works</h1>
                </div>
            
            <div class="d-flex justify-content-center align-items-center">
                <li v-for="w in this.works" :key="w.id">
                    <div class="py-2">
                        <hr class="py-3 border-top-1 border-dark">
                        <div class="d-flex justify-content-between">
                            <p class="text-left"><strong>{{ w.workTitle }}:</strong> <i>{{ w.workType}}</i></p>
                        </div>
                        <p>{{ w.workDescription}}</p>
                        <br>
                        <p class="text-right">{{w.workUrl}}</p>
                    </div>
                    <button class="px-2 py-2 bg-gray-500 rounded-md" @click="deleteWork(w.id)">Delete</button>

                </li>
            </div>
            </div>
        </div>
        <div class= "py-5 flex-row">
        <div class="py-3 flex-row rounded-md overflow-hidden shadow-md bg-gray-300">
            <input class="px-2" v-model="title" placeholder="Title">
            <input class="px-2" v-model="desc" placeholder="Description">
            <input class="px-2" v-model="type" placeholder="Type">
            <input class="px-2" v-model="url" placeholder="URL">
            <button class="px-2 py-2 bg-gray-500 rounded-md" @click="addWork()">Add Work</button>
        </div>
    </div>
    </div>
</template>

<script>
import axios from 'axios';

export default {
    data: () => {
        return {
            works: [],
            peep: {id: 4},
            title: '',
            desc: '',
            type: '',
            url: '',
        }
    },
    async mounted() {
        const url = 'https://bright-peeps-api.azurewebsites.net/work/peepId/' + this.peep.id;
        const response = await axios.get(url);
        if (response.status === 200) {
            console.log(response.data)
            this.works = response.data.result;
        } else {
            alert("Failed to retrieve works of peep")
        }
    },
    methods: {
        async deleteWork(wId) {
            const url = 'https://bright-peeps-api.azurewebsites.net/work/id/' + wId;
            const response = await axios.delete(url);
            console.log(response);
            this.getWorks()
        },
        async getWorks() {
            const url = 'https://bright-peeps-api.azurewebsites.net/work/peepId/' + this.peep.id;
            const response = await axios.get(url);
            if (response.status === 200) {
                console.log(response.data)
                this.works = response.data.result;
            } else {
                alert("Failed to retrieve works of peep")
            }
        },
        async addWork() {
            if (this.title !== '' && this.type !== '' && this.desc !== '') {
                const response = await axios.post('https://bright-peeps-api.azurewebsites.net/work', null, { params: {
                    peepId: 4,
                    workType: this.type,
                    workDesc: this.desc,
                    workUrl: this.url,
                    workTitle: this.title
                }});
                if (response.status === 200) {
                    console.log(response);
                    this.getWorks()
                } else {
                    console.log(response);
                }
            }
        }
    }
}
</script>

<style scoped>
    .flexRow {
        display: flex;
        justify-content: space-evenly;
        align-content: space-between;
    }
</style>
