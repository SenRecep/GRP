import  {useReducer, createContext } from 'react';
import Login from '../Companents/Login';
export const AuthContext=createContext();
const AuthContextProvider =(props)=> {
  const initialState = {
    isAuthenticated: false,
    user: null,
    token: null,
  };
      const Loginreducer = (state, action) => {
        switch (action.type) {
          case "LOGIN":
            localStorage.setItem("user", JSON.stringify(action.payload.user));
            localStorage.setItem("token", JSON.stringify(action.payload.token));
            localStorage.setItem("isAuthenticated", JSON.stringify(true));
            return {
              ...state,
              isAuthenticated: true,
              user: action.payload.user,
              token: action.payload.token
            };
          case "LOGOUT":
            localStorage.clear();
            return {
              ...state,
              isAuthenticated: false,
              user: null
            };
          default:
            return state;
        }
      };
      const [state, dispatch] =useReducer(Loginreducer, initialState);
       console.log(localStorage.getItem('isAuthenticated'))
    return(
      
      <AuthContext.Provider
      value={{
        state,
        dispatch
      }}
    >
     { localStorage.getItem('isAuthenticated')=== null ? <Login /> : props.children}
  </AuthContext.Provider>
    )
   }

   export default AuthContextProvider;