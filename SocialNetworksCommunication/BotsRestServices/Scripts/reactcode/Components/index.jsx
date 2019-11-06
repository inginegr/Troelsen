import React from 'react'

import './index.css'

import ServerService from '../Services/ServerService.js'

import Authorization from './Authorization/Authorization.jsx'


class Index extends React.Component {

  service = new ServerService()

  state = {
    IsAuthorized: false,
    IsLoading: false
  }

  login = ({ login, password }) => {
    this.service.sendRequest()
  }

  componentDidMount() {

    // const response = fetch("http://localhost:49492/interface/authorize")
    // console.log(response)

    //   this.setState(
    //     (state, props) => {
    //       return {
    //         IsAuthorized: props.IsAuthorized
    //       }
    //     }
    //   )
  }



  render() {



    return (
      <div className="index">
        <Authorization login={this.login} />
      </div>
    )
  }
}

export default Index