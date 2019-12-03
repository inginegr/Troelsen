import React from 'react'

import EditItem from '../EditItem/EditItem.jsx'

import './EditList.css'

export default class EditList extends React.Component {

  state = {

  }


  componentDidMount() {

  }



  // Render elements to row. Editable and selectable (dropdown)
  outElements = () => {
    return (
      this.props.editItems.map(
        e => {
          return (
            <EditItem elements={e.elements} />
          )
        }
      )
    )
  }

  render() {

    return (
      <table class="table table-dark">
        <tbody>
          {this.outElements()}
        </tbody>
      </table>
    )
  }
}