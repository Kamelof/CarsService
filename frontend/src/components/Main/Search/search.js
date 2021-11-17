import React from "react";
import style from "./search.module.css"

const Search = (props) => {
    return(
        <div>
            <div className={style.allBorder}>
                <div className={style.allBorder}>
                    <div>
                        <input type="text" placeholder="Search"/>
                    </div>
                    <div>
                        <button>Search</button>
                    </div>
                </div>
                <div className={style.allBorder}>
                    <div>
                        Text
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Search;