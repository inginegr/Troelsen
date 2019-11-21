import React from 'react'

import ClientItem from '../ClientItem/ClientItem.jsx'
import ServerService from '../../Services/ServerService.js'

import '../ClientList/ClientList.css'

export default class ClientList extends React.Component {

  service =new ServerService()

  state = {
    Users: [], // array of clients
    UserAuth: null, // login and password
    IsChangedArray: []  // Id of changed clients
  }

  // Handle changes in client bots state
  changeClient=(client)=>{
    let newUsers = Object.assign(this.state.Users)
    newUsers.forEach(newUser => {
      if(newUser.Id==client.Id){
        newUser=Object.assign(client)
      }
    })

    if(!this.state.IsChangedArray.includes(client.Id)){
      let newChangeArray=Object.assign(this.state.IsChangedArray)
      newChangeArray.push(client.Id)
      this.setState({Users: newUsers, IsChangedArray: newChangeArray})
    }else{
      this.setState({Users: newUsers})
    }
  }

  // Handle text changed in password and login fields
  textChanged=(e, client, key)=>{
    let newClient=Object.assign(client)
    newClient[key]=e.target.value
    this.changeClient(newClient)
  }

  // Remove save chancge icon from table
  deleteSaveIcon=(client)=>{
    let newArray=[null]
    this.state.IsChangedArray.map(
      (a)=>{
        if(a.Id!=client.Id){
          newArray.push(a.Id)
        }
      }
    )

    this.setState({IsChangedArray: newArray})
  }

  //Save change in client
  saveChange=(client)=>{
    
    let tempVar = null
    this.state.Users.map(
      (c)=>{
        if(c.Id==client.Id){
          tempVar=c
        }
      }
    )

    const newClient= {User: Object.assign(tempVar)} 
    
    const ans = this.service.saveClientData(this.state.UserAuth, newClient)

    ans.then(
      (ob)=>{
        const {IsTrue} = JSON.parse(ob)
        if(IsTrue.IsTrue){
          this.deleteSaveIcon(client)
        }
      }
    )
  }
  
  Elements = () => {

    if (this.state.Users == null || this.state.Users == undefined || this.state.UserAuth==null) {
      return null
    }
    
    let count = 0
    console.log(this.state.IsChangedArray)
    return (
      this.state.Users.map(
        (client) => {
          count++
          const trueFalse=this.state.IsChangedArray.includes(client.Id)
          
          return (
            <ClientItem key={count} 
              clientInfo={client} 
              statusChanged={this.changeClient} 
              IsChanged={trueFalse} 
              textChanged={this.textChanged} 
              saveChange={this.saveChange} />
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