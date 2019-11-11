import "core-js/stable";
import "regenerator-runtime/runtime";

import Glob from './GlobalProperties.js'

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
        const data = { username: 'example' };
        const localUrl = this.formUrl(addres)
        // const response = await fetch(
        //     'http://localhost:49492/Interface/Authorize',
        //     {
        //         method: 'POST', // или 'PUT'
        //         body: JSON.stringify(data), // данные могут быть 'строкой' или {объектом}!
        //         headers: {
        //           'Content-Type': 'application/json'
        //         }
        //       }
        //  )
        // const response = await fetch('http://localhost:49492/Interface/Authoridfgdfgzed', {
        //     method: 'POST', // или 'PUT'
        //     body: JSON.stringify(data), // данные могут быть 'строкой' или {объектом}!
        //     headers: {
        //       'Content-Type': 'application/json'
        //     }
        //   })

        // if (!response.ok) {
        //     throw new Error("Can not connect to")
        // }

        const myJson = await response.json();
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

        return await this.sendRequest({
            controller: Glob.InterfaceControllerName,
            method: Glob.Authorize
        }, body)
    }

    formRequest = ({ dataToSend, login, password }) => {

        return {
            method: "POST",
            headers: {
                'Accept': 'application/json; charset=utf-8',
                'Content-Type': 'application/json;charset=UTF-8'
              },
              body: JSON.stringify("sadsadsad")
            // login: login,
            // password: password,
            // data: dataToSend
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