import React from 'react'

import EditItems from '../EditItems/EditItems.jsx'

import './EditList.css'

export default class EditList extends React.Component {

  state = {
    elements: [],
    stack:[]
  }

  componentDidMount() {
    console.log(this.props.clientsList)
    this.setState({elements: this.props.clientsList})
  }

  // Gets and shows new list
  showNewList=()=>{
    let list = this.props.showNewList()

    this.setState(
      (e)=>{
        let {elements, stack}=e
        stack.push(elements)
        elements=list
        return e
      }
    )
  }

  //Shows previous list items
  showPrevList=()=>{
    this.setState(
      (e)=>{
        let {elements, stack}=e
        elements = stack.pop()
        return e
      }
    )
  }

  // Render elements to row. Editable and selectable (dropdown)
  outElements = () => {
    let count = 0
    if((this.state.elements==null)||(this.state.elements==undefined)){
      return null
    }else{
      return (
        this.state.elements.map(
          e => {
            count++
            return (
              <EditItems key={count} elements={e} />
            )
          }
        )
      )
    }
  }

  render() {
    return (
      <div className="container" id="m-a-client-list">
        <div className="row justify-content-center align-content-center">
          <div className="col-12">
            <table className="table table-dark">
              <tbody>
                {this.outElements()}
              </tbody>
            </table>
          </div>
        </div>
      </div>
    )
  }
}