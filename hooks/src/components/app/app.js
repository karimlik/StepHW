import React, {useContext, useState} from 'react';
import DarkModeSwitcher from "../dark-mode-switcher";
import DarkModeSwitcherHook from "../dark-mode-switcher-hook";
import User from "../user";
import ClassCounter from "../class-counter";
import HookCounter from "./hook-counter";

// useState()
// useEffect()
// useContext()

const MyContext = React.createContext()
const App = ()=> {
    const [value, setValue] = useState(0);
    const [visible, setVisible] = useState(true)
    if(visible){
        return (
            <div>
                <button onClick={()=>{
                    setValue((v)=>{
                        return v + 1
                    })
                }}>
                    +
                </button>
                <button onClick={()=>{
                    setVisible(false)
                }}>
                    Hide
                </button>
                <ClassCounter value={value}/>
                <HookCounter value={value}/>
            </div>
        )
    }
    else{
        return (
            <button onClick={()=>{
                setVisible(true)
            }}>
                Show
            </button>
        )
    }
    // return (
    //         <div>
    //         //<editor-fold decs = "useContext, useState">
    //             {/*<MyContext.Provider value="Salam Elvin">*/}
    //             {/* <Componen/>*/}
    //             {/* <Other/>*/}
    //             {/*</MyContext.Provider>*/}
    //             {/*<DarkModeSwitcher/>*/}
    //             {/*<DarkModeSwitcherHook/>*/}
    //             {/*<User/>*/}
    //        //</editor-fold>
    //
    //         </div>
    //     );
}

const Componen = ()=>{
    return(
            <MyContext.Consumer>
                {
                    (value)=>{
                        return(
                            <p>{value}</p>
                        )
                    }
                }
            </MyContext.Consumer>
        )
}

const Other = ()=>{
    const value = useContext(MyContext)
    return(
        <h1>{value}</h1>
    )
}
export default App;