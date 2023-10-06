import React, {useState} from 'react';

const DarkModeSwitcherHook = () => {
    const [color, setColor] = useState('white')
    const [fontSize, setFontSize] = useState(17)
    const setDark = ()=> {
        setColor('gray')
    }
    const setLight = () => {
        setColor('white')
    }
    return (
        <div>
            <div
                style={{padding: '10px', backgroundColor: color}}>
                <p style={{color: 'cyan', fontSize: fontSize}}>Hello Elvin</p>

                <button className="btn btn-dark"
                    onClick={setDark}>Dark</button>

                <button className="btn btn-light"
                    onClick={setLight}>Light</button>

                <button className="btn btn-warning"
                        onClick={()=>{
                            setFontSize((s)=> s + 3)
                        }}>+</button>

                <button className="btn btn-warning"
                        onClick={()=>{
                            setFontSize((s)=> s - 3)
                        }}>-</button>

            </div>
        </div>
    );
}

export default DarkModeSwitcherHook;