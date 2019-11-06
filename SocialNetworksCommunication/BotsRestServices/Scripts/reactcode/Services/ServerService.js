//import GlobalProperties from './GlobalProperties'

import "core-js/stable";
import "regenerator-runtime/runtime";

export default class ServerService {

    //global=new GlobalProperties()

    _port = 49492
    _url = "localhost:"
    _controller = "interface"
    _ControllerMethod = "index"
    _MethodParameter = ""
    _login = ""
    _password = ""




    sendRequest = async (addres) => {
        localUrl = this.formUrl(addres)
        const response = fetch(localUrl)

        if (!response.ok) {
            throw new Error("Can not connect to")
        }

        const body = await response.json();
        return body
    }

    formUrl = ({ url = "", port = "", controller = "", method = "", param = "" }) => {

        lUrl = url == "" ? this._url : url
        lPort = port == "" ? this._port : port
        lController = controller == "" ? this._controller : controller
        lMethod = method == "" ? this._ControllerMethod : method
        lParam = param == "" ? this._MethodParameter : param

        return `${lUrl+lPort}/${lController}/${lMethod}/${lParam}`
    }

    // logIn = async ({loginInput, passwordInput}) => {

    //     const res = await this.sendRequest({_ControllerMethod: "Authorize"})
    // }

    testFunc = () => {
        alert("Test")
    }

}
