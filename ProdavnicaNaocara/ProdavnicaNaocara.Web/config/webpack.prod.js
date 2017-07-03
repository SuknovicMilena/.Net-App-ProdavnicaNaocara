const webpack = require('webpack');
const webpackMerge = require('webpack-merge');
const ManifestPlugin = require('webpack-manifest-plugin');

const ENV = process.env.NODE_ENV = process.env.ENV = 'production';
const commonConfig = require('./webpack.common.js');
const helpers = require('./helpers');

module.exports = webpackMerge(commonConfig, {
  devtool: 'source-map',

  output: {
    path: helpers.root('dist'),
    publicPath: '/',
    filename: '[name].[chunkhash:8].js',
    chunkFilename: '[id].[chunkhash:8].chunk.js'
  },

  module: {
    rules: []
  },

  plugins: [
    new webpack.NoEmitOnErrorsPlugin(),
    new webpack.optimize.UglifyJsPlugin({
      compress: { warnings: false },
      comments: false,
      sourceMap: false
    }),
    new webpack.DefinePlugin({
      'process.env': {
        'ENV': JSON.stringify(ENV)
      }
    }),
    new ManifestPlugin()
  ]
});
