import React from 'react'

import './loadingspinner.css'

const loadingspinner = ({label='asdasd'}) => {

  return (
    <div className="d-flex justify-content-center align-items-center">
      <div className="spinner-border text-danger" role="status">
        <span className="sr-only">Loading...</span>
      </div>
    </div>
  )
}

export default loadingspinner