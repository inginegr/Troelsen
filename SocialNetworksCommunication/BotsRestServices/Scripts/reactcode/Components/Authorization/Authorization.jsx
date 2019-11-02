import React from 'react'

import InputWithLabel from '../InputWithLabel/InputWithLabel.jsx'
import ButtonsRow from '../ButtonsRow/ButtonsRow.jsx'

import './Authorization.css'

// const loginString = "Enter login lease"
// const passwordString = "Enter password please"


class Authorization extends React.Component {

    constructor(){
        super()

    }

    onLooseFocus(e){
        // let val = e.target.value
        // if (val == "") {
        //     val = this.state.textValue
        // }
    }

    onGetFocus(e){

        this.setState({ textValue: e.target.value })
        e.target.value = ""
    }

    render() {
        return (
            <div className="container" id="authorization">
                <div className="row justify-content-center align-items-center">
                    <div className="col-6">
                        <InputWithLabel label="Enter login please" inputType="text"/>
                        <InputWithLabel label="Enter password please" inputType="password"/>
                        
                        <ButtonsRow buttons={['Remember password', 'Register', 'Log in']} />
                    </div>
                </div>
            </div>
        )
    }
}

const InputElement = ({ typeParam, valueParam, columnClass, onGetFocus, onLooseFocus }) => {
    return (
        <div className={columnClass}>
            <input type={typeParam} value={valueParam} onFocus={onGetFocus} onfocusout= {onLooseFocus} ></input>
        </div>
    )
}


export default Authorization