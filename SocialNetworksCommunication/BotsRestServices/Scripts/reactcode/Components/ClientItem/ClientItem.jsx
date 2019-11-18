import React from 'react'

import '../ClientItem/ClientItem.css'

const TrueFalse = ({ IsTrue, IsEdited }) => {

    const sign = (IsTrue) => {
        if (IsTrue == true) {
            return (
                Подключен
            )
        } else {
            return (
                Отключен
            )
        }

    }

    if (IsEdited) {
        return (
            <div className="dropdown">
                <button className="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    {sign({ IsTrue })}
                </button>
                <div className="dropdown-menu" aria-labelledby="dropdownMenuButton">
                    <a className="dropdown-item" href="#">Подключить</a>
                    <a className="dropdown-item" href="#">Отключить</a>
                </div>
            </div>
        )
    } else {
        return (
            sign({ IsTrue })
        )
    }
}

export default class ClientItem extends React.Component{

    state={
        IsEdited: false,
        VkBot: false,
        TelegramBot: false,
        ViberBot: false,
        WhatsAppBot: false
    }

    render(){

        const {
            Id,
            VkBot,
            TelegramBot,
            ViberBot,
            WhatsAppBot,    
        } = this.props

        if(this.props.IsAdmin==false){
            return <div className="empty"></div>
        }

        return (
            <tr>
                <th scope="row">
                    {Id}
                </th>
                <td>
                    <TrueFalse IsTrue={VkBot} IsEdited={this.state.IsEdited} />
                </td>
                <td>
                    <TrueFalse IsTrue={TelegramBot} IsEdited={this.state.IsEdited} />
                </td>
                <td>
                    <TrueFalse IsTrue={ViberBot} IsEdited={this.state.IsEdited} />
                </td>
                <td>
                    <TrueFalse IsTrue={WhatsAppBot} IsEdited={this.state.IsEdited} />
                </td>
            </tr>
        )
    }
}