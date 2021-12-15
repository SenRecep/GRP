import React, {useState, useContext, useEffect } from "react"; 
import {CalculateContext} from '../contexts/CalculateContext';
import { useLocation } from "react-router-dom";
import { ThemeProvider } from "@mui/styles";
import { createTheme, responsiveFontSizes } from '@mui/material/styles';
import MUIDataTable from "mui-datatables";
import rop_axios from '../js/identityServerClient/rop_axios.js';
import { ApiError } from "../js/identityServerClient/centeralRequest.js";

function GrpSonuc(props) {   
  const { deleteAllData } = useContext(CalculateContext); 
    const [responseData, setresponseData] = useState([]);
    useEffect(() => {
       
        const getData = async () => {
            var companyResponse = await rop_axios.get(`watertankcalculator/History/${props.location.state.data}`);

            setresponseData(companyResponse.data);
            console.log(responseData)
        };
        deleteAllData()
        getData();
    }, []);
    const newOnclick = async (event) => {
         
        var url=`http://185.122.202.87:8264/api/export/${props.location.state.data}`
        window.open(url)
      };
      const mailSendOnclick = async (e)=>{
        var mailResponse = await rop_axios.post(`watertankcalculator/Mail/${props.location.state.data}`);
        if(!mailResponse.isSuccessful){
          alert(ApiError.getErrors(mailResponse.error));
        }
      }
    let data=responseData.tanks;
    console.log(responseData)
    let columns = [
        {
          name: "capacity",
          label: "Kapasite m3",
          options: {
            filter: true,
            sort: true,
           }
         },
         {
            name: "width",
            label: "Genişlik",
            options: {
              filter: true,
              sort: true,
             }
           },
         {
            name: "height",
            label: "Yükseklik",
            options: {
              filter: true,
              sort: true,
             }
           },
           {
            name: "length",
            label: "Boy",
            options: {
              filter: true,
              sort: true,
             }
           },
           {
            name: "quantity",
            label: "Adet",
            options: {
              filter: true,
              sort: true,
             }
           },
           {
            name: "total",
            label: "Ara Toplam",
            options: {
              filter: true,
              sort: true,
             }
           },
           {
            name: "type",
            label: "Tip",
            options: {
              filter: true,
              sort: true,
             }
           }
          
    ];
    let theme = createTheme();
      theme = responsiveFontSizes(theme);
      const options = {  
        download: false,
        print: false
      };
 return(
    <div className="container-fluid"> <div className="row"> <div className="col-xl-12 col-lg-12"> <div className="card shadow mb-4"> <div className="card-body">
        <ThemeProvider theme={theme}>
                                                <MUIDataTable
                                                    title={"Hesaplanacak Depolar"}
                                                    data={data}
                                                    columns={columns}
                                                    options={options}
                                                  />
                                            </ThemeProvider> 
     
     
             
                  
  <div class="ui grid">
  <div class="four column row">
    <div class="left floated column">   <div className="card ml-4 ">
    <div className="content">
      <div className="header"></div>
      <div className="meta"><b>GRP KG Fiyatı</b></div>
      <div className="description"> 
      {responseData?.constants?.grpKgPrice}
      </div>
      <div className="meta"><b>Dolar Fiyatı</b></div>
      <div className="description">
      {responseData?.constants?.dollar} 
      </div>
      <div className="meta"><b>Nakliye</b></div>
      <div className="description"> 
      {responseData?.constants?.transportation}
      </div>
      <div className="meta"><b>Ara Toplam</b></div>
      <div className="description">
      {responseData?.total}
      </div>
      <div className="meta"><b>KDV</b></div>
      <div className="description">
      {responseData?.kdv}
      </div>
      <div className="meta"><b>Genel Toplam</b></div>
      <div className="description">
        {responseData?.fullTotal}
      </div>
    </div>
  </div></div>
    <div class="right floated column">
    <div className="card ">
    <div className="content">
    <div className="meta"><b>İşlemler</b></div>
      <div className="description">
     
<button class="ui button primary" onClick={newOnclick}>
  Teklif indir
</button>
<button class="ui button positive"  onClick={mailSendOnclick}>
  Teklif Gönder
</button>
      </div>
    </div>
  </div>


    </div>
  </div>
  
</div>
          
        

        
        </div></div></div></div></div>
  
  
 )
}
export default GrpSonuc;