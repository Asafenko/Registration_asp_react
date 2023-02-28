import React, {Component, useState} from 'react';



function SmartInput({text,onEdit}){
    return <input id="search" type={"text"} value={text} onInput={event=>onEdit(event.target.value)}/>
}


async function register(){
    const element = document.getElementById("search");
    const response = await fetch('TradeMark/registration?name=' + element.value);
    const data = await response.text();
    alert(data);
}


export function Registration(){
    const [text,setText] = useState('');
    return <>
        <div>
            Enter Name:
            <SmartInput text={text} onEdit={x=>(setText(x))}/> 
            <button className="btn btn-primary"  onClick={register} >ADD</button>
        </div>
    </>
}