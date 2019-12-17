import React from 'react'

//import ClientList from '../ClientList/ClientList.jsx'
import ServerService from '../../Services/ServerService.js'

import '../ManageAdmin/ManageAdmin.css'

import EditList from '../EditList/EditList.jsx'
import { Object } from 'core-js'

export default class ManageAdmin extends React.Component {

  state = {
    totalClientsList: null,
    currentList: [],
    listStack: [],
    UserAuth: null,
    UserPattern: null, // User pattern to add to state
    IsToSave: false,  // If client changed 
    IsToAdd: false, // If client added
    AddedClients: [] // Massive of added clients
    //IsUserList: false // If users rendered in present time
  }

  service = new ServerService()

  // Get list of clients
  getClientsList = () => {
    const response = this.service.getClientsList(this.state.UserAuth)

    response.then(
      (a) => {
        const { Users } = JSON.parse(a)
        console.log(a)
        this.setState({ currentList: Users, IsUserList: true, totalClientsList: Users })
      }
    )
  }

  // Call if list object is changed
  listObjectChanged = (id, newContent) => {

    let isFound = false
    this.setState(
      (state)=>{
        let count=0
        state.currentList.map(
          el=>{
            if(count==id){
              el=newContent
              isFound=true
            }
            count++
          }
        )
        if(isFound){
          state.IsToSave=true
        }
        return state
      }
    )
  }

  // Send object to child component
  getObject=(id)=>{
    return Object.assign(this.state.currentList[id])
  }

  // Render users massive with data massive
  renderUsers = () => {
    let users = Object.assign(this.state.clientsList)

    userDataList = []
    users.map(
      e => {
        const { Id, Login, Password } = e
        userDataList.push({ IsSelectable: false, currentValue: Id, type: 'text' })
        userDataList.push({ IsSelectable: false, currentValue: Login, type: 'text' })
        userDataList.push({ IsSelectable: false, currentValue: Password, type: 'password' })
      }
    )
    return userDataList
  }

  componentDidMount() {
    this.setState({ UserAuth: this.props.UserAuth })
  }

  listOut = () => {
    if ((this.state.currentList != null)&&(this.state.currentList != undefined)) {
      return <EditList renderItems={this.state.currentList} listObjectChanged={this.listObjectChanged} getObject={this.getObject} />
    }
  }

  // Save change in objects
  saveChange = () => {
    console.log("do save")
  }

  // List inserted massive
  ListInsertedMassive=(ElementId)=>{
    this.setState()
  }
  
  // Shows save icon if changes made
  showSaveIcon = () => {
    if (this.state.IsToSave) {
      return (
        <button className="btn btn-primary" type="submit" onClick={this.saveChange} >
          <i className="material-icons"> save </i>
          Save
        </button>
      )
    }
  }

  // Adds client to state
  addClient=()=>{
    this.setState(
      state=>{
        let user = this.service.getUserObject()
        if(state.currentList.length==0){
          user.Id=0
        }else{
          let chooseId=0
          state.currentList.forEach(element => {
            if(element.Id>=chooseId){
              chooseId = element.Id + 1
            }
          });
          
          user.Id = chooseId
        }
        
        user.Login="any"
        user.Password="any"

        state.AddedClients.push(user)
        state.IsToAdd=true

        state.currentList.push(user)
        return state
      }
    )
  }   
  
  // Shows add user icon 
  showAddUserIcon = () => {
    if (this.state.listStack.length < 1) {
      return (
        <button className="btn btn-primary" type="submit" onClick={this.addClient}>
          <i className="material-icons">
            perm_identity
          </i>
          AddUser
        </button>
      )
    }
  }




  render() {
    return (
      <div className="container" id="manage-admin">
        <div className="row justify-content-center align-content-center">
          <div className="col-10">
            <button className="btn btn-primary" type="submit" onClick={this.getClientsList}>
              <i className="material-icons">
                cloud_download
              </i>
              GetList
            </button>          
            {this.showAddUserIcon()}  
            {this.showSaveIcon()}
            {this.listOut()}
          </div>
        </div>
      </div>
    )
  }
}