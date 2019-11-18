import React from 'react'

import './index.css'

import ServerService from '../Services/ServerService.js'

import Authorization from './Authorization/Authorization.jsx'
import ManageAdmin from './ManageAdmin/ManageAdmin.jsx'


let UserObjects = {
  IdSelected: null,
  VkBotStatus: false,
  TelegramBotStatus: false,
  ViberBotStatus: false,
  WhatsAppBotStatus: false
}

let User = {
  Password: null,
  Login: null
}

let ServerAnswer = {
  IsAdmin: false,
  IsClient: false,
  UserAuth: null,
  UserData: [{ UserObjects }],
  IsTrue: false,
}

class Index extends React.Component {

  service = new ServerService()

  state = {
    IsAuthorized: false,
    IsLoading: false,
    IsAdmin: false,
    IsClient: false
  }

  login = ({ login, password }) => {
    const response = this.service.logIn({ login, password })

    response.then(
      (serverAnswer) => {
        const {Admin, Client} =JSON.parse(serverAnswer)
        
        if (Admin.IsUserAdmin == true) {
          this.setState({ IsAuthorized: true, IsAdmin: true })
        } else if (Client.IsUserClient == true) {
          this.setState({ IsAuthorized: true, IsClient: true })
        }

      }
    )




  }

  componentDidMount() {

    // const response = fetch("http://localhost:49492/interface/authorize")
    // console.log(response)

    //   this.setState(
    //     (state, props) => {
    //       return {
    //         IsAuthorized: props.IsAuthorized
    //       }
    //     }
    //   )
  }




  render() {

    return (
      <div className="index">
        <Authorization login={this.login} />
        <ManageAdmin IsAdmin={this.state.IsAdmin} />
      </div>
    )
  }
}

export default Index