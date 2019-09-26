export let inc = () => {
    return { type: 'inc' }
}

export let dec = () => {
    return { type: 'dec' }
}

export let rnd = (value) => {
    return {
        type: 'rnd',
        randomValue: value
    }
}
