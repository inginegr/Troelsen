class ServerService {

    _port
    _url
    _controller
    _login
    constructor(){
        this._port=49492
        this._url="localhost:"
        this._login="authorize"
        this._controller="interface"
    }

    async sendRequest() {
        const response = fetch("http://localhost:49492/interface/authorize")

        // if (!response.ok) {
        //     throw new Error("Can not connect to")
        // }

        const body= await response.json();
        console.log(body)
        return body
    }

    formUrl(url, prefix) {
        return url + this._port + "/" + this._controller + "/" + prefix
    }

    async logIn() {
        const res = await this.sendRequest()
    }

    testFunc(){
        alert("Test")
    }
}


export default ServerService