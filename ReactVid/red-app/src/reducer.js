
let reducer = (state = 0, action) => {

    switch (action.type) {
        case 'rnd': {
            return state + action.randomValue
        }

        case 'inc': {
            return state + 1
        }

        case 'dec': {
            return state - 1
        }

        default:
            return state
    }

}

export default reducer