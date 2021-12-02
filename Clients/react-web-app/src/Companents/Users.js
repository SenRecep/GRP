import React, {useState, useEffect } from "react"; 
import {
    Button,
    Modal
  } from 'semantic-ui-react'; 
import { ThemeProvider } from "@mui/styles";
import { createTheme, responsiveFontSizes } from '@mui/material/styles';
import MUIDataTable from "mui-datatables";   
import rop_axios from '../js/identityServerClient/rop_axios.js';
import { Link } from "react-router-dom";
import identityServerRequest from '../js/identityServerClient/identityServerRequest.js';
import "../../src/App.css";
const requester = new identityServerRequest(); 
const Users=(props)=> {
  const [usersData, setusersData] = useState([]);
  useEffect(async () => {
    const getUsersData = async () => {
      await requester.connectTokenAsync();
      var userResponse = await requester.getUsers(); 
      setusersData(userResponse.data); 
    };

    await getUsersData();
}, []);

const refreshUsersData= async ()  => { 
  var userResponse = await requester.getUsers();
  console.log(userResponse); 
    if(userResponse.error!==null)
    {
        setusersData(userResponse.data);
    }
  }
  const redirectEditUser= (id)  => { 
    //props.history.push(`/UserEdit/${id}`)
  }
 
 const deleteUser=async (id) => { 
  //var userDeleteResponse = await rop_axios.delete(`/company/companies/${id}`);
  console.log(id)
  refreshUsersData(); 
  }

   
  let theme = createTheme();
      theme = responsiveFontSizes(theme);
  const options = {  
    download: false,
    print: false
  };
  const columns= [
    {
     "name": "id",
     "options": {
     "display": false
     }
   },
   {
    "name": "userName",
    "label": "K.Adı",
    "options": {
      "filter": true,
      "sort": true
      }
   },
   {
    "name": "firstName",
    "label": "Ad",
    "options": {
      "filter": true,
      "sort": true
      }
   },
   
   {
   "name": "lastName",
   "label": "Soyad",
   "options": {
     "filter": true,
     "sort": true
     }
  },
  {
    "name": "identityNumber",
    "label": "TC",
    "options": {
      "filter": true,
      "sort": true
      }
   },
   {
   "name": "address",
   "label": "Adres",
   "options": {
     "filter": true,
     "sort": true
     }
  },
   {
   "name": "phoneNumber",
   "label": "Tel",
   "options": {
     "filter": true,
     "sort": true
     }
  },
  {
    "name": "email",
    "label": "Email",
    "options": {
      "filter": true,
      "sort": true
      }
   },
  {
    name: "Actions",
    label: "Durum",
    options: {
        customBodyRender: (value, tableMeta, updateValue) => { 
            return (
             
              <>
              {/* <Button className="action-btn disable" disable onClick={() => redirectEditUser(tableMeta.rowData[0])} circular primary icon='edit' /> */}
              <Modal trigger={ <Button className="action-btn" circular negative icon='trash' />} header='Dikkat!' content={`${tableMeta.rowData[1]} silmek istediğinizden emin misiniz?`} actions={['İptal', { key: 'done', content: 'Sil', negative: true, onClick:() => deleteUser(tableMeta.rowData[0])}]} /> 
              </>
            )
        }
    }
  }
   
 ];
 return(


<div className="container-fluid">

              
                

               
<div className="row">

    <div className="col-xl-12 col-lg-12">
                    <div className="card shadow mb-4"> 
                      
                        <div className="card-body">
                          <div className="row">
                            
                          <Link className="ui positive button"  to="/UserAdd" style={{marginLeft:'.6em',marginBottom:'.6em'}}>
  <i className="fa fa-plus"></i> Kullanıcı Ekle
 </Link>
                          </div>
                            <div className="row">

 <ThemeProvider theme={theme} >

   <MUIDataTable title={"Kullanıcı Listesi"} data={usersData} columns={columns} options={options} style={{width:'100%'}}/>
</ThemeProvider>
                            </div>
                            
                            


                        </div>
                    </div>
                </div>
    </div>





</div>

  
 )
}
export default Users;