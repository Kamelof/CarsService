import React from "react";
import style from "./cars.module.css"

const Cars = (props) => {
    return(
        <div className={style.carsBlock + ' ' + style.allBorder}>
            <div className={style.cars}>
                <div className={style.car}>Car1</div>
                <div className={style.car}>Car2</div>
                <div className={style.car}>Car3</div>
                <div className={style.car}>Car4</div>
                <div className={style.car}>Car5</div>
                <div className={style.car}>Car6</div>
                <div className={style.car}>Car7</div>
                <div className={style.car}>Car8</div>
                <div className={style.car}>Car9</div>

            </div>
        </div>
    )
}

export default Cars;