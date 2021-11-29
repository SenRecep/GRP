import React, {useState, useContext, useEffect } from "react"; 
import {CalculateContext} from '../contexts/CalculateContext';
import {
    Button, 
    Form,
    Input,
    Message ,
    Modal
  } from 'semantic-ui-react'; 
import { ThemeProvider } from "@mui/styles";
import { createTheme, responsiveFontSizes } from '@mui/material/styles';
import MUIDataTable from "mui-datatables";
import axios from 'axios';
import { Link } from "react-router-dom";
const GrpHesapla=(props)=> { 
  
 
    const { calculateData, addData, deleteData, postData } = useContext(CalculateContext); 
  
      const onDeleteData=(id) => {  
        deleteData(id);
      }
      const triggerPostData=()=>{
        postData();
      }
      const theme = createTheme();
      theme = responsiveFontSizes(theme);
      const options = {  
        download: false,
        print: false
      };
    const columns = [
        {
          name: "id",
          options: {
          display: false,
          }
        },
        {
          name: "unit",
          label: "Adet",
          options: {
            filter: true,
            sort: true,
           }
         },
         {
          name: "basetype",
          label: "Kaide Tipi",
          options: {
            customBodyRender: (value, tableMeta, updateValue) => { 
               
              
                return (
                 
                  <>
                  {tableMeta.rowData[2]==='0'?'Kiriş Kaide':'Düz Kaide'}
                  </>
                )
            }
        }
         },
         {
          name: "x",
          label: "En",
          options: {
            filter: true,
            sort: true,
           }
         },
         {
          name: "y",
          label: "Boy",
          options: {
            filter: true,
            sort: true,
           }
         },
         {
            name: "z",
            label: "Yükseklik",
            options: {
              filter: true,
              sort: true,
             }
           },
           {
            name: "paymenttype",
            label: "Ödeme Şekli",
            options: {
              customBodyRender: (value, tableMeta, updateValue) => { 
                 
                
                  return (
                   
                    <>
                    {tableMeta.rowData[6]==='0'?'30/60 Gün Vadeli':'90/120 Gün Vadeli'}
                    </>
                  )
              }
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
                    
                    <Modal trigger={ <Button className="action-btn" circular negative icon='trash' />} header='Dikkat!' content={`${tableMeta.rowData[0]} silmek istediğinizden emin misiniz?`} actions={['İptal', { key: 'done', content: 'Sil', negative: true, onClick:() => onDeleteData(tableMeta.rowData[0])}]} /> 
                    </>
                  )
              }
          }
        }
    ];
    const basetypeoptions = [
        { key: 'k', text: 'Kiriş Kaide', value: '0' },
        { key: 'd', text: 'Düz Kaide', value: '1' }, 
      ]
      const paymentoptions = [
        { key: '3060', text: '30/60 Gün Vadeli', value: '0' },
        { key: '90120', text: '90/120 Gün Vadeli', value: '1' }, 
      ]
    const [inputValidate, setinputValidate] = useState({ 
        type:null,
        visible:false,
        validateMessage: null,
        header:null
      });
      const [selectInput, setSelectInput] = useState({ 
        selectValue:''
      });
      const [paymentSelectInput, setPaymentSelectInput] = useState({  
        paymentSelectValue:''
      });



      const onSelectChange = (evt, data) => { 
          setSelectInput({selectValue:data.value}); 
      }
      const onPaymentSelectChange = (evt, data) => { 
        setPaymentSelectInput({paymentSelectValue:data.value});
      }
    const valideteForm=(unit, x, y, z, SelectInput)=>{
        
        if(unit!=='' && x !=='' &&  y !=='' &&  z !==''  &&  unit !==''  && selectInput.selectValue !=='' && paymentSelectInput.paymentSelectValue !==''  )
        {  

          console.log(SelectInput.selectValue) 
            setinputValidate({
                type:'success',
                visible:true, 
                validateMessage:'Başarılı bir şekilde hesaplandı yönlendiriliyorsunuz..',
                header:'Başarılı'
            }) 
        
             var data={
                unit:unit,
                basetype:selectInput.selectValue,
                x:x,
                y:y,
                z:z,
                paymenttype:paymentSelectInput.paymentSelectValue
             }
            addData(data)
            // axios.post(`https://localhost:5102/api/plinth`, {
            //     "width":2,
            //     "length":5,
            //     "height":2,
            //     "plinthType":0
            // }).then(response => { 
            //     console.log(response);
            // }).catch(err => {
            //     console.log('error');
            //     console.log(err.status);
            //     console.log(err.response.status)
            // });
            
                 
        } 
        else {
            setinputValidate({
                type:'error',
                visible:true,
                validateMessage:'Lütfen gerekli alanları doldurun',
                header:'Hata'
            })
             
        }
       
    }
 const handleSubmit = (event) => {
        event.preventDefault();
        const {target} = event;  
        valideteForm(target.unit.value, target.x.value,target.y.value,target.z.value, selectInput, paymentSelectInput)  
      };
 return(

    <div className="container-fluid">

              
                

               
    <div className="row">

        <div className="col-xl-4 col-lg-4">
                        <div className="card shadow mb-4"> 
                          
                            <div className="card-body">
                            <Form  onSubmit={handleSubmit}>
                         

                            {
                                inputValidate.visible===true && inputValidate.type==='success' ? 
                               
                                <Message positive>
                                <Message.Header>{inputValidate.header}</Message.Header>
                                <p>
                                 {inputValidate.validateMessage}
                                </p>
                                </Message>
                                
                                
                                :inputValidate.visible===true && inputValidate.type==='error' ?  
                                    
                                <Message negative>
                                <Message.Header>{inputValidate.header}</Message.Header>
                                <p>
                                 {inputValidate.validateMessage}
                                </p>
                                </Message> 
                                :''  
                            }

                                
                                    <Form.Group width={8}> 
                                    <Form.Field
                                        control={Input}
                                        label='Depo Adet'
                                        name='unit'
                                        placeholder='Depo Adet'
                                        type='number' 
                                    /> 
                                    </Form.Group>
                                    <Form.Group width={8}>   
                                         <Form.Select fluid options={basetypeoptions}  label='Kaide Türü' placeholder='Kaide Türü' name='basetype' onChange={onSelectChange}/>
                                    </Form.Group> 
                                    <Form.Group width={8}>  
                                    <Form.Field
                                        control={Input}
                                        label='En'
                                        name='x'
                                        placeholder='m'
                                    /> 
                                    </Form.Group>
                                    
                                    <Form.Group  width={8}>
                                        <Form.Field
                                        control={Input}
                                        label='Boy'
                                        name='y'
                                        placeholder='m'
                                    />
                                    </Form.Group>
                                    <Form.Group  width={8}>
                                    <Form.Field
                                        control={Input}
                                        label='Yükseklik'
                                        name='z'
                                        placeholder='m'
                                    />
                                    </Form.Group>
                                    <Form.Group width={8}>
                                        <Form.Select fluid options={paymentoptions}  label='Ödeme Şekli' placeholder='Ödeme Şekli' name='paymenttype' onChange={onPaymentSelectChange}/>
                                    </Form.Group>
                                    <Button positive type='submit'>Ekle</Button> 
                                    <a onClick={triggerPostData} className="ui violet button">Hesapla</a>
                                    <Link className='ui button' to="/">
                                    <i className="fa fa-backward" style={{marginRight:'.5em'}}></i>
                                    Geri Dön
                                    </Link>
                                </Form>
                                
                            </div>
                        </div>
                    </div>
                    <div className="col-xl-8 col-lg-8">
                        <div className="card shadow mb-4"> 
                          
                            <div className="card-body">
                            <ThemeProvider theme={theme}>
                                                <MUIDataTable
                                                    title={"Hesaplanacak Depolar"}
                                                    data={calculateData}
                                                    columns={columns}
                                                    options={options}
                                                  />
                                            </ThemeProvider>
                            </div>
                        </div>
                    </div>
        </div>

   

  

</div>



  
 )
}
export default GrpHesapla;