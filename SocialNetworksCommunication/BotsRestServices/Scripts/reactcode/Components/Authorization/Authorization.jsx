import React from 'react'

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
            <div className="container authorize">
                <div className="row justify-content-center align-items-center">
                    <div className="col-6">
                        <div className="container auth-texts">
                            <div className="row">
                                
                                <div className="col-6">
                                    <input type="text" onGetFocus={this.onGetFocus.bind(this)} onLooseFocus={this.onLooseFocus.bind(this)} />
                                </div>
                                <div className="col-6">
                                    <text>Enter login please</text>
                                </div>

                                <div className="col-6">
                                    <input type="text" onGetFocus={this.onGetFocus.bind(this)} onLooseFocus={this.onLooseFocus.bind(this)} />
                                </div>
                                <div className="col-6">
                                    <text>Enter password please</text>
                                </div>

                            </div>
                        </div>
                        <div className="container auth-buttons">
                            <div className="row justify-content-between">                            
                                <InputElement typeParam="button" valueParam="Remember password" columnClass="col-4-lg a-button-forgot" />
                                <InputElement typeParam="button" valueParam="Registration" columnClass="col-4-lg a-button-registration" />
                                <InputElement typeParam="button" valueParam="Log in" columnClass="col-4-lg a-button-login" />
                            </div>
                        </div>
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