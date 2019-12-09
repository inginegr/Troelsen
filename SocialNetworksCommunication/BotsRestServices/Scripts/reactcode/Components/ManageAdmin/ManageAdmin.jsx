import React from 'react'

//import ClientList from '../ClientList/ClientList.jsx'
import ServerService from '../../Services/ServerService.js'

import '../ManageAdmin/ManageAdmin.css'

import EditList from '../EditList/EditList.jsx'

export default class ManageAdmin extends React.Component {

  state = {
    currentList: [],
    listStack: [],
    UserAuth: null
  }

  service = new ServerService()

  getClientsList = () => {
    const response = this.service.getClientsList(this.state.UserAuth)

    response.then(
      (a) => {
        const { Users } = JSON.parse(a)
        this.setState({ currentList: Users })
      }
    )
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

  listObjectChanged=(obj)=>{
    let retObj=null
    for(let key in obj){
      if(Array.isArray(obj[key])){
        retObj=obj[key]    
        this.setState({currentList: retObj})
      }
    }
  }

  listOut = () => {
    if ((this.state.currentList != null)&&(this.state.currentList != undefined)) {
      return <EditList renderItems={this.state.currentList} listObjectChanged={this.listObjectChanged} />
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