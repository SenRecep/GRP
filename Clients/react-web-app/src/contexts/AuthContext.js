import {useState, createContext } from 'react';
export const AuthContext=createContext();
const AuthContextProvider =()=> {
    const [userRequest, setUserRequest] = useState({
        isAuthenticated: false,
        token: null,
        user: null,
      });
    const check=()=>{

    }
    const setToken=()=>{

    }
    return(
    <></>
    )
   }

   export default AuthContextProvider;