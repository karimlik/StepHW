import React, {useState} from 'react';

const User = () => {
    const [name, setName] = useState("Nadir")
    const [surname, setSurname] = useState("Zamanov")

    const updateName =()=>{
        setName("Ali")
    }
    return (
        <div>
            <button onClick={()=>{
                updateName();
                console.log(name, surname);
            }}>Change</button>
        </div>
    );
};

export default User;