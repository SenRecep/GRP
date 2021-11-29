import React, {useState, useContext, useEffect } from "react"; 
import {
    Button,
    Modal
  } from 'semantic-ui-react'; 
import { ThemeProvider } from "@mui/styles";
import { createTheme, responsiveFontSizes } from '@mui/material/styles';
import MUIDataTable from "mui-datatables";
import axios from 'axios'; 
import rop_axios from '../js/identityServerClient/rop_axios.js';
import { Link } from "react-router-dom";
const FirmList=(props)=> {
  const [firmData, setFirmData] = useState([]);
  useEffect(() => {
    const getFirmData = async () => {
        var companyResponse = await rop_axios.get("/company/companies");
        console.log(companyResponse);
        setFirmData(companyResponse.data);
        
    };

    getFirmData();
}, []);

const refreshData= async ()  => { 
  var companyResponse = await rop_axios.get("/company/companies"); 
  setFirmData(companyResponse.data);
  }
  const redirectEditFirm= (id)  => { 
     props.history.push(`/FirmEdit/${id}`)
  }
 
 const deleteFirm= async (id) => { 
  var companyDeleteResponse = await rop_axios.delete(`/company/companies/${id}`);
  console.log(companyDeleteResponse)
    refreshData(); 
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
   "name": "title",
   "label": "Firma Ünvanı",
   "options": {
     "filter": true,
     "sort": true
     }
  },
   {
   "name": "currentAccountCode",
   "label": "Cari Kodu",
   "options": {
     "filter": true,
     "sort": true
     }
  },
   {
   "name": "phone",
   "label": "Tel",
   "options": {
     "filter": true,
     "sort": true
     }
  },
  {
    "name": "fax",
    "label": "Fax",
    "options": {
      "filter": true,
      "sort": true
      }
   },
   {
    "name": "mail",
    "label": "E-mail",
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
    "name": "taxAdministration",
    "label": "V. D",
    "options": {
      "filter": true,
      "sort": true
      }
   },
   {
    "name": "taxNumber",
    "label": "V. No",
    "options": {
      "filter": true,
      "sort": true
      }
   },
   {
    "name": "authorizedPerson",
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
              <Button className="action-btn" onClick={() => redirectEditFirm(tableMeta.rowData[0])} circular primary icon='edit' />
              <Modal trigger={ <Button className="action-btn" circular negative icon='trash' />} header='Dikkat!' content={`${tableMeta.rowData[1]} silmek istediğinizden emin misiniz?`} actions={['İptal', { key: 'done', content: 'Sil', negative: true, onClick:() => deleteFirm(tableMeta.rowData[0])}]} /> 
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

                             <Link className="ui positive button"  to="/FirmAdd" style={{marginLeft:'.6em',marginBottom:'.6em'}}>
  <i className="fa fa-plus"></i> Firma Cari Ekle
 </Link>
 <ThemeProvider theme={theme} >

   <MUIDataTable title={"Firma Cari Listesi"} data={firmData} columns={columns} options={options} />
</ThemeProvider>
                            </div>
                            
                            


                        </div>
                    </div>
                </div>
    </div>





</div>

  
 )
}
export default FirmList;