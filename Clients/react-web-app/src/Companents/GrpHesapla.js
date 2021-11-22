import React, {useState, useEffect} from "react";
import {
   Redirect
  } from "react-router-dom";
import {
    Button, 
    Form,
    Input,
    Message 
  } from 'semantic-ui-react'
  import axios from 'axios';
const GrpHesapla=(props)=> { 
    useEffect(()=>{})
    const options = [
        { key: 'k', text: 'Kiriş Kaide', value: '0' },
        { key: 'd', text: 'Düz Kaide', value: '1' }, 
      ]
    const [inputValidate, setinputValidate] = useState({ 
        type:null,
        visible:false,
        validateMessage: null,
        header:null
      });
      const [SelectInput, setSelectInput] = useState({ 
        selectValue:''
      });




      let onSelectChange = (evt, data) => {
          setSelectInput({selectValue:data.value});
      }
    let valideteForm=(x, y, z, SelectInput)=>{
        
        if( x !=='' &&  y !=='' &&  z !=='' && SelectInput.selectValue !=='')
        {  

            setinputValidate({
                type:'success',
                visible:true, 
                validateMessage:'Başarılı bir şekilde hesaplandı yönlendiriliyorsunuz..',
                header:'Başarılı'
            }) 

            //Axios
            axios.get(`https://jsonplaceholder.typicode.com/users/1`)
            .then(response => { 
                props.history.push({
                    pathname: '/GrpSonuc', 
                    state: { data: response.data }
                });
            })
            .catch(err => {
                console.log('error');
                console.log(err.status);
                console.log(err.response.status)
            });
            
                 
        } 
        else {
            setinputValidate({
                type:'error',
                visible:true,
                validateMessage:'Lütfen gerekli alanları doldurun',
                header:'Hata'
            })
            console.log("hata")
        }
       
    }
 let handleSubmit = (event) => {
        event.preventDefault();
        const {target} = event; 
        
        valideteForm(target.x.value,target.y.value,target.z.value, SelectInput) 
      };
 return(

    <div className="container-fluid">

              
                

               
    <div className="row">

        <div className="col-xl-12 col-lg-12">
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
                                        label='En'
                                        name='x'
                                        placeholder='m'
                                    />
                                    
                                    
                                    </Form.Group>
                                    <Form.Group width={8}>
                                        
                                    <Form.Select fluid options={options} placeholder='Kaide Türü' name='basetype' onChange={onSelectChange}/>
                                        
                                        
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
                                    <Button positive type='submit'>Hesapla</Button>
                                           
                      
                                </Form>
                            </div>
                        </div>
                    </div>
        </div>

   

  

</div>



  
 )
}
export default GrpHesapla;