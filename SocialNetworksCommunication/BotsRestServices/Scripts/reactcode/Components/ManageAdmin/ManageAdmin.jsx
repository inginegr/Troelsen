import React from 'react'

import ClientList from '../ClientList/ClientList.jsx'
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
        const { Users } = JSON.parse(a)
        this.setState({ clientsList: Users })
      }
    )
  }

  componentDidMount() {
    this.setState({ UserAuth: this.props.UserAuth })
  }

  listOut=()=>{
    if (this.state.clientsList!=null) {
      
      return <ClientList clientsList={this.state.clientsList} UserAuth={this.state.UserAuth} />
    }else{
      return null
    }
  }


  render() {

    return(
      <div className="container" id="manage-admin">
        <div className="row justify-content-center align-content-center">
          <div className="col-12">
            {this.listOut()}
            <div id="a-buttons-row" className="container">
              <div className="row justify-content-between">
                <div key={0} className="col">
                  <input className="abr-button" type="button" value="AddClient" onClick={this.getClientsList} />
                </div>
                <div key={1} className="col">
                  <input className="abr-button" type="button" value="DelClient" />
                </div>
                <div key={2} className="col">
                  <input className="abr-button" type="button" value="EditClient" />
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    )
  }
}