import React from 'react'

import ReactDOM from 'react-dom'

import { createStore, bindActionCreators } from 'redux'

import * as actions from './actions'
import reducer from './reducer'
import Counter from './Counter'

let store = createStore(reducer)

const { dispatch } = store

const { inc, dec, rnd } = bindActionCreators(actions, dispatch)

let update = () => {
  ReactDOM.render(
    <Counter
      counter={store.getState()}
      inc={inc}
      dec={dec}
      rnd={
        () => {
          const value = Math.floor(Math.random() * 10)
          rnd(value)
        }
      } />,
    document.getElementById('root')
  )
}

store.subscribe(
  update, 
  console.log(store.getState())
)

update()