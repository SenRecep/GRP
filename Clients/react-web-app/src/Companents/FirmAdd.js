import React, {useState, useEffect} from "react";
import {Button, Form, Input, Message} from 'semantic-ui-react';
import axios from 'axios'; 
import rop_axios from '../js/identityServerClient/rop_axios.js';
import { Link } from "react-router-dom";
const FirmAdd = (props) => { 
  const [inputValidate,
    setinputValidate] = useState({type: null, visible: false, validateMessage: null, header: null});
    
  const handleSubmit = (event) => {
    event.preventDefault();
    const {target} = event;
    valideteForm(target)
  };
  const valideteForm=async (targets)=>{
        
    if(targets.firmGsm.value!==''&& targets.title.value!==''&& targets.phone.value!==''&& targets.fax.value!==''&& targets.mail.value!==''&& targets.address.value!==''&& targets.taxAdministration.value!==''&& targets.taxNumber.value!==''&& targets.authorizedPerson.value!=='' && targets.currentAccountCode.value!==''  )
    {   

      
        setinputValidate({
            type:'success',
            visible:true, 
            validateMessage:'Başarılı bir şekilde firma cari eklendi yönlendiriliyorsunuz..',
            header:'Başarılı'
        }) 
    
       
         var companyResponse = await rop_axios.post("/company/companies", { 
          title: targets.title.value,
          currentAccountCode: targets.currentAccountCode.value,
          phone: targets.phone.value,
          fax: targets.fax.value,
          mail: targets.mail.value,
          address: targets.address.value,
          taxAdministration: targets.taxAdministration.value,
          taxNumber: targets.taxNumber.value,
          authorizedPerson: targets.authorizedPerson.value
      });
        
      if(companyResponse.error!==null){
        setinputValidate({
          type:'error',
          visible:true,
          validateMessage:'Üzgünüz Ufak Bir Hata İle Karşılaşıldı.',
          header:'Hata'
      })
      }
      else {
        setinputValidate({
          type:'success',
          visible:true, 
          validateMessage:'Başarılı bir şekilde firma cari düzenlendi yönlendiriliyorsunuz..',
          header:'Başarılı'
      }) 
      }
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
  return (

    <div className="container-fluid">
      <div className="row">

        <div className="col-xl-12 col-lg-7">
          <div className="card shadow mb-4">

            <div className="card-body">
              <Form onSubmit={handleSubmit}>

                {inputValidate.visible === true && inputValidate.type === 'success'
                  ? <Message positive>
                      <Message.Header>{inputValidate.header}</Message.Header>
                      <p>
                        {inputValidate.validateMessage}
                      </p>
                    </Message>

                  : inputValidate.visible === true && inputValidate.type === 'error'
                    ? <Message negative>
                        <Message.Header>{inputValidate.header}</Message.Header>
                        <p>
                          {inputValidate.validateMessage}
                        </p>
                      </Message>
                    : ''
                }

                <Form.Group width={12}>
                  <Form.Field
                    control={Input}
                    label='Firma Ünvanı'
                    name='title'
                    placeholder='Firma Ünvanı' 
                    type='text'/>
                </Form.Group>
                <Form.Group width={12}>
                  <Form.Field
                    control={Input}
                    label='Firma Telefon'
                    name='phone' 
                    placeholder='Firma Telefon'
                    type='tel'/>
                </Form.Group>
                <Form.Group width={12}>
                  <Form.Field
                     control={Input}
                     label='Firma Fax'
                     name='fax' 
                     placeholder='Firma Fax'
                     type='tel'/>
                </Form.Group>
                <Form.Group width={12}>
                  <Form.Field
                     control={Input}
                     label='Firma E-mail'
                     name='mail' 
                     placeholder='Firma E-mail'
                     type='email'/>
                </Form.Group>
                <Form.Group width={12}>
                  <Form.Field
                    control={Input}
                    label='Firma E-mail'
                    name='firmMail'
                    placeholder='Firma E-mail'
                    type='email'/>
                </Form.Group>
                <Form.Group width={12}>
                  <Form.Field
                     control={Input}
                     label='Firma Adres'
                     name='currentAccountCode' 
                     placeholder='Firma Adres'
                     type='text'/>
                </Form.Group>
                <Form.Group width={12}>
                  <Form.Field
                   control={Input}
                   label='Firma Adres'
                   name='firmAdress' 
                   placeholder='Firma Adres'
                   type='text'/>
                </Form.Group>
                <Form.Group width={12}>
                  <Form.Field
                     control={Input}
                     label='Firma Vergi Dairesi'
                     name='taxAdministration' 
                     placeholder='Firma Vergi Dairesi'
                     type='text'/>
                </Form.Group>
                <Form.Group width={12}>
                  <Form.Field
                    control={Input}
                    label='Firma Vergi Dairesi'
                    name='taxAdministration' 
                    placeholder='Firma Vergi Dairesi'
                    type='text'/>
                </Form.Group>
                <Form.Group width={12}>
                <Form.Field
                  control={Input}
                  label='Firma Yetkili Kişi'
                  name='authorizedPerson' 
                  placeholder='Firma Yetkili Kişi'
                  type='text'/>
              </Form.Group>
                <Button positive type='submit'>Ekle</Button> 
                <Link className='ui button' to="/FirmList">
                  <i
                    className="fa fa-backward"
                    style={{
                    marginRight: '.5em'
                  }}></i>
                  Geri Dön
                </Link>
              </Form>
            </div>
          </div>
        </div>
      </div>

    </div>

  );
};

export default FirmAdd;