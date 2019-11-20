import React from 'react'


import '../ClientItem/ClientItem.css'

import ServerService from '../../Services/ServerService.js'

const TrueFalse = ({IsTrue, ky, changeStatus}) => {

  const sign = () => {
    if (IsTrue) {
      return (
        "Подключен"
      )
    } else {
      return (
        "Отключен"
      )
    }
  }

  const turnOn = () => {
    const key = ky
    changeStatus(key, true)
  }

  const turnOff = () => {
    const key = ky
    changeStatus(key, false)
  }

  return (

    <div className="dropdown" >
      <button className="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
        {sign()}
      </button>
      <div className="dropdown-menu" aria-labelledby="dropdownMenuButton">
        <a className="dropdown-item" href="#" onClick={turnOn} >Подключить</a>
        <a className="dropdown-item" href="#" onClick={turnOff} >Отключить</a>
      </div>
    </div>
  )
}


export default class ClientItem extends React.Component {

  state = {
    User: null,      // All properties of component
    IsChanged: false, // Show if any property in coponent is changed
    UserAuth: null
  }

  service=new ServerService()

  componentDidMount() {
    this.setState({ User: this.props.clientData, UserAuth: this.props.UserAuth })
  }

  setStatus = (key, IsTrue) => {
    let newUser=Object.assign(this.state.User)
    
    newUser[key]=IsTrue

    this.setState(
      {
        User: newUser,
        IsChanged: true
      }
    )
  }

  setText = (key, e) => {
    this.setState({ [key]: e.target.value })
  }

  saveMouseOn = (e)=>{
    e.target.className=e.target.className + " on";
  }

  saveMouseOff = (e)=>{
    e.target.className = "material-icons save"
  }

  saveOnClick=(e)=>{
    const response = this.service.saveClientData(this.state.UserAuth, this.state)

    response.then(
      (e)=>{
        const resp = JSON.parse(e)
        const {IsTrue} = resp
        console.log(IsTrue)
        if (IsTrue.IsTrue) {
          this.setState({IsChanged: false})
        }
      }
    )
  }

  showSave=()=>{
    if(this.state.IsChanged){
      return(
        <i className="material-icons save" 
        onMouseOver={(e)=>this.saveMouseOn(e)} 
        onMouseLeave={(e)=>this.saveMouseOff(e)} 
        onClick={(e)=>this.saveOnClick(e)} >save</i>
      )
    }
  }

  render() {

    if (this.state.User == null) {
      return null
    }

    const {
      Id,
      VkBot,
      TelegramBot,
      ViberBot,
      WhatsAppBot,
      Login,
      Password
    } = this.state.User

    return (
      <tr id="ma-client-item">
        <th scope="row">
          {Id}
        </th>
        <td>
          <TrueFalse IsTrue={VkBot} changeStatus={this.setStatus}  ky={'VkBot'} />
        </td>
        <td>
          <TrueFalse IsTrue={TelegramBot} changeStatus={this.setStatus} ky={'TelegramBot'} />
        </td>
        <td>
          <TrueFalse IsTrue={ViberBot} changeStatus={this.setStatus} ky={'ViberBot'} />
        </td>
        <td>
          <TrueFalse IsTrue={WhatsAppBot} changeStatus={this.setStatus} ky={'WhatsAppBot'} />
        </td>
        <td>
          <input type="text" defaultValue={Login} onChange={(e)=>{this.setState({Login: e.target.value})}} />
        </td>
        <td>
          <input type="text" defaultValue={Password} onChange={(e)=>{this.setState({Password: e.target.value})}} />
        </td>
        <td>
          {this.showSave()}
        </td>
      </tr>
    )
  }
}