const nodeExternals = require('webpack-node-externals')

module.exports = {
    devtool: 'inline-cheap-module-source-map',
    externals: [nodeExternals()],
    output: {
        devtoolModuleFilenameTemplate: '[absolute-resource-path]',
        devtoolFallbackModuleFilenameTemplate: '[absolute-resource-path]?[hash]'
    }
}