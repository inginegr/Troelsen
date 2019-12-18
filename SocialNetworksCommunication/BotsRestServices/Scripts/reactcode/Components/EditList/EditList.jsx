import React from 'react'

import EditItem from '../EditItem/EditItem.jsx'

import './EditList.css'



const EditList = ({ renderItems, listObjectChanged, getObject, state, listInsertedArray, deleteSomeItem }) => {

  // Render elements to row. Editable and selectable (dropdown)
  const outElements = () => {
    let count = -1
    if ((renderItems == null) || (renderItems == undefined)) {
      return null
    } else {
      return (
        renderItems.map(
          e =>{
            count++
            return (
              <EditItem key={count} objectToRender={e} k={count} listObjectChanged={listObjectChanged} getObject={getObject} state={state} 
              listInsertedArray={listInsertedArray} deleteSomeItem={deleteSomeItem} />
            )
          }
        )
      )
    }
  }

  return (
    <div className="container" id="m-a-client-list">
      <div className="row justify-content-center align-content-center">
        <div className="col-12">
          <table className="table table-dark">
            <tbody>
              {outElements()}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  )
}

export default EditList