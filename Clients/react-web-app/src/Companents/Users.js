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
const Users=(props)=> {
  const [usersData, setusersData] = useState([]);
  useEffect(() => {
    const getUsersData = async () => {
      var userResponse = await rop_axios.get("/company/companies");
      console.log(userResponse); 
        if(userResponse.error!==null)
        {
            setusersData(userResponse.data);
        }
    };

    getUsersData();
}, []);

const refreshUsersData= async ()  => { 
  var userResponse = await rop_axios.get("/company/companies");
  console.log(userResponse); 
    if(userResponse.error!==null)
    {
        setusersData(userResponse.data);
    }
  }
  const redirectEditUser= (id)  => { 
    props.history.push(`/UserEdit/${id}`)
  }
 
 const deleteUser=async (id) => { 
  var userDeleteResponse = await rop_axios.delete(`/company/companies/${id}`);
  console.log(userDeleteResponse)
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
   "name": "userName",
   "label": "Kullanıcı Adı",
   "options": {
     "filter": true,
     "sort": true
     }
  },
   {
   "name": "userMail",
   "label": "E-Mail",
   "options": {
     "filter": true,
     "sort": true
     }
  },
   {
   "name": "userPhone",
   "label": "Yetkili Kişi",
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
              <Button className="action-btn" onClick={() => redirectEditUser(tableMeta.rowData[0])} circular primary icon='edit' />
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
 <ThemeProvider theme={theme} >

   <MUIDataTable title={"Kullanıcı Listesi"} data={usersData} columns={columns} options={options} />
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