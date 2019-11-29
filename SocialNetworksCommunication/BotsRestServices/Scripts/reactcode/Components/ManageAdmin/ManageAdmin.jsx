import React from 'react'

import ClientList from '../ClientList/ClientList.jsx'
import ServerService from '../../Services/ServerService.js'

import '../ManageAdmin/ManageAdmin.css'


export default class ManageAdmin extends React.Component {

  state = {
    clientsList: null,
    UserAuth: null,
    IsNew: []
  }

  service = new ServerService()

  getClientsList = () => {
    const response = this.service.getClientsList(this.state.UserAuth)

    response.then(
      (a) => {
        const { Users } = JSON.parse(a)
        this.setState({ clientsList: Users })
      }
    )
  }

  defineId=()=>{
    let prevId=0
    let curId=1
    this.state.clientsList.map(
      ({Id})=>{
        curId=Id
        if((curId-prevId)>1){
          return (prevId+1)
        }else{
          prevId=curId
        }
      }
    )

    if(this.state.clientsList.length>0){
      return (prevId + 1)      
    }else{
      return 0
    }
  }

  addClient=()=>{
    if(this.state.clientsList==null||this.state.clientsList==undefined){
      console.log(`Cannot add user to empty list`)
      return
    }
    let oldList= Object.assign(this.state.clientsList)
    const id=this.defineId()
    oldList.push(
      {
        Id: id,
        Login: "login",
        Password: "password",
        VkBot: false,
        TelegramBot: false,
        ViberBot: false,
        WhatsAppBot: false
      }
    )

    let newIsNew=Object.assign(this.state.IsNew)   
    newIsNew.push(id)

    this.setState({clientsList: oldList, IsNew: newIsNew})
  }

  saveNew=(client)=>{

    console.log("sad")
    const ans = this.service.addCleinToDb(this.state.UserAuth, {User: client})
    
    ans.then(
      (a)=>{
        const {IsTrue}=JSON.parse(a)
        
        if(IsTrue.IsTrue){
          
          let newArr=[]
          this.state.IsNew.map(
            c=>{
              if(c!=client.Id){
                newArr.push(c)
              }
            }
            )
            console.log(IsTrue.Text)
            this.setState({IsNew: newArr})
          }else{
            console.log(IsTrue.Text)
          }
      }
    ).catch(
      err=>console.log(err)
    )


  }

  componentDidMount() {
    this.setState({ UserAuth: this.props.UserAuth })
  }

  listOut = () => {
    if (this.state.clientsList != null) {
      return <ClientList clientsList={this.state.clientsList} UserAuth={this.state.UserAuth} saveNew={this.saveNew} IsNew={this.state.IsNew} />
    } else {
      return null
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
            <button className="btn btn-primary" type="submit" onClick={this.addClient}>
              <i className="material-icons">
                perm_identity
              </i>
              AddUser
            </button>
            {this.listOut()}
          </div>
        </div>
      </div>
    )
  }
}