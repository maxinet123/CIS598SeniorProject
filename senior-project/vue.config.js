const webpack = require('webpack');

module.exports = {
  publicPath: process.env.VUE_APP_PUBLIC_PATH,
  transpileDependencies: ["vuetify"],
  configureWebpack: {
    optimization: {
      slitChunks: {
        maxSize: 500000,
      },
    },
    plugins: [
      new webpack.ContextReplacementPlugin(/moment[\/\\]locale$/, /en/),
    ]
  }
};
