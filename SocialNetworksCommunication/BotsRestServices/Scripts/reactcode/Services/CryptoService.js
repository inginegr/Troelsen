import CryptoJS from 'crypto-js'


export default class CryptoClass{
    
    

    encryptData=(message, key, iv)=>{
        const lKey = CryptoJS.enc.Hex.parse(key); 
        const lIV = CryptoJS.enc.Hex.parse(iv);
        
        console.log(`${key}  ${iv}`)
        
        return CryptoJS.AES.encrypt(message, lKey, lIV)
    }

    decryptData=(message, key, iv)=>{
        const lKey = CryptoJS.enc.Hex.parse(key);
        const lIV = CryptoJS.enc.Hex.parse(iv);
        return CryptoJS.AES.encrypt(message, lKey, lIV);
    }
}