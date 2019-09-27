import React from 'react'

import ReactDOM from 'react-dom'

import { createStore } from 'redux'

import reducer from './reducer'
import App from './components/App'

import {Provider} from 'react-redux'


let store = createStore(reducer)

const { dispatch } = store

ReactDOM.render(
  <Provider store={store}>
    <App />
  </Provider>
  ,
  document.getElementById('root')
)