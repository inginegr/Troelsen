import React from 'react'

//import ClientList from '../ClientList/ClientList.jsx'
import ServerService from '../../Services/ServerService.js'

import '../ManageAdmin/ManageAdmin.css'

import EditList from '../EditList/EditList.jsx'
import { Object } from 'core-js'

export default class ManageAdmin extends React.Component {

  state = {
    totalClientsList: [], // Total clients list gotten from server. All edit user operations are influence on this object
    currentList: [],
    listStack: [],
    UserAuth: null,
    UserPattern: null, // User pattern to add to state
    IsToSave: false,  // If client changed 
    IsToAdd: false, // If item added
    AddedItems: [], // Massive of added items
    IsToDelete: false, // Is there deleted item
    DeletedItems:[], // Massive with deleted clients
    
    //IsUserList: false // If users rendered in present time
  }

  service = new ServerService()

  // Get list of clients
  getClientsList = () => {
    const response = this.service.getClientsList(this.state.UserAuth)

    response.then(
      (a) => {
        const { Users } = JSON.parse(a)
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


  //Delete element from rendered massive
  deleteSomeItem=(id)=>{

  }

  listOut = () => {
    if ((this.state.currentList != null)&&(this.state.currentList != undefined)) {
      return <EditList renderItems={this.state.currentList} listObjectChanged={this.listObjectChanged} getObject={this.getObject} 
      state={this.state} listInsertedArray={this.listInsertedMassive} deleteSomeItem={this.deleteSomeItem} />
    }
  }

  // Save change in objects
  saveChange = () => {
    console.log("do save")
  }

  // List inserted massive of selected element
  listInsertedMassive=(ElementId)=>{
    
    this.setState(
      s=>{
        let currentElement=s.currentList[ElementId]

        for(let key in currentElement){
          if(Array.isArray(currentElement[key])){
            s.listStack.push(s.currentList)
            s.currentList=currentElement[key]
          }
        }

        return s
      }
    )

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

  // Adds item to currentList
  addItem=()=>{
    this.setState(
      state=>{
        let item=null
        if ((state.listStack == null) || (state.listStack == undefined)) {
          item = this.service.getUserObject()
        }else{
          item=this.service.getCurrentObject(state.listStack.length)
        }

        for(let key in item){
          let l=item[key]
          if(typeof k == "boolean"){
            k=false
          }
          if(typeof k == "string"){
            k=""
          }
        }

        if(state.currentList.length==0){
          item.Id=0
        }else{
          let chooseId=0
          state.currentList.forEach(element => {
            if(element.Id>=chooseId){
              chooseId = element.Id + 1
            }
          });
          
          item.Id = chooseId
        }

        console.log(typeof item.Login)
        
        state.AddedItems.push(item)
        state.IsToAdd=true

        state.currentList.push(item)
        return state
      }
    )
  }   
  
  // Shows add user icon 
  showAddUserIcon = () => {
    return (
      <button className="btn btn-primary" type="submit" onClick={this.addItem}>
        <i className="material-icons">
          perm_identity
          </i>
        AddItem
        </button>
    )
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