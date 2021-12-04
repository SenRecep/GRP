import React, {useContext, useEffect, useState} from "react"; 
import identityServerRequest from '../js/identityServerClient/identityServerRequest';
import   {ApiError, separators}  from '../js/identityServerClient/centeralRequest'; 
var requester= new identityServerRequest();
const Login=  (props) => {  
    useEffect(() => {
        document.body.classList.add('bg-gradient-primary'); 
      },[]) 
  const initialState = {
    userName: "",
    password: "",
    isSubmitting: false,
    errorMessage: null
  };
  const [data, setData] = useState(initialState); 
  const handleInputChange = event => {
    setData({
      ...data,
      [event.target.name]: event.target.value
    });
  };
 

  const handleFormSubmit = async (event) => {
    event.preventDefault();
   
    let errors=null;
    const signInResponse =  await requester.signInAsync({
        username:data.userName,
        password:data.password
    });
    console.log(signInResponse);
    if (signInResponse.isSuccessful) {
       const userInfoResponse= await requester.getUserInfoAsync();
      if (userInfoResponse.isSuccessful) {
    console.log(userInfoResponse);

        // setData({
        //   ...data,
        //   isSubmitting: true,
        //   errorMessage: null
        // }); 
          //anasayfaya git
          // if (data.isSubmitting)
          // {
            // props.history.push(`/`)
            
            window.location.reload();
          // }
      }
      else{
           requester.signOutAsync();
         errors= ApiError.getErrors(userInfoResponse.error,separators.HTML);
      }
    }
    else
       errors="KULLANICI ADI VE PAROLA HATALI!!";
    

    if (errors) {
      setData({
        ...data,
        isSubmitting: false,
        errorMessage: errors
      });
      console.log(errors)
    }


  };
 return(
    <div className="container">
 
    <div className="row justify-content-center">

        <div className="col-xl-10 col-lg-12 col-md-9">

            <div className="card o-hidden border-0 shadow-lg my-5">
                <div className="card-body p-0"> 
                    <div className="row">
                        <div className="col-lg-6 d-none d-lg-block bg-login-image"></div>
                        <div className="col-lg-6">
                            <div className="p-5" style={{marginBottom: '30%'}}>
                                <div className="text-center">
                                    <h1 className="h4 text-gray-900 mb-4">Aksu Panel Giriş</h1>
                                    {data.errorMessage && (
                                         <span className="form-error">{data.errorMessage}</span>
                                     )}
                                </div>
                                <form className="user" onSubmit={ handleFormSubmit}>
                                    <div className="form-group">
                                        <input type="text"  className="form-control form-control-user" onChange={handleInputChange}
                                            id="userName" name="userName"   placeholder="Kullanıcı Adı"/>
                                    </div>
                                    <div className="form-group">
                                        <input type="password" className="form-control form-control-user" onChange={handleInputChange}
                                           name="password" id="password" placeholder="Şifre"/>
                                    </div>
                                    

                                    <button  className="btn btn-primary btn-user btn-block" disabled={data.isSubmitting}>
                                        {data.isSubmitting ? (
                                            "Yükleniyor..."
                                        ) : (
                                            "Giriş"
                                        )}
                                    </button>
                                    
                                   
                                </form> 
                                <div className="text-center">
                                    <a className="small" href="forgot-password.html">Şifremi Unuttum?</a>
                                </div>
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </div>

</div>
 )
}
export default Login;