const path = require('path');

module.exports = {
  entry: './App.jsx',
  output: {
    path: path.resolve(__dirname, 'bundles'),
    filename: 'appbundle.js'
  },
  mode: 'development',
  module:{
    rules: [
        { test: /\.(js|jsx)$/, exclude: /node_modules/, loader: "babel-loader" },
        {
          test: /\.css$/,
          use:["style-loader", "css-loader"]
        }
      ]
  }
};