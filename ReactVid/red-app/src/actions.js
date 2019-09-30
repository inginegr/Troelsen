export let incr = () => {
    return { type: 'inc' }
}

export let dec = () => {
    return { type: 'dec' }
}

export let rnd = () => {
    const value = Math.floor(Math.random() * 10)
    return {
        type: 'rnd',
        randomValue: value
    }
}
