import React from 'react'

//import ClientList from '../ClientList/ClientList.jsx'
import ServerService from '../../Services/ServerService.js'

import '../ManageAdmin/ManageAdmin.css'

import EditList from '../EditList/EditList.jsx'
import { Object } from 'core-js'

export default class ManageAdmin extends React.Component {

  state = {
    totalClientsList: [], // Total clients list gotten from server. All edit user operations are influence on this object
    currentList: {
      itemsToRender:[],     // Current items to render
      IsToSave: false,             // If made changes in itemsToRender array
      DeletedItems:[],      // Deleted items of itemsToRender array
      NewItems:[]           // Added items to itemsToRender array
    },
    listStack: [],
    UserAuth: null,
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
        this.setState(
          s=>{
            s.currentList.itemsToRender = Users
            s.totalClientsList = Users
            s.currentList.IsToSave = false 
            return s
          }
        )
      }
    )
  }

  // Call if list object is changed
  listObjectChanged = (id, newContent) => {

  }

  // Send object to child component
  getObject=(id)=>{

  }


  componentDidMount() {
    this.setState({ UserAuth: this.props.UserAuth })
  }


  listOut = () => {
    if ((this.state.currentList.itemsToRender != null)&&(this.state.currentList.itemsToRender != undefined)) {
      return <EditList renderItems={this.state.currentList.itemsToRender} listObjectChanged={this.listObjectChanged} getObject={this.getObject} 
      state={this.state} listInsertedArray={this.listInsertedMassive} deleteSomeItem={this.deleteSomeItem} 
      deleteItem={this.deleteItem} />
    }
  }

  // Save change in clients data 
  saveChange=()=>{

  }

  // List inserted massive of selected element
  listInsertedMassive=(ElementId)=>{

  }
  
  
  // Adds item to currentList
  addItem=()=>{
    
  }   
  
  // Delete item from currentList state
  deleteItem=(id)=>{
    
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
  
  
  // Shows save icon if changes made
  showSaveIcon = () => {
    if (this.state.currentList.IsToSave) {
      return (
        <button className="btn btn-primary" type="submit" onClick={this.saveChange} >
          <i className="material-icons"> save </i>
          Save
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