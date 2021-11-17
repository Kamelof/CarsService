import React from "react";
import style from "./header.module.css"

const Header = (props) => {
    return (
            <div className={style.header}>
                <div className={style.logo + ' ' + style.allBorder} >LOGO</div>
                <div className={style.menuBlock + ' ' + style.allBorder}>
                    <select name="Menu" id="">
                        <option value="">Menu</option>
                        <option value="">Sale</option>
                        <option value="">News</option>
                    </select>
                </div>

                <div className={style.buttonBlock + ' ' + style.allBorder}>
                    <div className={style.allBorder}>
                        <button>One more button</button>
                    </div>
                    <div className={style.signInBlock + ' ' + style.allBorder}>
                        <button className={style.signIn}>sign in</button>
                    </div>
                    <div className={style.signUpBlock + ' ' + style.allBorder}>
                        <button className={style.signUp}>sign up</button>
                    </div>
                </div>
            </div>
    )
}

export default Header;