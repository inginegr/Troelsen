import React from 'react'

import ClientItem from '../ClientItem/ClientItem.jsx'


import '../ClientList/ClientList.css'

export default class ClientList extends React.Component{

    state={
        Users: null
    }

    userData={
        Id: "ID",
        VkBot: "VK Bot",
        TelegramBot: "Telegram Bot",
        ViberBot: "Viber Bot",
        WhatsAppBot: "WhatsApp Bot"
    }

    Elements=()=>{
        this.props.clientsList.map(
            (a)=>{
                return(
                    <ClientItem clientObject={user} />
                )
            }
        )        
    }

    componentDidMount(){
        this.setState({Users: this.props.clientsList})
    }

    render(){

        if(this.props.IsAdmin==false){
            return <div className="empty"></div>
        }

        return(
            <div className="container" id="manage-admin">
                <div className="row justify-content-center align-content-center">
                    <div className="col-6">
                        <table class="table table-hover table-dark">
                            <thead>
                                <th scope="col">Id</th>
                                <th scope="col">VK Bot</th>
                                <th scope="col">Telegram Bot</th>
                                <th scope="col">Viber Bot</th>
                                <th scope="col">WhatsApp Bot</th>
                                <th scope="col">Login</th>
                                <th scope="col">Password</th>
                            </thead>

                            <tbody>
                                {this.Elements()}
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        )
    }
}