import React from 'react'

import '../EditItem/EditItem.css'



export default class EditItem extends React.Component {
  
  state={
    renderObject: null,
    IsNew: false,
    IsEdited: false
  }
  
  componentDidMount() {
    this.setState({ renderObject: this.props.objectToRender })
  }
  
  componentDidUpdate(){

  }
  // Form massive from object
  formMassive = () => {
    if((this.state.renderObject==null)||(this.state.renderObject==undefined)){
      return null
    }

    let massiveToRender = []
    let massiveOfKeys = []

    for (let key in this.state.renderObject) {
      massiveOfKeys.push(key)
      massiveToRender.push(this.state.renderObject[key])
    }

    let retObj={
      massiveOfKeys,
      massiveToRender
    }

    return retObj
  }

  // Change state 
  contentChanged=(e)=>{
    const {massiveOfKeys, massiveToRender} = this.formMassive()
    const ind=e.target.dataset.ind
    const val=e.target.value
    let tempState=Object.assign(this.state.renderObject)
    let count=0
    
    massiveOfKeys.map(
      i=>{
        if(count==ind){
          tempState[i]=val
          this.setState({renderObject: tempState, IsEdited: true})
        }
        count++
      }
    )

  }

  // Renders all elements in object
  renderObject = () => {
    const ob = this.formMassive(this.state.renderObject)

    if((ob==null)||(ob==undefined)){
      return null
    }

    const {massiveToRender}=ob

    let count = 0
    return (
      massiveToRender.map(
        el => {
          if (!Array.isArray(el)) {
            count++
            let elem=null
            if(count<2){
              elem = el.toString()
            }else{
              elem = <input type="text" defaultValue={el.toString()} onChange={this.contentChanged} data-ind={count} />
            }
            return (
              <th key={count}>
                {elem}
              </th>
            )
          }
        }
      )
    )
  }


  //Shows save icon
  showSaveIcon=()=>{
    if(this.state.IsNew){
      return(
        <th>
          <i className="material-icons" onClick={()=>this.props.saveNew}> save </i>
        </th>
      )
    }else if(this.state.IsEdited){
      return(
        <th>
          <i className="material-icons" onClick={this.props.saveEdited}> save </i>
        </th>
      )
    }
  }

  shwoInsertedList=()=>{
    const retObj = this.props.listObjectChanged(Object.assign(this.state.renderObject))
    console.log(retObj)
  }

  //Shows edit icon
  showEditIcon=()=>{
    return(
      <th>
        <i className="material-icons" onClick={this.shwoInsertedList} > build </i>
      </th>
    )
  }


  render() {
    if(this.state.renderObject!=null){
      return (
        <tr key={this.props.k}>
          {this.renderObject()}
          {this.showSaveIcon()}
          {this.showEditIcon()}
        </tr>
      )
    }else{
      return(
        null
      )
    }
  }
}

{/* <i className="material-icons">
build
</i> */}