import React from 'react'

import './InputWithLabel.css'

const InputWithLabel = ({ inputType, label, key, inputId }) => {
    
    return (
        <div className="container" id="input-with-label">
            <div className="row">
                <div className="col-12">
                    <label key={key} id="iwl-label">
                        {label}
                    </label>
                </div>
                <div className="col-12">
                    <input id={inputId} type={inputType} className="iwl-input-type" />
                </div>
            </div>
        </div>
    )
}

export default InputWithLabel