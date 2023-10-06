import React, { useState } from 'react';

function DarkModeSwitcher() {
    const [color, setColor] = useState('white');

    const setDark = () => {
        setColor('black');
    }

    const setLight = () => {
        setColor('white');
    }

    return (
        <div style={{ padding: '10px', backgroundColor: color }}>
            <button onClick={setDark}>Dark</button>
            <button onClick={setLight}>Light</button>
        </div>
    );
}

export default DarkModeSwitcher;
