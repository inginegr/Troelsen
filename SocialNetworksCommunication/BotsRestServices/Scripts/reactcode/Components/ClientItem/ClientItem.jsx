import React from 'react'

import '../ClientItem/ClientItem.css'

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
    IsChanged: false // Show if any property in coponent is changed
  }

  componentDidMount() {
    this.setState({ User: this.props.clientData })
  }

  setStatus = (key, IsTrue) => {
    let newUser=Object.assign(this.state.User)
    newUser[key]=IsTrue
    this.setState(
      {
        User: newUser
      }
    )
    console.log(this.state.User)
  }

  setText = (key, e) => {
    this.setState({ [key]: e.target.value })
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
      <tr>
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
          asdasd
        </td>
      </tr>
    )
  }
}