import React from 'react'

//import ClientList from '../ClientList/ClientList.jsx'
import ServerService from '../../Services/ServerService.js'

import '../ManageAdmin/ManageAdmin.css'

import EditList from '../EditList/EditList.jsx'

export default class ManageAdmin extends React.Component {

  state = {
    listToRender: null,
    UserAuth: null
  }

  service = new ServerService()

  getClientsList = () => {
    const response = this.service.getClientsList(this.state.UserAuth)

    response.then(
      (a) => {
        const { Users } = JSON.parse(a)
        this.setState({ listToRender: Users })
      }
    )
  }

  // Render users massive with data massive
  renderUsers = () => {
    let users = Object.assign(this.state.clientsList)

    userDataList = []
    users.map(
      e => {
        const { Id, Login, Password } = e
        userDataList.push({ IsSelectable: false, currentValue: Id, type: 'text' })
        userDataList.push({ IsSelectable: false, currentValue: Login, type: 'text' })
        userDataList.push({ IsSelectable: false, currentValue: Password, type: 'password' })
      }
    )
    return userDataList
  }

  // Render bots massive with data massive
  renderBots = (UserId) => {
    let users = Object.assign(this.state.clientsList)

    botsDataList = []
    users.map(
      u => {
        if (u.Id == UserId) {
          return(
            u.Bots.map(
              b => {
                const {
                  BotName,
                  BotStatus,
                  Id,
                  UserDataId
                } = b
                botsDataList.push({ IsSelectable: false, currentValue: Id, type: 'text' })
                botsDataList.push({ IsSelectable: false, currentValue: BotName, type: 'text' })
                botsDataList.push({ IsSelectable: true, currentValue: BotStatus, type: 'text', choice: ['On', 'Off'] })
                botsDataList.push({ IsSelectable: false, currentValue: UserDataId, type: 'text' })
              }
            )
          )
        }
      }
    )
  }

  // Render users massive with data massive
  renderBotObjects = (UserId, BotId) => {
    let users = Object.assign(this.state.clientsList)

    botObjectsDataList = []
    users.map(
      u => {
        if (u.Id == UserId) {
          u.Bots.map(
            b => {
              if (b.Id == BotId) {
                return (
                  b.BotObject.map(
                    bo => {
                      const {
                        Id,
                        PathToObject,
                        UserBotId
                      } = bo
                      botObjectsDataList.push({ IsSelectable: false, currentValue: Id, type: 'text' })
                      botObjectsDataList.push({ IsSelectable: false, currentValue: PathToObject, type: 'file' })
                      botObjectsDataList.push({ IsSelectable: true, currentValue: UserBotId, type: 'text' })
                    }
                  )
                )
              }
            }
          )
        }
      }
    )
  }

  renderItems=(type)=>{
    let renderList=null
    if(type==1){
      renderList = this.renderUsers()
    }else if(type==2){
      renderList = this.renderBots()
    }else if(type==3){
      renderList = this.renderBotObjects()
    }



    this.setState({ListToRender: renderList})
  }

  showChange=()=>{
    console.log(this.state.listToRender)
  }

  componentDidMount() {
    this.setState({ UserAuth: this.props.UserAuth })
  }

  listOut = () => {
    if ((this.state.listToRender != null)&&(this.state.listToRender != undefined)) {

      return <EditList renderItems={this.state.listToRender} showChange={this.showChange} />
    } 
  }


  render() {
    return (
      <div className="container" id="manage-admin">
        <div className="row justify-content-center align-content-center">
          <div className="col-10">
            <button className="btn btn-primary" type="submit" onClick={this.getClientsList}>
              <i className="material-icons">
                cloud_download
              </i>
              GetList
            </button>
            <button className="btn btn-primary" type="submit" onClick={this.addClient}>
              <i className="material-icons">
                perm_identity
              </i>
              AddUser
            </button>
            {this.listOut()}
          </div>
        </div>
      </div>
    )
  }
}