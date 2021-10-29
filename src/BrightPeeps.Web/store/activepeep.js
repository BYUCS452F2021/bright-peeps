export const state = () => ({
    id: 0
})

export const mutations = {
    setActivePeepId(state, id) {
        state.id = id;
    }
}