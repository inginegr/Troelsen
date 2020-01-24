import "core-js/stable";
import "regenerator-runtime/runtime";

import Glob from './GlobalProperties.js'
import { async } from "regenerator-runtime/runtime";


const UserData = {
  Id: Number,
  Login: "login",
  Password: "password",
  Bots: [BotRequest]
}

const BotObjectRequest = {
  Id: Number,
  PathToObject: "",
  UserBotId: Number
}

const BotRequest = {
  Id: Number,
  FriendlyBotName: "",
  BasicBotName: "",
  UniqueBotNumber: Number,
  BotStatus: false,
  BotObject: [BotObjectRequest],
  UserDataId: Number
}

const BotServiceData = {
  url: "",
  max_connections: Number,
  allowed_updates: []
}

const UserRequest = {
  User: UserData,
  ClientsList: [UserData],
  BotsList: [BotRequest],
  BotObjectsList: [BotObjectRequest],
  ServiceBot: BotServiceData
}



// const dataToSend = {
//   User: UserRequest,
//   UserList: [UserRequest]
// }

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
    const User = { Login: Login, Password: Password }
    const body = this.formRequest(User)

    const ans = await this.sendRequest(this.formUrl(
      {
        controller: this.glob.InterfaceControllerName,
        method: this.glob.Authorize
      }
    ), body)

    return ans
  }

  formRequest = (a, b = null) => {

    let dts = [UserRequest]

    // console.log(b)
    if (b != null) {
      dts = b
    }
    // const UserRequest={
    //   User: UserData,
    //   ClientsList: [UserData],
    //   BotsList: [BotRequest],
    //   BotObjectsList: [BotObjectRequest]
    // }
    return {
      method: "POST",
      headers: {
        'Accept': 'application/json; charset=utf-8',
        'Content-Type': 'application/json;charset=UTF-8'
      },

      body: JSON.stringify(
        {
          User: a,
          ClientsList: dts.ClientsList,
          BotsList: dts.BotsList,
          BotObjectsList: dts.BotObjectsList
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

    const User = { Login: Login, Password: Password }

    const body = this.formRequest(User)

    const ans = await this.sendRequest(this.formUrl(
      {
        controller: this.glob.AdminController,
        method: this.glob.GetClientsList
      }
    ), body)

    return ans
  }

  //Get list of user bots
  getBotsList = async (a, id) => {
    if (a == null || a == undefined || id == null || id == undefined) {
      console.log(`Cannot get bots list of empty user`)
      return
    }

    const parentUser = a
    parentUser.Id = id
    const body = this.formRequest(parentUser)

    const ans = await this.sendRequest(this.formUrl(
      {
        controller: this.glob.AdminController,
        method: this.glob.GetBots
      }
    ), body)

    return ans
  }

  // Get list of bot objects
  getBotObjectsList = async (a, id) => {
    if (a == null || a == undefined || id == null || id == undefined) {
      console.log(`Cannot get bots list of empty user`)
      return
    }

    const parentUser = a
    parentUser.Id = id
    const body = this.formRequest(parentUser)

    const ans = await this.sendRequest(this.formUrl(
      {
        controller: this.glob.AdminController,
        method: this.glob.GetBotObjects
      }
    ), body)

    return ans
  }

  // Send request to save changes, that made by admin in clients data
  saveClientsChange = async (a, b) => {

    const User = { Login: a.Login, Password: a.Password }

    const body = this.formRequest(User, b)

    const ans = await this.sendRequest(this.formUrl(
      {
        controller: this.glob.AdminController,
        method: this.glob.SaveClientData
      }
    ), body)

    return ans
  }

  // Delete client from db
  deleteClientsFromDb = async (a, b) => {

    const { Login, Password } = a
    const User = { Login: Login, Password: Password }

    const body = this.formRequest(User, b)

    const ans = await this.sendRequest(this.formUrl(
      {
        controller: this.glob.AdminController,
        method: this.glob.DeleteClientsFromDb
      }
    ), body)

    return ans
  }

  //Adds client to db
  addRowsToDb = async (a, clients = [], bots = [], botobj = []) => {
    if (a == null || a == undefined) {
      console.log(`Cannot send empty row to server`)
      return
    }

    let req = Object.assign({}, UserRequest)

    req.User = UserData
      req.ClientsList = clients
      req.BotsList = bots
      req.BotObjectsList = botobj

    const { Login, Password } = a
    const User = { Login: Login, Password: Password }
    const dataToSend = req

    const body = this.formRequest(User, dataToSend)

    const ans = await this.sendRequest(this.formUrl(
      {
        controller: this.glob.AdminController,
        method: this.glob.AddRows
      }
    ), body)

    return ans
  }

  //Edit rows in db
  editRowsInDb = async (a, clients = [], bots = [], botobj = []) => {
    if (a == null || a == undefined) {
      console.log(`Cannot send empty row to server`)
      return
    }

    let req = Object.assign({}, UserRequest)

    req.User = UserData
      req.ClientsList = clients
      req.BotsList = bots
      req.BotObjectsList = botobj

    const { Login, Password } = a
    const User = { Login: Login, Password: Password }
    const dataToSend = req

    const body = this.formRequest(User, dataToSend)

    const ans = await this.sendRequest(this.formUrl(
      {
        controller: this.glob.AdminController,
        method: this.glob.EditRows
      }
    ), body)

    return ans
  }

  //Delete rows from db
  deleteRowsInDb = async (a, clients = [], bots = [], botobj = []) => {
    if (a == null || a == undefined) {
      console.log(`Cannot send empty row to server`)
      return
    }

    let req = Object.assign({}, UserRequest)

    req.User = UserData
      req.ClientsList = clients
      req.BotsList = bots
      req.BotObjectsList = botobj

    const { Login, Password } = a
    const User = { Login: Login, Password: Password }
    const dataToSend = req

    const body = this.formRequest(User, dataToSend)

    const ans = await this.sendRequest(this.formUrl(
      {
        controller: this.glob.AdminController,
        method: this.glob.DeleteRows
      }
    ), body)

    return ans
  }

  // Start bot on the server
  startBot = async (a, bots = []) => {

    if (a == null || a == undefined) {
      console.log(`Cannot the request is empty`)
      return
    } else if (bots == null || bots == undefined) {
      console.log("Cannot start empty bots massive")
      return
    }

    let req = Object.assign({}, UserRequest)

    req.User = UserData
    req.BotsList = bots

    const { Login, Password } = a
    const User = { Login: Login, Password: Password }
    const dataToSend = req

    const body = this.formRequest(User, dataToSend)

    const ans = await this.sendRequest(this.formUrl(
      {
        controller: this.glob.BotServiceController,
        method: this.glob.StartBot
      }
    ), body)

    return ans
  }


  // Make all massives by empty inside gotten object
  makeArraysEmpty = (ob) => {
    for (let key in ob) {
      if (Array.isArray(ob[key])) {
        ob[key] = []
      }
    }
    return ob
  }

  //Return user any object
  getUserObjects = () => {
    let result = null
    result = Object.assign({}, this.makeArraysEmpty(UserAny))
    return result
  }

  // Return type of element, to add to currentList
  // depth - depth to find element
  getCurrentObject = (depth) => {

    let retObj = null
    if (depth == 0) {
      retObj = UserData
    } else if (depth == 1) {
      retObj = BotRequest
    } else if (depth == 2) {
      retObj = BotObjectRequest
    }

    return Object.assign({}, retObj)
  }

  // Search second int value in the щиоусе and return its key
  searchSecondInt = (mas) => {
    let countInt = 2
    for (let key in mas) {
      if (typeof mas[key] == "number") {
        countInt--
      }
      if (countInt == 0) {
        return key
      }
    }
    return null
  }

  // Remove element from massive return new array without signed element
  remArEl = (arr, id) => {
    let newArr = []
    for (let index = 0; index < arr.length; index++) {
      if (index != id) {
        newArr.push(arr[index])
      }
    }
    return newArr
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