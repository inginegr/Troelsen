import React from 'react'

import '../EditItem/EditItem.css'



const EditItem = ({objectToRender, k, listObjectChanged , getObject, listInsertedArray, deleteItem }) => {
  
  // Form massive from object
  const convertObjectToMassive = () => {
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
    const id = e.target.dataset.id
    const ind = e.target.dataset.ind
    const value = e.target.value
    let ob = getObject(id)
    let { massiveOfKeys, massiveToRender } = convertObjectToMassive(ob)
    ob[massiveOfKeys[ind]]=value
    
    listObjectChanged(id, ob)
  }

  // Renders all elements in object
  const renderObject = (k) => {
    const ob = convertObjectToMassive(objectToRender)

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
                    <a className="dropdown-item" href="#" data-id={k} >Включить</a>
                    <a className="dropdown-item" href="#" data-id={k} >Отключить</a>
                  </div>
                </div>
              )
            }else{
              elem = <input type="text" value={el.toString()} onChange={contentChanged} data-ind={count} data-id={k} />              
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

  //Shows edit icon
  const showEditIcon = () => {
    return (
      <th>
        <i className="material-icons active-icon" data-ind={k} onClick={showInsertedList} > build </i>
      </th>
    )
  }
  
  const showInsertedList=(e)=>{
    const id=e.target.dataset.ind
    listInsertedArray(id)
  }

  const doDeleteItem=(e)=>{
    const id=e.target.dataset.ind
    deleteItem(id)
  }
  
  if (objectToRender != null) {
    return (
      <tr key={k}>
        {renderObject(k)}
        {showEditIcon()}
        <th>
          <i className="material-icons active-icon" data-ind={k} onClick={doDeleteItem} > delete_forever </i>
        </th>
      </tr>
    )
  } else {
    return (
      null
    )
  }

    
}

export default EditItem