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

        if(this.props.IsAdmin==true){
            return <div className="empty"></div>
        }

        return(
            <div className="container" id="manage-admin">
                <div className="row justify-content-center align-content-center">
                    <div className="col-12">
                        <table className="table table-hover table-dark">
                            <thead>
                                <th scope="col"><p className="text-center">Id</p></th>
                                <th scope="col"><p className="text-center">VK Bot</p></th>
                                <th scope="col"><p className="text-center">Telegram Bot</p></th>
                                <th scope="col"><p className="text-center">Viber Bot</p></th>
                                <th scope="col"><p className="text-center">WhatsApp Bot</p></th>
                                <th scope="col"><p className="text-center">Login</p></th>
                                <th scope="col"><p className="text-center">Password</p></th>
                            </thead>

                            <tbody>
                                {/* {this.Elements()} */}
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        )
    }
}