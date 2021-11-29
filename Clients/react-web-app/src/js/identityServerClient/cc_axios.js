import axios from 'axios';
import store from './store.js';
import CenteralRequest from './centeralRequest.js';
const axiosApiInstance = axios.create();

axiosApiInstance.interceptors.request.use(
    async config => {
        const token = store.get('webClientToken');
        config.headers = {
            'Authorization': `Bearer ${token.access_token}`,
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
        return config;
    },
    error => {
        Promise.reject(error)
    });

axiosApiInstance.interceptors.response.use((response) => {
    return CenteralRequest.successResponse(response);
}, async function (error) {
    if (error.response.request.status === 401)
        return CenteralRequest.successResponse(error);
});

// module.exports = axiosApiInstance;
export default axiosApiInstance;