import "core-js/stable";
import "regenerator-runtime/runtime";

import Glob from './GlobalProperties.js'
import { async } from "regenerator-runtime/runtime";


const UserData = {
  Login: "login",
  Password: "password",
  Id: "id",
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

const dataToSend = {
  User:{
    Login: '',
    Password: '',
    Id: 0,
    VkBot: false,
    TelegramBot: false,
    ViberBot: false,
    WhatsAppBot: false
  },
  ClientCommand: "command"
}

export default class ServerService {

  //crypto = new CryptoService()

  glob = new Glob()

  _port = 50117
  _url = "http://localhost:"
  // _port = ""
  // _url = "https://fbszk.icu"
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
    const User={Login: Login, Password: Password}
    const body = this.formRequest( User)
    
    const ans = await this.sendRequest(this.formUrl(
      {
        controller: this.glob.InterfaceControllerName,
        method: this.glob.Authorize
      }
      ), body)
      
      return ans
    }
    
    formRequest = (a, b=null) => {
    let dts=dataToSend
      if(b!=null){
        dts=b
    }
    // console.log(a)
    return {
      method: "POST",
      headers: {
        'Accept': 'application/json; charset=utf-8',
        'Content-Type': 'application/json;charset=UTF-8'
      },
      body: JSON.stringify(
        {
          User: a,
          DataRequest: dts
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

    const User={Login: Login, Password: Password}

    const body = this.formRequest(User)

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

    const User={Login: a.Login, Password: a.Password}

    const dataToSend = b
    
    const body = this.formRequest(User, dataToSend)

    const ans = await this.sendRequest(this.formUrl(
      {
        controller: this.glob.AdminController,
        method: this.glob.SaveClientData
      }
    ), body)

    return ans
  }

  // Delete client from db
  deleteClientFromDb = async (a, b) => {

    const { Login, Password } = a
    const User={Login: Login, Password: Password}

    const dataSend = dataToSend

    dataSend.User=b.User

    // console.log(User)
    // console.log(dataSend)
    
    const body = this.formRequest(User, dataSend)

    //console.log(body)

    const ans = await this.sendRequest(this.formUrl(
      {
        controller: this.glob.AdminController,
        method: this.glob.DeleteClientFromDb
      }
    ), body)

    return ans
  }

  //Adds client to db
  addCleinToDb= async (a,b)=>{
    if(a==null||a==undefined||b==null||b==undefined){
      console.log(`Cannot save empty user`)
      return
    }
    
    const { Login, Password } = a
    const User={Login: Login, Password: Password}
    const dataToSend = b
    
    const body = this.formRequest(User, dataToSend)

    const ans = await this.sendRequest(this.formUrl(
      {
        controller: this.glob.AdminController,
        method: this.glob.AddClient
      }
    ), body)

    return ans
  }
  
  //Adds client to db
  getBotsList= async (a,b)=>{
    if(a==null||a==undefined||b==null||b==undefined){
      console.log(`Cannot get bots list of empty user`)
      return
    }
    const {Login, Password} = a
    const  User  = {Login: Login, Password: Password}

    // console.log(a)

    const body = this.formRequest(a)

    const ans = await this.sendRequest(this.formUrl(
      {
        controller: this.glob.ClientController,
        method: this.glob.GetBots
      }
    ), body)

    return ans
  }

  //Return user any object
  getUserObject=()=>{
    let result = null                
    result = Object.assign({}, UserAny)
    return result
  }

  // Return type of element, to add to currentList
  // depth - depth to find element
  getCurrentObject=(depth)=>{
    
    let currentObject=UserAny

    while (depth!=0) {
      depth--
      for(let key in currentObject){
        if (Array.isArray(currentObject[key])) {
          currentObject=currentObject[key][0]
        }
      }
    }
    return currentObject
  }

}



let UserAny = {

  Bots: [

    {
      BotObject: [
        {
          Id: 0,
          PathToObject: "",
          UserBotId: 0
        }
      ],
      Id: 0,
      BotName: "",
      BotStatus: false,
      UserDataId: 0
    }
  ],
  Id: 0,
  Login: "",
  Password: ""
}