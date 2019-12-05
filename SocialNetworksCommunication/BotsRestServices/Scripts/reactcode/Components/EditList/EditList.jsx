import React from 'react'

import './EditList.css'

class EditItem extends React.Component {



  // const renderElements=()=>{
  //   return(
  //     this.props.listToRender.map(
  //       l=>{
  //         return <td>l</td>
  //       }
  //     )

  //   )
  // }

  // const  showSave=()=>{
  //   if(this.props.IsNew){
  //     return(
  //       <th>
  //         <i className="material-icons" onClick={this.props.doSaveNew}>save</i>
  //       </th>
  //     )
  //   }else if(this.props.IsUpdated){
  //     return(
  //       <th>
  //         <i className="material-icons" onClick={this.props.doUpdateExisting}>save</i>
  //       </th>
  //     )
  //   }
  // }

  // Form massive from object
  formMassive = (ob) => {
    let retMas = []
    for (let key in ob) {
      console.log(key)
      retMas.push(ob[key])
    }
    return retMas
  }

  renderObject = () => {
    const renderMassive = this.formMassive(this.props.objectToRender)

    let count = 0
    return (
      renderMassive.map(
        el => {
          if (!Array.isArray(el)) {
            return (
              <th key={count++}>
                <input type="text" defaultValue={el.toString()} onChange={()=>this.props.showChange()} />
              </th>
            )
          }
        }
      )
    )
  }

  render() {
    return (
      <tr key={this.props.k}>
        {this.renderObject()}
      </tr>
    )
  }
}


const EditList = ({ renderItems, showChange }) => {
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
              <EditItem objectToRender={e} k={count++} showChange={showChange}   />
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