import React from 'react'


import '../ClientItem/ClientItem.css'

import BotStatusItem from '../BotStatusItem/BotStatusItem.jsx'


const ClientItem = ({clientInfo, statusChanged, IsChanged, textChanged, saveChange}) => {

  const {
    Id,
    VkBot,
    TelegramBot,
    ViberBot,
    WhatsAppBot,
    Login,
    Password
  } = clientInfo

  const changeStatus=(status, key)=>{
    clientInfo[key]=status
    statusChanged(clientInfo)
  }

  const saveClient=()=>{
    saveChange(clientInfo)
  }

  const showSave=()=>{
    if(IsChanged){
      return (
        <i className="material-icons" onMouseOver={(e)=>{encreaseIcon(e)}} onMouseLeave={(e)=>{decreaseIcon(e)}} onClick={saveClient} >save</i>
      )
    }
  }

  const encreaseIcon=(e)=>{
    e.target.className+=" on"
  }
  
  const decreaseIcon=(e)=>{
    e.target.className = e.target.className.replace(" on", "")
  }
  
  const changeText=(e,key)=>{
    textChanged(e,clientInfo, key)
  }

  return (

    
    <tr id="m-a-c-l-client-item">
      <th scope="row">
        {Id}
      </th>
      <td>
        <BotStatusItem status={VkBot} setStatus={changeStatus} botKey={'VkBot'} />
      </td>
      <td>
        <BotStatusItem status={TelegramBot} setStatus={changeStatus} botKey={'TelegramBot'} />
      </td>
      <td>
        <BotStatusItem status={ViberBot} setStatus={changeStatus} botKey={'ViberBot'} />
      </td>
      <td>
        <BotStatusItem status={WhatsAppBot} setStatus={changeStatus} botKey={'WhataAppBot'} />
      </td>
      <td>
        <input type="text" defaultValue={Login} onChange={(e)=>{changeText(e, 'Login')}}  />
      </td>
      <td>
        <input type="text" defaultValue={Password} onChange={(e)=>{changeText(e, 'Password')}}  />
      </td>
      <td>
        {showSave()}
      </td>
      <td>
        <i className="material-icons" onMouseOver={(e)=>{encreaseIcon(e)}} onMouseLeave={(e)=>{decreaseIcon(e)}} >delete_forever</i>
      </td>
    </tr>
  )
}

export default ClientItem