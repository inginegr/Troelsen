import React from 'react'

import ClientItem from '../ClientItem/ClientItem.jsx'


import '../ClientList/ClientList.css'

export default class ClientList extends React.Component {

  state = {
    Users: null,
    UserAuth: null
  }

  userData = {
    Id: "ID",
    VkBot: "VK Bot",
    TelegramBot: "Telegram Bot",
    ViberBot: "Viber Bot",
    WhatsAppBot: "WhatsApp Bot"
  }

  removeClient=(a)=>{
    const {Id} = a
    let newUsers=[]
    for(let i=0;i<this.state.Users.length;i++){
      const el =this.state.Users[i] 
      if(el.Id!=Id){
        newUsers.push(Object.assign(el))
      }
    }
    console.log(newUsers)
    this.setState({Users: newUsers})
  }

  Elements = () => {
    
    if (this.props.clientsList == null || this.props.clientsList == undefined || this.state.UserAuth==null) {
      return null
    }

    let count = 0

    return (
      this.state.Users.map(
        (a) => {
          count++
          console.log(a)
          return (
            <ClientItem key={count} clientData={a} removeClient={(a)=>this.removeClient(a)} UserAuth={this.state.UserAuth} />
          )
        }
      )
    )
  }

  componentDidMount() {
    this.setState({UserAuth: this.props.UserAuth, Users: this.props.clientsList})
  }

  render() {

    return (
      <div className="container" id="m-a-client-list">
        <div className="row justify-content-center align-content-center">
          <div className="col-12">
            <table className="table table-hover table-dark">
              <thead>
                <tr>
                  <th scope="col"><p className="text-center">Id</p></th>
                  <th scope="col"><p className="text-center">VK Bot</p></th>
                  <th scope="col"><p className="text-center">Telegram Bot</p></th>
                  <th scope="col"><p className="text-center">Viber Bot</p></th>
                  <th scope="col"><p className="text-center">WhatsApp Bot</p></th>
                  <th scope="col"><p className="text-center">Login</p></th>
                  <th scope="col"><p className="text-center">Password</p></th>
                </tr>
              </thead>

              <tbody>
                {this.Elements()}
              </tbody>
            </table>
          </div>
        </div>
      </div>
    )
  }
}