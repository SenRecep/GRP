import axios from 'axios';
import querystring from 'querystring'
import clientInfo from './clientInfo.js';
import store from './store.js';
import CenteralRequest,{ApiResponse} from './centeralRequest.js';
const axiosConfig = {
    baseURL: clientInfo.BaseUrl,
    timeout: 30000,
    headers: {
        'Content-Type': 'application/x-www-form-urlencoded'
    }
};

class identityServerRequest {
    setBearerToken(access_token) {
        var config = {
            ...axiosConfig,
        }
        config.headers["Authorization"] = `Bearer ${access_token}`
        return config;
    }
    async signInAsync({
        username,
        password
    }) {
        const requestData = {
            client_id: clientInfo.WebClientForUser.ClientId,
            client_secret: clientInfo.WebClientForUser.ClientSecret,
            grant_type: clientInfo.GrantType.ResourceOwnerPasswordCredential,
            username: username,
            password: password
        };
        return CenteralRequest.request(async () => {
            const result = await axios.post('/connect/token', querystring.stringify(requestData), axiosConfig);
            store.set("token", result.data);
            return result;
        });
    }
    async getUserInfoAsync() {
        const currentToken = store.get("token").access_token;
        const config = this.setBearerToken(currentToken);
        return CenteralRequest.request(async () => {
            var result = await axios.get('/connect/userinfo', config);
            store.set("userInfo", result.data);
            return result;
        });
    }
    async connectTokenAsync() {
        const currentToken = store.get("webClientToken");
        if (currentToken)
            return ApiResponse.success(currentToken);

        const requestData = {
            client_id: clientInfo.WebClient.ClientId,
            client_secret: clientInfo.WebClient.ClientSecret,
            grant_type: clientInfo.GrantType.ClientCredential
        };
        return CenteralRequest.request(async () => {
            const result = await axios.post('/connect/token', querystring.stringify(requestData), axiosConfig);
            store.set("webClientToken", result.data);
            return result;
        });
    }
    async refreshTokenAsync() {
        const currentToken = store.get("token").refresh_token;
        const requestData = {
            client_id: clientInfo.WebClientForUser.ClientId,
            client_secret: clientInfo.WebClientForUser.ClientSecret,
            grant_type: clientInfo.GrantType.ClientCredential,
            refresh_token: currentToken
        };
        return CenteralRequest.request(async () => {
            const result = await axios.post('/connect/token', querystring.stringify(requestData), axiosConfig);
            store.set("token", result.data);
            return result;
        });
    }

    async revokeRefreshTokenAsync() {
        console.log( store.get("token"));
        const currentToken = store.get("token").refresh_token;
        const requestData = {
            client_id: clientInfo.WebClientForUser.ClientId,
            client_secret: clientInfo.WebClientForUser.ClientSecret,
            refresh_token: currentToken,
            token_typ_hint: clientInfo.GrantType.RefreshTokenCredential
        };
        return CenteralRequest.request(async () => {
            const result = await axios.post('/connect/token', querystring.stringify(requestData), axiosConfig);
            store.set("token", result.data);
            return result;
        });
    }
    async signUpAsync(model) {
        const currentToken = store.get("webClientToken").access_token;
        const config = this.setBearerToken(currentToken);
        config.headers["Content-Type"] = "application/json";
        return CenteralRequest.request(async () => {
            var result = await axios.post('/api/user/signup', model, config);
            return result;
        });
    }
    async getUsers() {
        const currentToken = store.get("webClientToken").access_token;
        const config = this.setBearerToken(currentToken);
        config.headers["Content-Type"] = "application/json";
        return CenteralRequest.request(async () => {
            var result = await axios.get('/api/user/getusers', config);
            return result;
        });
    }
    async signOutAsync() {
       // await this.revokeRefreshTokenAsync();
        store.remove('token');
        store.remove('userInfo');
    }
}

// module.exports = identityServerRequest;
export default identityServerRequest;