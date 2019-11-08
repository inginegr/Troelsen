import CryptoJS from 'crypto-js'


export default class CryptoClass{
    
    

    encryptData=(message, key, iv)=>{
        
        // var message = "some_secret_message";

        // var key = "6Le0DgMTAAAAANokdEEial"; //length=22
        // var iv  = "mHGFxENnZLbienLyANoi.e"; //length=22
        
        // key = CryptoJS.enc.Base64.parse(key); // length=16 bytes
        // //key is now e8b7b40e031300000000da247441226a5d, length=32 (hex encoded)
        // iv = CryptoJS.enc.Base64.parse(iv); // length=16 bytes
        // //iv is now 987185c4436764b6e27a72f2fffffffd, length=32 (hex encoded)
        
        // var cipherData = CryptoJS.AES.encrypt(message, key, { iv: iv });
        
        // var key = "6Le0DgMTAAAAANokdEEial"; //length=22
        // var iv  = "mHGFxENnZLbienLyANoi.e"; //length=25
        
        // key = CryptoJS.enc.Base64.parse(key); // length = 16 bytes
        // //key is now e8b7b40e031300000000da247441226a5d, length=32 (hex encoded)
        // iv = CryptoJS.enc.Base64.parse(iv); // length = 18 bytes
        // //iv is now 987185c4436764b6e27a72f2fffffffded76, length=36 (hex encoded)
        
        // var data = CryptoJS.AES.decrypt(cipherData, key, { iv: iv });
        // console.log(data.toString(CryptoJS.enc.Utf8))
        // console.log("sdfdsf")


        const k = key.toString().replace(/_/g, ' ')      
        const lKey = CryptoJS.enc.Base64.parse(k); 
        
        const i=iv.replace(/_/g,' ')
        const lIV = CryptoJS.enc.Base64.parse(i);
        
        const s = CryptoJS.AES.encrypt(JSON.stringify(message), lKey, { iv: lIV });
        console.log(s.ciphertext)
        const r = CryptoJS.AES.decrypt(s, lKey, { iv: lIV });
        console.log(r.toString(CryptoJS.enc.Utf8))
        return s
    }

    decryptData=(message, key, iv)=>{
        const k = key.toString().replace(/_/g, ' ')      
        const lKey = CryptoJS.enc.Hex.parse(k); 
        
        const i=iv.replace(/_/g,' ')
        const lIV = CryptoJS.enc.Hex.parse(i);
        
        return CryptoJS.AES.decrypt(JSON.stringify(message), lKey, { iv: lIV });
    }
}