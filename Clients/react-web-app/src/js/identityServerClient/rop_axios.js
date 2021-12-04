import axios from 'axios';
import identityServerRequest from './identityServerRequest.js';
import CenteralRequest from './centeralRequest.js'; 
import store from './store.js';
const requester = new identityServerRequest();
const axiosApiInstance = axios.create();

axiosApiInstance.interceptors.request.use(
    async config => {
        const token = store.get('token');
        config.baseURL="http://185.122.202.87:8265/services"
        config.headers = {
            'Authorization': `Bearer ${token.access_token}`,
            'Accept': 'application/json',
            "withCredentials": true,
            "Access-Control-Allow-Methods": "DELETE, POST, GET, OPTIONS",
            "Access-Control-Allow-Headers": "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With",
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
        }
        return config;
    },
    error => {
        return CenteralRequest.errorResponse(error);
    });

axiosApiInstance.interceptors.response.use((response) => {
    return CenteralRequest.successResponse(response);
}, async function (error) {
    const originalRequest = error.config;
    if (error.response.request.status === 401 && !originalRequest._retry) {
        originalRequest._retry = true;
        const token = await requester.refreshTokenAsync();
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + token.access_token;
        return axiosApiInstance(originalRequest);
    }
    return CenteralRequest.errorResponse(error);
});

// module.exports = axiosApiInstance;
export default axiosApiInstance;