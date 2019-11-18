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
        // console.log(this.props)
        if(this.props.IsAdmin==true){
            return <div className="empty"></div>
        }

        return(
            <div className="container" id="manage-admin">
                <div className="row justify-content-center align-content-center">
                    <div className="col-10">
                        <ClientList clientsList={this.props.clientsList} />

                        <div id="a-buttons-row" className="container">
                            <div className="row justify-content-between">
                                <div key={0} className="col">
                                    <input className="abr-button" type="button" value="AddClient"  />
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