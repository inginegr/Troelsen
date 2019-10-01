import React from 'react'

import './errorexception.css'

const ErrorException = ({errorMessage = 'Some error occured'}) => {

  return (
    <div id='error' className="alert alert-danger" role="alert">
      {errorMessage}
    </div>
  )
}

export default ErrorException