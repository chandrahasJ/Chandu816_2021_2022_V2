const  path   = require('path');
const CopyPlugin = require('copy-webpack-plugin')

module.exports = {
    context: path.join(__dirname, './'),
    mode: 'development',
    watch: true,
    entry: './src/ts/index.ts',
    devtool:'source-map', // This removed unnesscary logs from console.log
    module: {
      rules: [
        {
          test: /\.ts?$/,
          use: 'ts-loader',
          exclude: /node_modules/,
        },
        {
            test: /\.html$/,
            use: 'html-loader'
        },
        {
            test: /\.css$/,
            use: ['style-loader', 'css-loader']
        }
      ],
    },
    resolve: {
      extensions: ['.tsx', '.ts', '.js'],
    },
    output: {
      filename: 'main.js',
      path: path.resolve(__dirname, 'dist'),
    },
    devServer: {
      static: path.join(__dirname, "dist"),
      compress: true,
      devMiddleware: {
                    publicPath: 'dist',
                    writeToDisk: true
                 },
      port: 4000,
      open: true,      
    },
    plugins:[    
        new CopyPlugin({
            patterns:[
                {from: 'src/*.html',
                    to:'[name].html',
                    force: true,
                }
            ]
        })
    ]
  };
