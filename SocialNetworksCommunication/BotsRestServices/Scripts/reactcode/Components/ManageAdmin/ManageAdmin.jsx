import React from 'react'

//import ClientList from '../ClientList/ClientList.jsx'
import ServerService from '../../Services/ServerService.js'

import '../ManageAdmin/ManageAdmin.css'


export default class ManageAdmin extends React.Component {

  state = {
    clientsList: null,
    UserAuth: null
  }

  service = new ServerService()

  getClientsList = () => {
    const response = this.service.getClientsList(this.state.UserAuth)

    response.then(
      (a) => {
        console.log(JSON.parse(a))
        const { Users } = JSON.parse(a)
        this.setState({ clientsList: Users })
      }
    )
  }

  componentDidMount() {
    this.setState({ UserAuth: this.props.UserAuth })
  }

  listOut = () => {
    if (this.state.clientsList != null) {
      return <ClientList clientsList={this.state.clientsList} UserAuth={this.state.UserAuth} />
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