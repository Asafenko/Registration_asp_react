import React, {Component, useEffect, useState} from 'react';





export function ListTradeMark(){
    const [data,setData]= useState('');
    useEffect(()=>{
        async function fetchData(){
            const response = await fetch('TradeMark/list');
            const data = await response.json();
            setData(data);
            console.log('asaf',data);
        }
        fetchData();
    },[]);
    
    return <>
        <GetList data={data}/>
    </>
}

function GetList({data}){
    if (!data) return <div>ERROR</div>;
    return <div> {data.map((el,i) =>
        <fieldset key={i}>
            <a>{el}</a>
        </fieldset>)
    }</div>
}