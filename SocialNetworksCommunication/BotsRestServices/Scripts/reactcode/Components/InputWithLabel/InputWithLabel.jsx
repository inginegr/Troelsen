import React from 'react'

import './InputWithLabel.css'

const InputWithLabel = ({ inputType, label }) => {
    return (
        <div className="container" id="input-with-label">
            <div className="row">
                <div className="col-12">
                    <text id="iwl-label">
                        {label}
                    </text>
                </div>
                <div className="col-12">
                    <input id="iwl-input-type" type={inputType} />
                </div>
            </div>
        </div>
    )
}

export default InputWithLabel