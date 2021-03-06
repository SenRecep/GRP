import React, {useState, useContext, useEffect } from "react"; 
import {CalculateContext} from '../contexts/CalculateContext';
import {
    Button, 
    Form,
    Input,
    Message ,
    Modal,
    Checkbox
  } from 'semantic-ui-react'; 
import { ThemeProvider } from "@mui/styles";
import { createTheme, responsiveFontSizes } from '@mui/material/styles';
import MUIDataTable from "mui-datatables"; 
import rop_axios from '../js/identityServerClient/rop_axios.js';
import { Link } from "react-router-dom";
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
const GrpHesapla=(props)=> { 
  const [firmData, setFirmData] = useState([]); 
  const [halfXInput, setHalfXInput] = useState('');
  const [halfYInput, setHalfYInput] = useState('');
  const [unitInput, setunitInput] = useState(1); 
  const [halfZInput, setHalfZInput] = useState('');
  const { calculateData, addData, deleteData, postData, currencySelectInput,setCurrencySelectInput, disableInputs, setDisableInputs, redirectPage } = useContext(CalculateContext); 
  useEffect(() => { 
    if(calculateData.length>0){
      setDisableInputs(true)
      
    }
    else{
      setDisableInputs(false)
    }
  }, [calculateData]);
 
  useEffect(() => {
    toast.configure();
    
    const getFirmData = async () => {
        var companyResponse = await rop_axios.get("/company/companies");
        setFirmData(companyResponse.data);
        
    };
    
    getFirmData();
}, []);
    let firmOptions=firmData.map(item=>({
      key:Math.random(), text: item.title, value:item.id
    }))
    
  
      const onDeleteData=(id) => {  
        deleteData(id);
      }
      const triggerPostData=()=>{
      
       
        postData(firrmSelectInput.companyId,paymentSelectInput.paymentSelectValue);
        if(redirectPage){ 
          toast.success('Yönlendiriliyor', {
            position: "top-right",
            autoClose: 10000,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            progress: undefined,
            });
          
        }
        else{
          toast.error('Hatalı parametre lütfen değerleri kontrol ediniz', {
            position: "top-right",
            autoClose: 4000,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            progress: undefined,
            });
        }
      }
      let theme = createTheme();
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
          name: "quantity",
          label: "Adet",
          options: {
            filter: true,
            sort: true,
           }
         },
         {
          name: "plinthType",
          label: "Kaide Tipi",
          options: {
            customBodyRender: (value, tableMeta, updateValue) => { 
                
                return (
                 
                  <>
                  {tableMeta.rowData[2]===0?'Kiriş Kaide':tableMeta.rowData[2]===1?'Düz Kaide':'Hatalı'}
                  </>
                )
            }
        }
         },
         {
          name: "width",
          label: "En",
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
            name: "height",
            label: "Yükseklik",
            options: {
              filter: true,
              sort: true,
             }
           },
       
           {
            name: "paymentType",
            label: "Ödeme Şekli",
            options: {
              customBodyRender: (value, tableMeta, updateValue) => { 
               
                  return (
                   
                    <>
                    {
                      
                     tableMeta.rowData[6]=='0'?"Peşin": 
                     tableMeta.rowData[6]=='1'?"30 gün":
                     tableMeta.rowData[6]=='2'?"30/60 gün":
                     tableMeta.rowData[6]=='3'?"90/120 gün":
                     tableMeta.rowData[6]=='4'?"120/150 gün":
                     tableMeta.rowData[6]=='5'?"150/180 gün":"BILINMIYOR"
                    }
                    </>
                  )
              }
            }
           },
           {
            name: "vol",
            label: "Tonaj",
            options: {
              filter: true,
              sort: true,
             }
           },
         {
          name: "Actions",
          label: "Durum",
          options: {
              customBodyRender: (value, tableMeta, updateValue) => {  
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
        { key: 'k', text: 'Kiriş Kaide', value: '1' },
        { key: 'd', text: 'Düz Kaide', value: '0' }, 
      ]
      const currencyOptions = [
        { key: 'd', text: 'Dolar', value: '0' },
        { key: 't', text: 'TL', value: '1' }, 
      ]
      const paymentoptions = [
        { key: '3060', text: 'Peşin', value: '0' },
        { key: '90120', text: '30 Gün', value: '1' },
        { key: '30601', text: '30/60 Gün Vadeli', value: '2' },
        { key: '901201', text: '90/120 Gün Vadeli', value: '3' }, 
        { key: '901202', text: '120/150 Gün Vadeli', value: '4' }, 
        { key: '901203', text: '150/180 Gün Vadeli', value: '5' }, 
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
      const [firrmSelectInput, setfirrmSelectInput] = useState({ 
        companyId:''
      });
      const [paymentSelectInput, setPaymentSelectInput] = useState({  
        paymentSelectValue:''
      });
       
      const onFirmSelectChange = (evt, data) => { 
        setfirrmSelectInput({companyId:data.value}); 
     }


      const onSelectChange = (evt, data) => { 
          setSelectInput({selectValue:data.value}); 
      }
      const onPaymentSelectChange = (evt, data) => { 
        setPaymentSelectInput({paymentSelectValue:data.value});
      }
      const onCurrencySelectChange = (evt, data) => { 
        console.log(disableInputs)
        setCurrencySelectInput(data.value);
      }
    const valideteForm=(unit, x, y, z)=>{
        
        if(unit!=='' && x !=='' &&  y !=='' &&  z !==''  &&  unit !==''  && selectInput.selectValue !=='' && paymentSelectInput.paymentSelectValue !==''  )
        {  
  
  
            setinputValidate({
                type:'success',
                visible:true, 
                validateMessage:'Başarılı bir şekilde eklendi',
                header:'Başarılı'
            }) 
        
             var data={
                unit:unit,
                basetype:selectInput.selectValue,
                x:x,
                y:y,
                z:z,
                paymentType:paymentSelectInput.paymentSelectValue,
                currencyType:+currencySelectInput
             }



          
            addData(data)
            
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
    const halfhandleChange = (e) => { 
        if(e.target.value%0.5===0|| e.target.value===0 ){ 

          e.target.name==='x'?setHalfXInput( e.target.value  ):  e.target.name==='y'?setHalfYInput( e.target.value  ):e.target.name==='z'?setHalfZInput( e.target.value  ):  console.log(e.target.value)
         
        }else{
          e.target.name==='x'?setHalfXInput( ''  ):  e.target.name==='y'?setHalfYInput( ''  ):e.target.name==='z'?setHalfZInput( '' ):  console.log(e.target.value)
        
          toast.error('Lütfen en boy yükseklik kat sayılarını 0.5 artıcak şekilde giriniz', {
            position: "top-right",
            autoClose: 4000,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            progress: undefined,
            });

        } 
      
    };
    const unitHandleChange = (e) => { 
      if(e.target.value<0){ 

        setunitInput(1)
       
      }
      else{
        setunitInput(e.target.value)

      } 
    
  };
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
                                        value={unitInput}
                                        onChange={unitHandleChange}
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
                                        value={halfXInput}
                                        onChange={halfhandleChange}
                                    /> 
                                    </Form.Group>
                                    
                                    <Form.Group  width={8}>
                                        <Form.Field
                                        control={Input}
                                        label='Boy'
                                        name='y'
                                        value={halfYInput}
                                        onChange={halfhandleChange}
                                        placeholder='m'
                                    />
                                   
                                    </Form.Group>
                                    <Form.Group  width={8}>
                                    <Form.Field
                                        control={Input}
                                        label='Yükseklik'
                                        name='z'
                                        value={halfZInput}
                                        onChange={halfhandleChange}
                                        placeholder='m'
                                    />

                                    </Form.Group>
                                    


                                    <Form.Group width={8}>
                                        <Form.Select fluid options={paymentoptions}  label='Ödeme Şekli' placeholder='Ödeme Şekli' name='paymenttype' onChange={onPaymentSelectChange}/>
                                    </Form.Group>
                                    <Form.Group width={8}>
                                        <Form.Select fluid options={firmOptions} disabled={disableInputs} label='Firma Seç' placeholder='Firma Seç' name='compnyId' onChange={onFirmSelectChange}/>
                                    </Form.Group>
                                    <Form.Group width={8}>   
                                         <Form.Select fluid options={currencyOptions} disabled={disableInputs} value={currencySelectInput}  label='Döviz Türü' placeholder='Döviz Türü' name='currencyType' onChange={onCurrencySelectChange}/>
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