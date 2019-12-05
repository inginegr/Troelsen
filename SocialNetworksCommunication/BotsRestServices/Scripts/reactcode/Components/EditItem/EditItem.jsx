import React from 'react'

import '../EditItem/EditItem.css'



export default class EditItem extends React.Component {

  state={
    rebderObject: null
  }

  componentDidMount(){
    this.setState({renderObject: objectToRender})    
  }

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