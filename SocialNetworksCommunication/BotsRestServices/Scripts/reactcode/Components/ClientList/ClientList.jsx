import React from 'react'

//import ClientItem from '../ClientItem/ClientItem.jsx'
import ServerService from '../../Services/ServerService.js'
import EditList from '../EditList/EditList.jsx'

import '../ClientList/ClientList.css'

export default class ClientList extends React.Component {

  componentDidMount() {

  }

  render() {

    return (
      <div className="container" id="m-a-client-list">
        <div className="row justify-content-center align-content-center">
          <div className="col-12">
            <EditList clientList={this.props.clientList} />
          </div>
        </div>
      </div>
    )
  }
}