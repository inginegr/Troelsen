import React from 'react'

import './InputWithLabel.css'

const InputWithLabel = ({ inputType, label, key }) => {
    
    return (
        <div className="container" id="input-with-label">
            <div className="row">
                <div className="col-12">
                    <text key={key} id="iwl-label">
                        {label}
                    </text>
                </div>
                <div className="col-12">
                    <input type={inputType} className="iwl-input-type" />
                </div>
            </div>
        </div>
    )
}

export default InputWithLabel