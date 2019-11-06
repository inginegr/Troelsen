import CryptoJS from 'crypto-js'


class CryptoClass{
    
    

    encryptData=(message, key, iv)=>{
        lKey = CryptoJS.enc.Hex.parse(key); 
        lIV = CryptoJS.enc.Hex.parse(iv); 
        return CryptoJS.AES.encrypt("Message", lKey, lIV);
    }

    decryptData=(message, key, iv)=>{
        lKey = CryptoJS.enc.Hex.parse(key); 
        lIV = CryptoJS.enc.Hex.parse(iv); 
        return CryptoJS.AES.encrypt("Message", lKey, lIV);
    }
}