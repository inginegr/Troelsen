import React from 'react'

import EditItem from '../EditItem/EditItem.jsx'

import './EditList.css'



const EditList = ({ renderItems, listObjectChanged, updateState }) => {

  // Render elements to row. Editable and selectable (dropdown)
  const outElements = () => {
    let count = 0
    if ((renderItems == null) || (renderItems == undefined)) {
      return null
    } else {
      return (
        renderItems.map(
          e => {

            return (
              <EditItem key={count++} objectToRender={e} k={count++}  listObjectChanged={listObjectChanged} />
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