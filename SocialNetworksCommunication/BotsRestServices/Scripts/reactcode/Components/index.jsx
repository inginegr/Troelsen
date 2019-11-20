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
    IsClient: false,
    UserAuth: null
  }

  login = ({ Login,Password }) => {
    
    const response = this.service.logIn({ Login, Password })
    
    response.then(
      (serverAnswer) => {
        const {Admin, Client, UserAuth} =JSON.parse(serverAnswer)
        
        if (Admin.IsUserAdmin == true) {
          this.setState({ IsAuthorized: true, IsAdmin: true, UserAuth: UserAuth })
        } else if (Client.IsUserClient == true) {
          this.setState({ IsAuthorized: true, IsClient: true, UserAuth: UserAuth })
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
    //       }l;'
    //     }
    //   )
  }




  render() {

    if(this.state.IsAdmin){
      return(
        <ManageAdmin IsAdmin={this.state.IsAdmin} UserAuth={this.state.UserAuth} />
      )
    }else{
      return (
        <div className="index">
          <Authorization login={this.login} IsAuthorized={this.state.IsAuthorized} />
        </div>
      )
    }
  }
}

export default Index