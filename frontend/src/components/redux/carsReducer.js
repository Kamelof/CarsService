import {carsAPI} from "../../API/api";

const SET_CARS = 'SET_CARS';

let initialState = {
    cars: [],
    isFetching: true,
};

const carsReducer = (state = initialState, action) => {
    switch (action.type) {
        case SET_CARS:{
            return {...state, cars: action.cars}
        }
        default:
            return state;
    }
}

export const setUsers = (cars) => ({type: SET_CARS, cars})

export default carsReducer;