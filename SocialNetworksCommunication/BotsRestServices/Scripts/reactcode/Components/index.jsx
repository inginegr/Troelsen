import React from 'react'

import './index.css'

import ServerService from '../Services/ServerService.jsx'

import Authorization from './Authorization/Authorization.jsx'


class Index extends React.Component {

  server 
  
  constructor(props) {
    super(props)

    this.server = new ServerService()

    this.state = {
      IaAuthorized: false
    }

  }

  componentDidMount() {

    // const response = fetch("http://localhost:49492/interface/authorize")
    // console.log(response)

    this.setState(
      (state, props) => {
        return {
          IsAuthorized: props.IsAuthorized
        }
      }
    )
  }



  render() {



    return (
      <div className="index">
        <Authorization />
      </div>
    )
  }
}


export default Index