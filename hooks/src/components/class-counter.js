import React, { useEffect } from 'react';

function FunctionCounter(props) {
    useEffect(() => {
        console.log('Function component Mount');

        return () => {
            console.log('Function component Unmount');
        }
    }, []);

    useEffect(() => {
        console.log('Function component Update');
    }, [props.value]);

    return (
        <p>{props.value}</p>
    );
}

export default FunctionCounter;
