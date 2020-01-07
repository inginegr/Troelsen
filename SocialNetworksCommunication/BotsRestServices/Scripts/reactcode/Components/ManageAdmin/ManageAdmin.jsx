import React from 'react'

//import ClientList from '../ClientList/ClientList.jsx'
import ServerService from '../../Services/ServerService.js'

import '../ManageAdmin/ManageAdmin.css'

import EditList from '../EditList/EditList.jsx'
import { Object } from 'core-js'

export default class ManageAdmin extends React.Component {

  state = {
    totalClientsList: [],   // Total clients list gotten from server. All edit user operations are influence on this object
    currentList: {
      itemsToRender:[],     // Current items to render
      DeletedItems:[],      // Deleted items of itemsToRender array
      NewItems:[],          // Added items to itemsToRender array
      ItemsToSave: []       // Items, that changed
    },
    listStack: [],
    UserAuth: null,
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
            s.currentList.DeletedItems = []
            s.currentList.ItemsToSave = []
            s.currentList.NewItems = []

            s.listStack=[]
            
            return s
          }
        )
      }
    )
  }

  // Call if list object is changed
  listObjectChanged = (id, newContent) => {
    this.setState(
      s => {
        let { itemsToRender, ItemsToSave } = s.currentList
        itemsToRender.map(
          el => {
            if (el.Id == id) {
              el = newContent
            }
          }
        )

        let flg = true
        ItemsToSave.map(
          el => {
            if (el.Id == id) {
              // console.log(newContent)
              flg = false
              el = newContent
            }
          }
          )
          if (flg) {
          // console.log(newContent)
          ItemsToSave.push(newContent)
        }

        return s
      }
    )
  }

  // Send object to child component
  getObject=(id)=>{
    let retOb=null
    this.state.currentList.itemsToRender.map(      
      el=>{
        if(el.Id==id){
          retOb=el
        }
      }
    )
    return retOb
  }


  componentDidMount() {
    this.setState({ UserAuth: this.props.UserAuth })
  }


  listOut = () => {
    // console.log(this.state.currentList)
    if ((this.state.currentList.itemsToRender != null)&&(this.state.currentList.itemsToRender != undefined)) {
      return <EditList renderItems={this.state.currentList.itemsToRender} listObjectChanged={this.listObjectChanged} 
      getObject={this.getObject} 
      state={this.state} listInsertedArray={this.listInsertedMassive} deleteSomeItem={this.deleteSomeItem} 
      deleteItem={this.deleteItem} />
    }
  }

  // Form object to edit
  formSaveObjects=(newObjects)=>{
    let clients=[]
    let bots=[]
    let botObjects=[]

    if(this.state.listStack.length<1){
      clients=newObjects
    }else if(this.state.listStack.length==1){
      bots=newObjects
    }else if(this.state.listStack.length==2){
      botObjects=newObjects
    }
    return {clients, bots, botObjects}
  }


  // Save change in clients data 
  saveChange=()=>{
    const {DeletedItems, NewItems, ItemsToSave} = this.state.currentList
    if(NewItems.length>0){

      let {clients, bots, botObjects} = this.formSaveObjects(NewItems)

      const answer = this.service.addRowsToDb(this.state.UserAuth, clients, bots, botObjects)
      
      answer.then(
        ansJson=>{
          let ans=JSON.parse(ansJson)
            if(ans.IsTrue.IsTrue){
              this.setState(arrayToSet=[])
            }else{
              console.log(`Cannot save rows. The exception on server is: ${ans.IsTrue.Text}`)
            }
        }
      )
    }

    if(ItemsToSave.length>0){

      let {clients, bots, botObjects} = this.formSaveObjects(ItemsToSave)

      const answer = this.service.editRowsInDb(this.state.UserAuth, clients, bots, botObjects)
      
      answer.then(
        ansJson=>{
          let ans=JSON.parse(ansJson)
          if(ans.IsTrue.IsTrue){
            this.setState(
              s=>{
                s.currentList.ItemsToSave=[]
                return s
              }
            )
          }else{
            console.log(`Cannot save rows. The exception on server is: ${ans.IsTrue.Text}`)
          }
        }
      )
    }

    if(DeletedItems.length>0){

      let {clients, bots, botObjects} = this.formSaveObjects(DeletedItems)

      const answer = this.service.deleteRowsInDb(this.state.UserAuth, clients, bots, botObjects)
      
      answer.then(
        ansJson=>{
          let ans=JSON.parse(ansJson)
          if(ans.IsTrue.IsTrue){
            this.setState(
              s=>{
                s.currentList.DeletedItems=[]
                return s
              }
            )
          }else{
            console.log(`Cannot delete rows. The exception on server is: ${ans.IsTrue.Text}`)
          }
        }
      )
    }
  }

  // List inserted massive of selected element
  listInsertedMassive=(ElementId)=>{
    let ans = null
    let flg=0
    console.log(this.state)
    if(this.state.listStack.length<1){
      ans=this.service.getBotsList(this.state.UserAuth, ElementId)
      flg=1
    }else if(this.state.listStack.length==1){
      ans=this.service.getBotObjectsList(this.state.UserAuth, ElementId)
      flg=2
    }else{
      return null
    }

    ans.then(
      answer => {
        this.setState(
          s => {
            let items=null
            if(flg==1){
              let {Bots}=JSON.parse(answer)
              items=Bots
            }else if(flg==2){
              let {BotObjects}=JSON.parse(answer)
              items=BotObjects
            }
            
            let { listStack, currentList } = s
            listStack.push(currentList)
            currentList.itemsToRender = items
            currentList.IsToSave = false
            currentList.DeletedItems = []
            currentList.NewItems = []
            return s
          }
        )
      }
    )
  }
  
  // Define id of added element
  defineId=()=>{
    let newId=0;
    if(this.state.currentList.itemsToRender!=null&&this.state.currentList.itemsToRender!=undefined){
      this.state.currentList.itemsToRender.map(
        el=>{
          if(newId<=el.Id){
            newId=el.Id+1
          }
        }
      )
      this.state.currentList.NewItems.map(
        el=>{
          if(newId<=el.Id){
            newId=el.Id+1
          }
        }
      )
      this.state.currentList.DeletedItems.map(
        el=>{
          if(newId<=el.Id){
            newId=el.Id+1
          }
        }
      )
    }
    return newId
  }

  // Adds item to currentList
  addItem=()=>{
    
    let newEl=this.service.getCurrentObject(this.state.listStack.length)

    newEl.Id=this.defineId()

    this.setState(
      s=>{
        let {itemsToRender, NewItems} =s.currentList

        itemsToRender.push(newEl)
        NewItems.push(newEl)                
        return s
      }
    )
  }
  
  // Delete item from currentList state
  deleteItem = (id) => {

    this.setState(
      s => {
        let { itemsToRender, NewItems, DeletedItems } = s.currentList

        let count = 0
        let flgNewElem=false
        NewItems.map(
          item => {
            if (item.Id == id) {
              NewItems.splice(count, 1)
              flgNewElem=true
            }
            count++
          }
        )

        count = 0
        itemsToRender.map(
          item => {
            if (item.Id == id) {
              if(!flgNewElem){
                DeletedItems.push(item)
              }
              itemsToRender.splice(count, 1)
            }
            count++
          }
        )
        return s
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
    
  // Shows save icon if changes made
  showSaveIcon = () => {
    if (this.state.currentList.ItemsToSave.length>0 ||
      this.state.currentList.DeletedItems.length>0 ||
      this.state.currentList.NewItems.length>0) {
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