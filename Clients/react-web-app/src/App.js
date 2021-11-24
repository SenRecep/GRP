import React from 'react';
import 'semantic-ui-css/semantic.min.css'
import {BrowserRouter,Switch, Route} from 'react-router-dom'; 
import SideBar from './Companents/SideBar'; 
import Footer from './Companents/Footer'; 
import Veriler from './Companents/Veriler';
import Users from './Companents/Users';  
import GrpHesapla from './Companents/GrpHesapla';
import GrpSonuc from './Companents/GrpSonuc';
import UserEdit from './Companents/UserEdit';


function App() {  
    let inputs = [
      {
          "inputId": 1,
          "inputName": "checkName",
          "inputUUID": "0a02ce20-43c9-11ec-81d3-0242ac130003",
          "inputType": "checkbox",
          "seedValue": false,
          "isSetSeedValue":false,
          "defaultValue":true,
          "label":"Checkbox"
          
      },
      {
        "inputId": 2,
        "inputName": "numberName",
        "inputUUID": "4adcb002-43cc-11ec-81d3-0242ac130003",
        "inputType": "number",
        "seedValue": 22,
        "isSetSeedValue":false,
        "defaultValue":30,
        "label":"Checkbox"
        
    },
      {
        "inputId": 3,
        "inputName": "textName",
        "inputUUID": "5f886ffa-43cc-11ec-81d3-0242ac130003",
        "inputType": "text",
        "seedValue": "bubirtext",
        "isSetSeedValue":false,
        "defaultValue":"bubirtextvaluesu",
        "label":"Text"
        
    },
    {
      "inputId": 4,
      "inputType": "radiogroup",  
      "inputUUID": "6a5bb554-43cc-11ec-81d3-0242ac130003",
      "question": "Label question 1",  
      "radios": [
        {"value":'test', "label":'asd' ,"name":"radioGroup1"},
        {"value":'2', "label":'xyz',"name":"radioGroup2"}, 
      ],
      "defaultValue": 'test'
    },
    {
      "inputId": 5,
      "inputName": "selectName",
      "inputUUID": "72d35728-43cc-11ec-81d3-0242ac130003",
      "inputType": "select",
      "seedValue": "option1", 
      "label":"Select", 
      "options": [
        {"value":'1', "text":'Lamborghini Aventador 2016'},
        {"value":'2', "text":'VW Beetle 1971'},
        {"value":'3', "text":'Ford Mustang'},
      ],
      "defaultValue": '1',
     
      
    },
    {
      "inputId": 6,
      "inputType": "radiogroup",  
      "inputUUID": "7bca3194-43cc-11ec-81d3-0242ac130003",
      "question": "Label question 2",  
      "radios": [
        {"value":'1', "label":'Lamborghini Aventador 2016' ,"name":"radioGroup3"},
        {"value":'2', "label":'VW Beetle 1971',"name":"radioGroup4"}, 
      ],
      "defaultValue": '1'
    }
    
       
    ];
  return (
    <div id="wrapper">
  <BrowserRouter> 
  <SideBar/>
     <div id="content-wrapper" className="d-flex flex-column">
         <div id="content">

               
                <nav className="navbar navbar-expand navbar-light bg-white topbar mb-4 static-top shadow">

                   
                    <button id="sidebarToggleTop" className="btn btn-link d-md-none rounded-circle mr-3">
                        <i className="fa fa-bars"></i>
                    </button>

                  
                 

                </nav>
      <Switch>     
      <Route exact path="/" component = {GrpHesapla}/>  
      <Route path="/Veriler"> <Veriler datas={inputs}/> </Route>
      <Route path="/Users"  component = {Users}/>   
      <Route path="/UserEdit/:user"  component = {UserEdit}/>    
      <Route path="/GrpSonuc"  component = {GrpSonuc}/>  
    </Switch>
    </div>
      <Footer></Footer> 
   
   </div>   
 
   </BrowserRouter>
   </div>
  
   
  );
}


export default App;
