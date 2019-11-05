import React from 'react'


import './ButtonsRow.css'


const ButtonsRow = ({ buttons }) => {



  let k = 0

  let el = buttons.map(
    (a) =>
      <div key={k++} className="col">
        <input className="br-button" type="button" value={a} onClick={()=>{srv.logIn()}} />
      </div>
  )

  return (
    <div id="buttons-row" className="container">
      <div className="row justify-content-between">
        {el}
      </div>
    </div>
  )
}

export default ButtonsRow