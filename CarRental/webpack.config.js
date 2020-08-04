const path = require("path");
const webpack = require("webpack");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const UglifyJsPlugin = require("uglifyjs-webpack-plugin");
const OptimizeCssAssetsPlugin = require("optimize-css-assets-webpack-plugin");
const { AngularCompilerPlugin } = require("@ngtools/webpack");

module.exports = (env) => {
    const isDevelopmentEnvironment = env.environment === "development";
    const virtualPath = env.virtualPath || "";

    const applicationCommonBundleConfig = {
        mode: isDevelopmentEnvironment ? "development" : "production",
        resolve: { extensions: [".js", ".ts"] },
        module: {
            rules: [
                {
                    test: /\.scss$/,
                    use: [
                        MiniCssExtractPlugin.loader,
                        {
                            loader: "css-loader",
                            options: {
                                sourceMap: isDevelopmentEnvironment
                            }
                        },
                        {
                            loader: "sass-loader",
                            options: {
                                sourceMap: isDevelopmentEnvironment
                            }
                        }]
                },
                {
                    test: /\.(png|woff|woff2|eot|ttf|svg)$/,
                    loader: "url-loader?limit=100000"
                },
                {
                    test: /\.ts$/,
                    use:
                    {
                        loader: "awesome-typescript-loader",
                        options: {
                            configFileName: path.join(__dirname, "tsconfig.json")
                        }
                    }
                }
            ]
        },
        output: {
            publicPath: virtualPath + "/app/",
            path: path.join(__dirname, "./wwwroot/app"),
            filename: "[name].js"
        },
        entry: {
            "bootstrap.custom": "./ClientApp/styles/bootstrap.custom.scss",
            styles: "./ClientApp/styles/main.scss",
            polyfills: "./ClientApp/polyfills.ts"
        },
        devtool: isDevelopmentEnvironment ? "source-map" : "",
        plugins: [
            new MiniCssExtractPlugin("[name].css")
        ],
        optimization: isDevelopmentEnvironment ? {} :
            {
                minimizer: [
                    new UglifyJsPlugin({
                        cache: true,
                        parallel: true
                    }),
                    new OptimizeCssAssetsPlugin({})
                ]
            }
    };

    function getApplicationLocalizedBundleConfig(culture) {
        return {
            mode: isDevelopmentEnvironment ? "development" : "production",
            resolve: { extensions: [".js", ".ts"] },
            module: {
                rules: [
                    {
                        test: /(?:\.ngfactory\.js|\.ngstyle\.js|\.ts)$/,
                        loader: "@ngtools/webpack"
                    }
                ]
            },
            output: {
                publicPath: virtualPath + "/app/",
                path: path.join(__dirname, "./wwwroot/app"),
                filename: `[name].${culture}.js`
            },
            entry: {
                main: "./ClientApp/main.ts"
            },
            devtool: isDevelopmentEnvironment ? "source-map" : "",
            plugins: [
                new webpack.NormalModuleReplacementPlugin(
                    /environment$/,
                    function (resource) {
                        resource.request = resource.request.replace(/environment$/, `environment.${env.environment}`);
                    }),
                new AngularCompilerPlugin({
                    tsConfigPath: path.join(__dirname, "tsconfig.json"),
                    entryModule: path.join(__dirname, "/ClientApp/modules/app.module#AppModule"),
                    mainPath: path.join(__dirname, "/ClientApp/main.ts"),
                    sourceMap: isDevelopmentEnvironment,
                    directTemplateLoading: true,
                    hostReplacementPaths: ((file) => {
                        if (file.match(/\.{culture}\.html$/))
                            return file.replace(/{culture}/, culture);

                        return file;
                    })
                })
            ]
        };
    }

    return [
        applicationCommonBundleConfig,
        getApplicationLocalizedBundleConfig("en-US")
    ];
}
