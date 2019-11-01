import * as React from 'react';
import InputElement from '../InputElement/InputElement'


import './Authorization.css'

const Input=({elemType, valueParam, className})=>{
    return(
        <input type={elemType} value={valueParam} className={className}  />
    )
}

const InputRow = ({elemType, valueParam, className}) => {
    return (
        <div className="row">
            <div className="col-12">
                <Input className={className} elemType={elemType} valueParam={valueParam} />
            </div>
        </div>
    )
}

const InputCol = ({ elemType, valueParam, className, columnClass }) => {
    return (
        <div className={columnClass}>
            <Input className={className} elemType={elemType} valueParam={valueParam} />
        </div>

    )
}

let Authorization = () => {
    return (
        <div className="Authorization row align-items-center justify-content-center">
            <div className="au-container col-4">
                <div className="container">
                    {/* <InputRow elemType="text" valueParam="Enter login please" className="aac-login"/>
                    <InputRow elemType="password" valueParam="Enter password please" className="aac-password"/> */}
                </div>
                <div className="row">
                {/* <InputCol elemType="button" valueParam="Remember password" className="aac-remember-pas" columnClass="col-3"/>
                <InputCol elemType="button" valueParam="Registration" className="aac-register"  columnClass="col-3"/>
                <InputCol elemType="button" valueParam="Enter" className="aac-enter"  columnClass="col-3"/> */}
                </div>
            </div>
        </div>
        )
}

export default Authorization