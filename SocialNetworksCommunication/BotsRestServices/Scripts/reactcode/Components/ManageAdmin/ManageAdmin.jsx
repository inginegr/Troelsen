import React from 'react'

import ClientList from '../ClientList/ClientList.jsx'

import '../ManageAdmin/ManageAdmin.css'


export default class ManageAdmin extends React.Component{

    state={
        IdSelected: null,
        VkBotStatus: false,
        TelegramBotStatus: false,
        ViberBotStatus: false,
        WhatsAppBotStatus: false
    }



    render(){

        if(this.props.IsAdmin==false){
            return <div className="empty"></div>
        }

        return(
            <div className="container" id="manage-admin">
                <div className="row justify-content-center align-content-center">
                    <div className="col-6">
                        <ClientList clientsList={this.props.clientsList} />

                        <div id="a-buttons-row" className="container">
                            <div className="row justify-content-between">
                                <div key={0} className="col">
                                    <input className="abr-button" type="button" value="AddClient" onClick={this.onRemind} />
                                </div>
                                <div key={1} className="col">
                                    <input className="abr-button" type="button" value="DelClient" onClick={this.onRegister} />
                                </div>
                                <div key={2} className="col">
                                    <input className="abr-button" type="button" value="EditClient" onClick={this.onLogin} />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}