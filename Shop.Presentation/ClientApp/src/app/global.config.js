"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.GlobalConfig = void 0;
var GlobalConfig = /** @class */ (function () {
    function GlobalConfig() {
    }
    //static readonly API_BASE_URL: string = 'https://olympusrecette.azurewebsites.net/api';
    //  static readonly API_BASE_URL: string = 'https://localhost:44377/api';
    GlobalConfig.customersBaseUrl = '/api/CustomersManagement';
    GlobalConfig.paniersBaseUrl = '/api/PaniersManagement';
    GlobalConfig.productsBaseUrl = '/api/ProductsManagement';
    GlobalConfig.shopStoresBaseUrl = '/api/ShopStoreManagement';
    GlobalConfig.usersBaseUrl = '/api/UserManagement';
    return GlobalConfig;
}());
exports.GlobalConfig = GlobalConfig;
//# sourceMappingURL=global.config.js.map