import React from 'react'


import '../BotStatusItem/BotStatusItem.css'


const BotStatusItem = ({status, setStatus, botKey}) => {


  const On = "Turned on"
  const Off = "Turned off"

  const showStatus=()=>{
    if(status){
      return On
    }else{
      return Off
    }
  }

  const setBotStatus=(e)=>{
    let trueFalse=null
    const status=e.target.text
    if(status==On){
      trueFalse=true
    }else{
      trueFalse=false
    }
    setStatus(trueFalse, botKey)
  }

  return (
    <div className="dropdown">
      <button className="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
        {showStatus()}
      </button>
      <div className="dropdown-menu" aria-labelledby="dropdownMenuButton">
        <a className="dropdown-item" href="#" onClick={(e)=>setBotStatus(e)} >{On}</a>
        <a className="dropdown-item" href="#" onClick={(e)=>setBotStatus(e)} >{Off}</a>
      </div>
    </div>
  )
}

export default BotStatusItem