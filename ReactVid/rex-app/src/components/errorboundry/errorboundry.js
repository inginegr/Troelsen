import React, {Component} from 'react'
// import ReactDOM from 'react-dom'
import './errorboundry.css'

import Error from '../errorexception'

class ErrorBoundry extends Component{
    state={
        hasError: false
    }

    componentDidCatch(){
        this.setState({hasError: true})
    }

    render(){
        if(this.state.hasError){
            return <Error/>
        }else{
            return this.props.children
        }
    }
}

export default ErrorBoundry 