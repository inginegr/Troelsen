import React from 'react';
import Spinner from './components/loadingspinner'
import Error from './components/errorexception'
import ErrorBoundry from './components/errorboundry/errorboundry';


const App = () => {
  return (
    <div>
      <ErrorBoundry>
        <Spinner/>
      </ErrorBoundry>
    </div>
  )
}

export default App;