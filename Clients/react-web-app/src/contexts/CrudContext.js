import  React, { createContext, useState  } from 'react';
import { v4 as uuidv4 } from 'uuid';
import axios from 'axios';
export const CrudContext=createContext();

const CrudContextProvider =({children})=> {
   const initialData=[  ]// veritabanından gelicek data 
   const [getDataState, setDataState]=useState(initialData)
   const [getColumnState, setColumnState]=useState(initialColumn)

   const addData=(calcData)=>{
    
   }
   const deleteData=(id)=>{
     
   }
   const updateData=(id)=>{
     
   }
   const refreshData=()=>{
     
   }
    return(
      
      <CrudContext.Provider value={{calculateData, addData, deleteData, postData}} >{children} </CrudContext.Provider>
    )
   }

   export default CrudContextProvider;