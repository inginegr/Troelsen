import React from 'react'

import './index.css'

import Authorization from './Authorization/Authorization.jsx'


class Index extends React.Component {

    constructor (props) {
        super(props)

      }
  
    // state={
    //     IsAothirized: false
    // }
  
    // componentDidMount(){
    //     this.setState(
    //         (state, props)=>{
    //             return{
    //                 IsAuthorized: props.IsAuthorized
    //             }
    //         }
    //     )
    // }
  

  
    render() {
      return (
          <div>
              <Authorization  />
          </div>
      )
    }
}


export default Index