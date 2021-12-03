import  React, { createContext, useState  } from 'react';
import { v4 as uuidv4 } from 'uuid';
import axios from 'axios';
import rop_axios from '../js/identityServerClient/rop_axios.js';
import { Redirect, useHistory } from 'react-router';
export const CalculateContext=createContext();

const CalculateContextProvider =({children})=> {
  let history=useHistory();
    const initialData=[  ]
   const [calculateData, setCalculateData]=useState(initialData)
   const [ct, setct]=useState()
   const addData=(calcData)=>{
     var vol=calcData.x*calcData.y*calcData.z; 
      setct(!calcData.currencyType)
      console.log(ct)
       setCalculateData([
           ...calculateData,
           {id:uuidv4(),quantity:+calcData.unit,plinthType:+calcData.basetype,width:+calcData.x,length:+calcData.y,height:+calcData.z,paymentType:+calcData.paymentType,vol:vol}
       ])
   }
   const deleteData=(id)=>{
     setCalculateData(calculateData.filter(data=>{
        return data.id !==id;
     }))
   }
    const postData= async(compId, payType)=>{ 
        let postDatas=[];
        postDatas=calculateData.map(item=>{
           var dummy={...item};
           delete dummy.id  
            return dummy
        })
       console.log({
          
        calculateModels:postDatas,
        compnyId:compId,
        currencyType:+ct
      });
         
        var calculatorResponse = await rop_axios.post('/watertankcalculator/Plinth',{
          
          calculateModels:postDatas,
          compnyId:compId,
          currencyType:+ct
        } );
          if (calculatorResponse.isSuccessful) {
            history.push({
              pathname: '/GrpSonuc', 
              state: { data:  calculatorResponse.data }
          });
          } 
        
       
    }
    return(
      
      <CalculateContext.Provider value={{calculateData, addData, deleteData, postData}} >{children} </CalculateContext.Provider>
    )
   }

   export default CalculateContextProvider;