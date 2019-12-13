import React from 'react'

import '../EditItem/EditItem.css'



const EditItem = ({objectToRender, k}) => {
  
  // Form massive from object
  const formMassive = () => {
    if((objectToRender==null)||(objectToRender==undefined)){
      return null
    }

    let massiveToRender = []
    let massiveOfKeys = []

    for (let key in objectToRender) {
      massiveOfKeys.push(key)
      massiveToRender.push(objectToRender[key])
    }

    return {
      massiveOfKeys,
      massiveToRender
    }
  }

  // Change state 
  const contentChanged=(e)=>{
    const { massiveOfKeys, massiveToRender } = formMassive()
    const ind = e.target.dataset.ind
    const val = e.target.value
    let tempState = objectToRender
    let count = 0
    
    // massiveOfKeys.map(
    //   i=>{        
    //     if(count==ind){
    //       tempState[i]=val
    //       this.setState({renderObject: tempState, IsEdited: true})
    //     }
    //     count++
    //   }
    // )
  }

  // Renders all elements in object
  const renderObject = () => {
    const ob = formMassive(objectToRender)

    console.log(ob)
    console.log(`====================== ${renderObject.Id}`)

    if ((ob == null) || (ob == undefined)) {
      return null
    }

    const { massiveToRender } = ob

    let count = 0
    return (
      massiveToRender.map(
        el => {
          if (!Array.isArray(el)) {
            count++
            let elem = null
            if (count < 2) {
              elem = el.toString()
            } else if ((typeof el) == "boolean") {
              let trueFalse = null
              if(el){
                trueFalse="Включен"
              }else{
                trueFalse="Выключен"
              }
              elem = (
                <div className="dropdown">
                  <a className="btn btn-secondary dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    {trueFalse}
                  </a>
                  <div className="dropdown-menu" aria-labelledby="dropdownMenuLink">
                    <a className="dropdown-item" href="#">Включить</a>
                    <a className="dropdown-item" href="#">Отключить</a>
                  </div>
                </div>
              )
            }else{
              elem = <input type="text" value={el.toString()} onChange={contentChanged} data-ind={count} />              
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


  // //Shows save icon
  // showSaveIcon=()=>{
  //   if(IsNew){
  //     return(
  //       <th>
  //         <i className="material-icons" onClick={()=>this.props.saveNew}> save </i>
  //       </th>
  //     )
  //   }else if(IsEdited){
  //     return(
  //       <th>
  //         <i className="material-icons" onClick={this.props.saveEdited}> save </i>
  //       </th>
  //     )
  //   }
  // }

  // shwoInsertedList=()=>{
  //   this.setState({IsToUpdateObject: true})
  //   this.props.listObjectChanged(Object.assign(renderObject))
  // }

  // //Shows edit icon
  // showEditIcon=()=>{
  //   return(
  //     <th>
  //       <i className="material-icons" onClick={this.shwoInsertedList} > build </i>
  //     </th>
  //   )
  // }


  if (objectToRender != null) {
    return (
      <tr key={k}>
        {renderObject()}
        {/* {this.showSaveIcon()}
          {this.showEditIcon()} */}
      </tr>
    )
  } else {
    return (
      null
    )
  }

    
}

export default EditItem