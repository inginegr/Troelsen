import React from 'react'

import '../ClientItem/ClientItem.css'

const TrueFalse = ({IsTrue, ky, onChange}) => {

  const sign = () => {
    if (IsTrue) {
      console.log("this.props")
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
    onChange(key, true)
  }

  const turnOff = () => {
    const key = ky
    onChange(key, false)
  }

  return (

    <div className="dropdown" >
      <button className="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
        {sign}
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
    User: null
  }


  componentDidMount() {
    this.setState({ User: this.props.clientData })
  }

  setStatus = (key, IsTrue) => {
    this.setState({ [key]: IsTrue })
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

    // if(this.props.IsAdmin==false){
    //     return <div className="empty"></div>
    // }

    return (
      <tr>
        <th scope="row">
          {Id}
        </th>
        <td>
          <TrueFalse IsTrue={VkBot} onChange={this.setStatus} ky={'VkBot'} />
        </td>
        <td>
          {/* <TrueFalse IsTrue={TelegramBot} onChange={this.setStatus} ky={'TelegramBot'} /> */}
        </td>
        <td>
          {/* <TrueFalse IsTrue={ViberBot} onChange={this.setStatus} ky={'ViberBot'} /> */}
        </td>
        <td>
          {/* <TrueFalse IsTrue={WhatsAppBot} onChange={this.setStatus} ky={'WhatsAppBot'} /> */}
        </td>
        <td>
          {/* <input type="text" defaultValue={Login} onChange={(e)=>{this.setState({Login: e.target.value})}} /> */}
        </td>
        <td>
          {/* <input type="text" defaultValue={Password} onChange={(e)=>{this.setState({Password: e.target.value})}} /> */}
        </td>
      </tr>
    )
  }
}