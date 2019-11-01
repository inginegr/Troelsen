import * as React from 'react'

import './InputElement.css'

const InputElement=({elemType, valueParam, className})=>{
    return(
        <input type={elemType} value={valueParam} className={className}  />
    )
}

export default InputElement