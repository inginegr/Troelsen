import React from 'react'

import ClientList from '../ClientList/ClientList.jsx'
import ServerService from '../../Services/ServerService.js'

import '../ManageAdmin/ManageAdmin.css'


export default class ManageAdmin extends React.Component{
    
    state={
        clientsList: null
    }

    service =new ServerService()

    getClientsList=()=>{
        
        const response = this.service.getClientsList(this.props.UserAuth)
        
        response.then(
            (a)=>{
                const {Users} = JSON.parse(a)
                this.setState({clientsList: Users})
            }
        )        
    }

    render(){

        if(this.props.IsAdmin==false){
            return <div className="empty"></div>
        }

        
        return(
            
            <div className="container" id="manage-admin">
                <div className="row justify-content-center align-content-center">
                    <div className="col-10">
                        <ClientList clientsList={this.state.clientsList} />

                        <div id="a-buttons-row" className="container">
                            <div className="row justify-content-between">
                                <div key={0} className="col">
                                    <input className="abr-button" type="button" value="AddClient" onClick={this.getClientsList} />
                                </div>
                                <div key={1} className="col">
                                    <input className="abr-button" type="button" value="DelClient"  />
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