import React, {useEffect} from 'react';

const HookCounter = ({value}) => {
    // useEffect(() => {
    //     console.log('constructor')
    // }, []);
    useEffect(() => {
        console.log('Update')
        return () => console.log("Clear")
    }, [value]);
    return (
        <p>{value}</p>
    );
};

export default HookCounter;