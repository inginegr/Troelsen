import React from 'react'

import './ButtonsRow.css'


const ButtonsRow = ({ buttons }) => {

  let k=0

  let el = <input key={k++} type="button" value={buttons[1]} />
  // buttons.map(
  //   (lbl)=>{
  //     <input key={k++} type="button" value={lbl} />
  //   }
  // )  

  return(
    <div id="buttons-row" className="container">
      <div className="row justify-content-between">
        <div className="col">
          {el}
        </div>
      </div>
    </div>
  )
}

export default ButtonsRow