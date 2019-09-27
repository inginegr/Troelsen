import React from 'react'

let Counter = ({counter, inc, dec, rnd}) => {



  return (
    <div>
      <h2 id="counter">
        {counter}
      </h2>
      <button id="inc" onClick={inc}>incыы</button>
      <button id="dec" onClick={dec}>dec</button>
      <button id="rnd" onClick={rnd}>rnd</button>
    </div>
  )
}

export default Counter