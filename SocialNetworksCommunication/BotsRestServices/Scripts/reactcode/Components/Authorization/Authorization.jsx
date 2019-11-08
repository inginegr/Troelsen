import React from 'react'

import InputWithLabel from '../InputWithLabel/InputWithLabel.jsx'

import './Authorization.css'

// const loginString = "Enter login lease"
// const passwordString = "Enter password please"


class Authorization extends React.Component {

    loginId = "a-login-text"
    passwordId = "a-password-text"

    state = {
        login: "",
        password: ""
    }

    takeData = (id) => {
        return document.getElementById(id).value
    }

    componentDidMount() {

    }

    onRemind = (e) => {

    }

    onLogin = () => {
        const login = this.takeData(this.loginId)
        const password = this.takeData(this.passwordId)
        this.props.login({login, password})
    }

    onRegister = () => {
        const x=2
    }

    render() {
        return (
            <div className="container" id="authorization">
                <div className="row justify-content-center align-content-center">
                    <div className="col-6">
                        <InputWithLabel inputId={this.loginId} label="Enter login please" inputType="text" />
                        <InputWithLabel inputId={this.passwordId} label="Enter password please" inputType="password" />

                        <div id="a-buttons-row" className="container">
                            <div className="row justify-content-between">
                                <div key={0} className="col">
                                    <input className="abr-button" type="button" value="Remind" onClick={this.onRemind} />
                                </div>
                                <div key={1} className="col">
                                    <input className="abr-button" type="button" value="Register" onClick={this.onRegister} />
                                </div>
                                <div key={2} className="col">
                                    <input className="abr-button" type="button" value="Login" onClick={this.onLogin} />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}

export default Authorization