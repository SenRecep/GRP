import  React, { createContext, useState  } from 'react';
import { v4 as uuidv4 } from 'uuid';
import axios from 'axios';
import rop_axios from '../js/identityServerClient/rop_axios.js';
import { Redirect } from 'react-router';
export const CalculateContext=createContext();

const CalculateContextProvider =({children})=> {
    const initialData=[  ]
   const [calculateData, setCalculateData]=useState(initialData)

   const addData=(calcData)=>{
       setCalculateData([
           ...calculateData,
           {id:uuidv4(),unit:calcData.unit,basetype:calcData.basetype,x:calcData.x,y:calcData.y,z:calcData.z,paymenttype:calcData.paymenttype}
       ])
   }
   const deleteData=(id)=>{
     setCalculateData(calculateData.filter(data=>{
        return data.id !==id;
     }))
   }
    const postData= async()=>{ 
        let postDatas=[];
        postDatas=calculateData.map(item=>{
            delete item.id
            return item
        })
        var calculatorResponse = await rop_axios.post('/watertankcalculator/Plinth', {
          calculateModels:postDatas
          });
        
          if (calculatorResponse.error===null) {
            <Redirect to={{pathName: "/GrpSonuc", state:{data:calculatorResponse.data} }} />   
          } 
        
       
    }
    return(
      
      <CalculateContext.Provider value={{calculateData, addData, deleteData, postData}} >{children} </CalculateContext.Provider>
    )
   }

   export default CalculateContextProvider;