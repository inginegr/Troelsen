import CryptoService from './CryptoService'

import "core-js/stable";
import "regenerator-runtime/runtime";

export default class ServerService {

    crypto = new CryptoService()

    _port = 49492
    _url = "http://localhost:"
    _controller = "Interface"
    _ControllerMethod = "Authorize"
    _MethodParameter = ""
    _login = ""
    _password = ""




    sendRequest = async (addres, body) => {

        const localUrl = this.formUrl(addres)
        const response = await fetch(localUrl, body)

        alert(body)

        if (!response.ok) {
            throw new Error("Can not connect to")
        }

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

        const body = this.formRequest({login, password})

        const res = await this.sendRequest({ _ControllerMethod: "Authorize" }, body)
    }

    formRequest = ({ dataToSend, login, password }) => {
        
        const encryptedData = this.formBody({dataToSend, login, password})
        
        return {
            method: "POST",
            data: encryptedData
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

        const body = {
            login: login,
            password: password,
            data: dataToSend
        }


        return this.crypto.encryptData(body, this.getKey(), this.getIV())

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