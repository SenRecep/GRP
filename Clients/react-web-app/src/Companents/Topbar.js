import React from 'react';
import identityServerRequest from '../js/identityServerClient/identityServerRequest';
import store from '../js/identityServerClient/store';
import { useHistory } from "react-router";
var requester= new identityServerRequest();
function Topbar() {
   const history = useHistory();
 return(
    <nav className="navbar navbar-expand navbar-light bg-white topbar mb-4 static-top shadow"> 
         <ul className="navbar-nav ml-auto">
            {localStorage.getItem('userInfo')  && (
            <li>
               {store.get('userInfo').name}
                <a className="mr-2 d-none d-lg-inline text-gray-600" onClick={ async () =>{
                     await requester.signOutAsync();
                     // history.push({
                     //    pathname:  "/Login" 
                     // });
                     window.location.reload();
                } }>Çıkış  <i className="fas fa-sign-out-alt fa-sm fa-fw mr-2"></i> </a></li>
            )}
        </ul>
    </nav>
 )
}
export default Topbar;