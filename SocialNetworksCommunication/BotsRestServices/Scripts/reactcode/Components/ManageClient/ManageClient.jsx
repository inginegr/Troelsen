import React from 'react'

import ServerService from '../../Services/ServerService.js'

import '../ManageClient/ManageClient.css'

const Bot={
  Botname: "",
  BotStatus: false
}

const BotItem = ({ IsTrue, NameBot, changeState, onRestart }) => {

  const showStatus=()=>{
    if(IsTrue){
      return "Включен"
    }
    else{
      return "Отключен"
    }
  }
  
  const showState=()=>{
    if(IsTrue){
      return <span className="badge badge-pill badge-success">On</span>
    }
    else{
      return <span className="badge badge-pill badge-danger">Off</span>
    }
  }


  return (
    <tr>
      <th scope="row">
        {NameBot}
      </th>
      <td>
        <div className="dropdown">
          <button className="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            {showStatus()}
          </button>
          <div className="dropdown-menu" aria-labelledby="dropdownMenuButton">
            <a className="dropdown-item" href="#" onClick={()=>changeState(true, NameBot)}>Включить</a>
            <a className="dropdown-item" href="#" onClick={()=>changeState(false, NameBot)}>Отключить</a>
          </div>
        </div>
      </td>
      <td>
        <button type="button" className="btn btn-secondary" onClick={()=>onRestart(NameBot)}>Перезагрузить</button>
      </td>
      {/* <td>
        <button type="button" className="btn btn-success" onClick={()=>onApply(NameBot)}>Применить</button>
      </td> */}
      <td>
        {showState()}
      </td>
    </tr>
  )
}


export default class ManageClient extends React.Component {

  state = {
    clientBots: [],
    IsLoading: [],
  }

  service =new ServerService()

  changeState = (state, name) => {

    let newBots = Object.assign(this.state.clientBots)


    newBots.map(
      b => {
        if (b.BotName == name) {
          b.BotStatus = state
        }
      }
    )
    this.setState({ clientBots: newBots })
  }

  // onApplay=(name)=>{

  // }
  
  onRestart=(name)=>{

  }

  renderBots = () => {
    if (this.state.clientBots == null || this.state.clientBots == undefined) {
      console.log("You have no bot")
      return
    }

    let count=0
    return(
      this.state.clientBots.map(
        (b)=>{
          const {BotStatus, BotName}=b
          if(BotStatus){
            return(
              <BotItem key={count++} IsTrue={BotStatus} NameBot={BotName} changeState={(a,b)=>this.changeState(a,b)} onRestart={this.onRestart} />
            )
          }
        }
      )
    )

  }

  loadBots=()=>{ 

    const answer = this.service.getBotsList(this.props.UserAuth, "empty")
    answer.then(
      (e) => {
        const {IsTrue, Bots } = JSON.parse(e)
        if(IsTrue.IsTrue){
          this.setState({ clientBots: Bots })
        }else{
          console.log(IsTrue.Text)
        }
      }
    )
  }

  componentDidMount(){
    this.loadBots()
  }


  render() {

    return (
      <div className="container" id="manafe-client">
        <div className="row justify-content-center align-content-center">
          <div className="col-10">
            <table className="table">
              <thead>
                <tr>
                  <th scope="col">Тип бота</th>
                  <th scope="col">Состояние</th>
                  <th scope="col">Перезагрузить</th>
                  {/* <th scope="col">Применить</th> */}
                  <th scope="col">Статус</th>
                </tr>
              </thead>
              <tbody>
                {this.renderBots()}
              </tbody>
            </table>
          </div>
        </div>
      </div>
    )
  }
}