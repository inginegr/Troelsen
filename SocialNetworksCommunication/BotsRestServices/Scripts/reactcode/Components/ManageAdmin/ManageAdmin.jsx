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
    IsToSave: false,      // If client changed
    DeletedItems:[],      // Deleted items and do not synchronized with server
    ParentItem: null      // Parent item of current list
  }

  service = new ServerService()

  // Get list of clients
  getClientsList = () => {
    const response = this.service.getClientsList(this.state.UserAuth)

    response.then(
      (a) => {
        const { Users } = JSON.parse(a)
        this.setState({ currentList: Users, IsUserList: true, totalClientsList: Users, IsToSave: false })
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
            if(el['Id']==id){
              isFound=true
            }
            if(!isFound){
              count++
            }
          }
        )
        state.currentList[count]=newContent

        if(state.listStack.length<1){
          state.totalClientsList = state.currentList
        }else{
          state.totalClientsList = state.listStack[0]
        }

        if(isFound){
          state.IsToSave=true
        }
        return state
      }
    )
  }

  // Send object to child component
  getObject=(id)=>{
    for (let index = 0; index < this.state.currentList.length; index++) {
      if(this.state.currentList[index]['Id']==id){
        return Object.assign({}, this.state.currentList[index]) 
      }
    }
    return Object.assign(null)
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
      return <EditList renderItems={this.state.currentList} listObjectChanged={this.listObjectChanged} getObject={this.getObject} 
      state={this.state} listInsertedArray={this.listInsertedMassive} deleteSomeItem={this.deleteSomeItem} 
      deleteItem={this.deleteItem} />
    }
  }

  // Save change in clients data 
  saveChange=()=>{
    if (this.state.IsToDelete) {
      let ans = this.service.deleteClientsFromDb(this.state.UserAuth, this.state.DeletedItems)
      ans.then(
        ret => {
          const retObj=JSON.parse(ret)
          if (retObj.IsTrue.IsTrue) {
            this.setState({ IsToDelete: false, DeletedItems: [] })
          }
        }
      )
    }
    if(this.state.IsToSave){
      this.service.saveClientsChange(this.state.UserAuth, this.state.totalClientsList)
    }
    if(this.state.IsToAdd){
      
    }
  }

  // Save change all in objects
  doSave = () => {
    console.log("do save")
  }

  // List inserted massive of selected element
  listInsertedMassive=(ElementId)=>{
    this.setState(
      s=>{
        let currentElement=null 
        for (let index = 0; index < s.currentList.length; index++) {
          if(s.currentList[index]['Id']==ElementId){
            currentElement=s.currentList[index]
          }
        }

        for(let key in currentElement){
          if(Array.isArray(currentElement[key])){
            s.listStack.push(s.currentList)
            s.currentList=currentElement[key]
          }
        }

        s.ParentItem = currentElement

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
          state.DeletedItems.forEach(element => {
            if(element.Id>=chooseId){
              chooseId = element.Id + 1
            }
          });
          item.Id = chooseId
        }

        if (state.listStack.length > 0) {
          const intKey = this.service.searchSecondInt(item)
          item[intKey]=state.ParentItem.Id
        }
        // else{
        //   state.totalClientsList.push(item)
        // }
        
        // state.AddedItems.push(item)
        // state.IsToAdd=true

        state.currentList.push(item)
        return state
      }
    )
  }   

  // Delete item from currentList state
  deleteItem=(id)=>{

    let newCurrentList=[]
    let newDeletedItems=[]
    let newTotalClientList=[]
        
    for (let index = 0; index < this.state.currentList.length; index++) {
      if (this.state.currentList[index]['Id'] == id) {
        newDeletedItems.push(this.state.currentList[index])
        newCurrentList = this.service.remArEl(this.state.currentList, index)
      }
    }
    if (this.state.listStack.length < 1) {
      newTotalClientList = newCurrentList
    } else {
      newTotalClientList = this.state.listStack[0]
    }
    
    this.setState({currentList: newCurrentList, totalClientsList:newTotalClientList, DeletedItems:newDeletedItems})
  }

  // Updates object, that send to server
  updateOdkectWithUsers=()=>{
    
    
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