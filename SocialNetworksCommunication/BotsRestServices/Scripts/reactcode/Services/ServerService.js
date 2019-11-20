import "core-js/stable";
import "regenerator-runtime/runtime";

import Glob from './GlobalProperties.js'


const UserData = {
  Login: "login",
  Password: "password",
  Id: "id",
  VkBot: "false",
  TelegramBot: "false",
  ViberBot: "false",
  WhatsAppBot: "false"
}

const ServerResponse = {
  Admin: {
    IsUserAdmin: "status"
  },
  Client: {
    IsUserClient: "status"
  },
  Users: [
    { UserData },
    { UserData }
  ],
  IsTrue: {
    IsTrue: "false",
    Text: "text message"
  }
}

const TotalRequest = {
  User: {
    Login: "login",
    Password: "password",
    Id: "id",
    VkBot: "false",
    TelegramBot: "false",
    ViberBot: "false",
    WhatsAppBot: "false"
  },
  CommandType: "command"
}

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

    const response = await fetch(addres, body)

    const myJson = await response.json();

    //console.log(myJson)
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

  //Login to server
  logIn = async ({ Login, Password }) => {

    const body = this.formRequest({ Login, Password })

    const ans = await this.sendRequest(this.formUrl(
      {
        controller: this.glob.InterfaceControllerName,
        method: this.glob.Authorize
      }
    ), body)

    return ans
  }

  formRequest = ({ dataToSend, Login, Password }) => {

    return {
      method: "POST",
      headers: {
        'Accept': 'application/json; charset=utf-8',
        'Content-Type': 'application/json;charset=UTF-8'
      },
      body: JSON.stringify(
        {
          User: {
            Login: Login,
            Password: Password
          },
          DataRequest: dataToSend
        }
      )
    }
  }

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

  //Get list of clients from server
  getClientsList = async ({ Login, Password }) => {


    const body = this.formRequest({ Login, Password })

    const ans = await this.sendRequest(this.formUrl(
      {
        controller: this.glob.AdminController,
        method: this.glob.GetClientsList
      }
    ), body)

    return ans
  }

  // Save changed client data
  saveClientData = async (a, b) => {

    const { Login, Password } = a
    const dataToSend = b
    
    const body = this.formRequest({ dataToSend, Login, Password })

    const ans = await this.sendRequest(this.formUrl(
      {
        controller: this.glob.AdminController,
        method: this.glob.SaveClientData
      }
    ), body)

    return ans
  }

}