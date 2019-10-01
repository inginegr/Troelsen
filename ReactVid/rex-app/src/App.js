import React from 'react';
import Spinner from './components/loadingspinner'
import Error from './components/errorexception'


const App = () => {
  return (
    <div>
      <Spinner />
      <Error/>
    </div>
  )
}

export default App;