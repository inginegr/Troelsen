import "core-js/stable";
import "regenerator-runtime/runtime";

import Glob from './GlobalProperties.js'

export default class ServerService {

    //crypto = new CryptoService()

    glob = new Glob()

    _port = 50117
    _url = "http://localhost:"
    _controller = "Interface"
    _ControllerMethod = "Authorize"
    _MethodParameter = ""
    _login = ""
    _password = ""




    sendRequest = async (addres, body) => {

        const response = await fetch( addres, body )

        const myJson = await response.json();

        console.log(myJson)

        return myJson
    }

    formUrl = ({ url = "", port = "", controller = "", method = "", param = "" }) => {

        const lUrl = url == "" ? this._url : url
        const lPort = port == "" ? this._port : port
        const lController = controller == "" ? this._controller : controller
        const lMethod = method == "" ? this._ControllerMethod : method
        const lParam = param == "" ? this._MethodParameter : param

        return `${lUrl + lPort}/${lController}/${lMethod}/${lParam}`
    }

    logIn = async ({ login, password }) => {

        const body = this.formRequest({ login, password })

        return await this.sendRequest(this.formUrl(
            {
                controller: this.glob.InterfaceControllerName,
                method: this.glob.Authorize
            }
        ), body)
    }

    formRequest = ({ dataToSend, login, password }) => {

        return {
            method: "POST",
            headers: {
                'Accept': 'application/json; charset=utf-8',
                'Content-Type': 'application/json;charset=UTF-8'
            },
            body: JSON.stringify(
                {
                    LogPas: {
                        Login: login,
                        Password: password
                    }
                }
            )
        }
    }

    // formLogPasPair = ({ login, password }) => {

    //     const log = this.crypto.encryptData(login, this.getKey(), this.getIV())
    //     const passw = this.crypto.encryptData(password, this.getKey(), this.getIV())

    //     return {
    //         login: log,
    //         password: passw
    //     }
    // }

    formBody = ({ dataToSend, login, password }) => {

        return body = {
            login: login,
            password: password,
            data: dataToSend
        }
    }

    getKey = () => {
        return document.getElementById("key").value
    }

    getIV = () => {
        return document.getElementById("iv").value
    }

    testFunc = () => {
        alert("Test")
    }

}