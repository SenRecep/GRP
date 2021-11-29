import React, {useState, useContext, useEffect } from "react"; 
import {
    Button,  
    Modal
  } from 'semantic-ui-react'; 
import { ThemeProvider } from "@mui/styles";
import { createTheme, responsiveFontSizes } from '@mui/material/styles';
import MUIDataTable from "mui-datatables";
import axios from 'axios';
import { Link } from "react-router-dom";
import rop_axios from '../js/identityServerClient/rop_axios.js';
const GrpListe=(props)=> {
  const [calculatedData, setCalculatedData] = useState([]);
   useEffect(() => {
    const getCalculatedData = async () => {
      var res = await rop_axios.get("/watertankcalculator/");  
      console.log(res);
      setCalculatedData(res.data);
    }; 
    getCalculatedData();
}, []);
  const redirectEditCalculate= (id)  => { 
    console.log(id)
    //props.history.push(`/GrpHesaplaEdit/${id}`)
  }
  const refreshData= async (id)  => { 
    var res = await rop_axios.get("/watertankcalculator/");  
    console.log(res);
    setCalculatedData(res.data);
  }
 
   
  let theme = createTheme();
      theme = responsiveFontSizes(theme);
  const options = {  
    download: false,
    print: false
  };
  const columns=[
    {
       "name": "id",
       "options": {
       "display": false
       }
     },
     {
     "name": "preparedDate",
     "label": "Hazırlanma Tarihi",
     "options": {
       "filter": true,
       "sort": true
       }
    },
    {
     "name": "preparedBy",
     "label": "Hazırlayan Kullanıcı",
     "options": {
       "filter": true,
       "sort": true
     }
    },
    {
     "name": "baseType",
     "label": "Kaide Türü",
     "options": {
       "filter": true,
       "sort": true
       }
    },
    {
     "name": "x",
     "label": "En",
     "options": {
       "filter": true,
       "sort": true
       }
    },
    {
     "name": "y",
     "label": "Boy",
     "options": {
       "filter": true,
       "sort": true
       }
    },
    {
     "name": "z",
     "label": "Yükseklik",
     "options": {
       "filter": true,
       "sort": true
       }
    },
    
    {
     "name": "paymentType",
     "label": "Ödeme Türü",
     "options": {
       "filter": true,
       "sort": true
       }
    },
    {
     "name": "firm",
     "label": "Teklif Yapılan Firma",
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
            console.log(tableMeta.rowData[0])
              return (
               
                <> 
                 <Button className="action-btn disable" onClick={() =>redirectEditCalculate(tableMeta.rowData[0])} circular primary icon='edit' />
                </>
              )
          }
      }
    }
   ]
 return(
  

<div className="container-fluid">

              
                

               
<div className="row">

    <div className="col-xl-12 col-lg-12">
                    <div className="card shadow mb-4"> 
                      
                        <div className="card-body">
                          
                            <div className="row">

                             <Link className="ui positive button"  to="/GrpHesapla" style={{marginLeft:'.6em',marginBottom:'.6em'}}>
  <i className="fa fa-plus"></i> GRP Depo Hesapla
 </Link>
 <ThemeProvider theme={theme} >

   <MUIDataTable title={"Teklif Gönderilmiş Depolar"} data={calculatedData} columns={columns} options={options} />
</ThemeProvider>
                            </div>
                            
                            


                        </div>
                    </div>
                </div>
    </div>





</div>

  
 )
}
export default GrpListe;