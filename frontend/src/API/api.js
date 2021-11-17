import * as axios from "axios";


const instance = axios.create({
    baseURL: '',
    headers: {}
});

export const carsAPI = {
    getUsers() {
        return instance.get(`cars`)
            .then(response => {
                return response.data;
            });
    }
}