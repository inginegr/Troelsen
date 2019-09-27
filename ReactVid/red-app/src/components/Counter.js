import React from 'react'
import { connect } from 'react-redux'
import {BindActionCreators, bindActionCreators} from 'redux'
import * as actions from '../actions'

let Counter = ({ counter, inc, dec, rnd }) => {



  return (
    <div>
      <h2 id="counter">
        {counter}
      </h2>
      <button id="inc" onClick={inc}>inc</button>
      <button id="dec" onClick={dec}>dec</button>
      <button id="rnd" onClick={rnd}>rnd</button>
    </div>
  )
}

const mapStateToProps = (state) => {
  return {
    counter: state
  }
}

const mapDispatchToProps = (dispatch) => {
  const {inc, dec, rnd} = bindActionCreators(actions, dispatch)
  return {
    inc: () => inc(),
    dec: () => dec(),
    rnd: () => {
      const value = Math.floor(Math.random() * 10)
      rnd(value)
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(Counter)