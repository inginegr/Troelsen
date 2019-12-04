import React from 'react'

import EditList from '../EditList/EditList.jsx'
import ServerService from '../../Services/ServerService.js'

import './EditItem.css'



export default class EditItem extends React.Component {

  state = {
    // Elements, that rendered
    elements: [
      {
        // Id of element
        id,
        //Is selectable element
        IsSelectable,
        currentValue, //Text that seen 
        choice: [], // Text that inside drop down list
        type, // Type of input element
      }]
  }


  componentDidMount() {
    this.setState({ elements: this.props.elements })
  }

  // Render choice
  renderChoice = (elems, eventChoice, id) => {
    return (
      elems.map(
        e => {
          return (
            <a class="dropdown-item" href="#" onClick={(e) => eventChoice(e, id)}>
              {e}
            </a>
          )
        }
      )
    )
  }

  changeDropDawnText = (st, e) => {
    this.setState(
      (s) => {
        const { elements } = s
        elements.map(
          el => {
            const { id } = el
            if (id == e) {
              el.currentValue = st.target.text
              return s
            }
          }
        )
      }
    )
  }

  // Render elements to row. Editable and selectable (dropdown)
  outElements = () => {
    let count = 0
    const firstElement="row"
    return (
      this.state.elements.map(
        (el) => {
          const { IsSelectable, id, currentValue } = el
          count++
          if(count>1){
            firstElement=""
          }
          if (IsSelectable) {
            const { choice } = el
            return (
              <th key={count} scope={firstElement} >
                <div className="dropdown" >
                  <button className="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    {currentValue}
                  </button>
                  <div className="dropdown-menu" aria-labelledby="dropdownMenuButton">
                    {this.renderChoice(choice, this.changeDropDawnText, id)}
                  </div>
                </div>
              </th>
            )
          } else {
            const { type } = editable
            return (
              <th scope={firstElement}>
                <input key={count} type={type} value={currentValue} />
              </th>
            )
          }
        }
      )
    )
  }

  showSave=()=>{
    if(this.props.IsNew){
      return(
        <th>
          <i class="material-icons" onClick={this.props.doSaveNew}>save</i>
        </th>
      )
    }else if(this.props.IsUpdated){
      return(
        <th>
          <i class="material-icons" onClick={this.props.doUpdateExisting}>save</i>
        </th>
      )
    }
  }

  render() {

    return (
      <tr>
        {this.outElements()}
        {this.showSave()}
        <th>
          <i class="material-icons" onClick={this.props.doShowChildrenList}>build</i>
        </th>
      </tr>
    )
  }
}