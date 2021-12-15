import  React, { createContext, useState  } from 'react';
import { v4 as uuidv4 } from 'uuid';
import axios from 'axios';
import rop_axios from '../js/identityServerClient/rop_axios.js';
import { Redirect, useHistory } from 'react-router';
export const CalculateContext=createContext();

const CalculateContextProvider =({children})=> {
  let history=useHistory();
   const initialData=[  ]
   const [currencySelectInput, setCurrencySelectInput] = useState(null);
   const [disableInputs, setDisableInputs] = useState(false);
   const [calculateData, setCalculateData]=useState(initialData)
   const [ct, setct]=useState(null)
   const [redirectPage, setRedirectPage]=useState(null)
   const addData=(calcData)=>{
     var vol=calcData.x*calcData.y*calcData.z; 
      setct(calcData.currencyType)
     
       setCalculateData(
       [
           ...calculateData,
           {id:uuidv4(),quantity:+calcData.unit,plinthType:+calcData.basetype,width:+calcData.x,length:+calcData.y,height:+calcData.z,paymentType:+calcData.paymentType,vol:vol}
       ]
       )
       
   }
   const deleteData=(id)=>{
     setCalculateData(calculateData.filter(data=>{
        return data.id !==id;
     }))
   }
   const deleteAllData=()=>{
    setCalculateData(initialData)
   }
    const postData= async(compId, payType)=>{ 
      console.log(redirectPage) 
      setRedirectPage(null)
        let postDatas=[];
        postDatas=calculateData.map(item=>{
           var dummy={...item};
           delete dummy.id  
            return dummy
        })
       console.log({
          
        calculateModels:postDatas,
        compnyId:compId,
        currencyType:ct
      });
         
        var calculatorResponse = await rop_axios.post('/watertankcalculator/Plinth',{
          
          calculateModels:postDatas,
          compnyId:compId,
          currencyType:ct
        } );
          if (calculatorResponse.isSuccessful) {
            setRedirectPage(true) 
            history.push({
              pathname: '/GrpSonuc', 
              state: { data:  calculatorResponse.data }
          }); 
          }
          else{
            setRedirectPage(false)
          } 
        
       
    }
    return(
      
      <CalculateContext.Provider value={{calculateData, addData, deleteData, postData, deleteAllData,currencySelectInput,setCurrencySelectInput, disableInputs, setDisableInputs, redirectPage }} >{children} </CalculateContext.Provider>
    )
   }

   export default CalculateContextProvider;