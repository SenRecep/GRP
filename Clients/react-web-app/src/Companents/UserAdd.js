import React, {useState, useEffect } from "react"; 
import {Button, Form, Input, Message} from 'semantic-ui-react';
import axios from 'axios';
import rop_axios from '../js/identityServerClient/rop_axios.js';
import { Link } from "react-router-dom";
import identityServerRequest from '../js/identityServerClient/identityServerRequest.js';
const requester = new identityServerRequest(); 
const UserAdd = (props) => {
    const [inputValidate, setinputValidate] = useState({type: null, visible: false, validateMessage: null, header: null});
    const [selectRole, setSelectRole] = useState();
    const [roleOptions, setRoleOptions] = useState([]);
    useEffect(() => {
       
      const getData = async () => {
          var rolesResponse = await requester.getRoles();
          setRoleOptions(rolesResponse.data.map(x=>( { key: Math.random(), text: x, value: x })));
      };
  
      getData();
  }, []);
  const onSelectChange = (evt, data) => { 
    setSelectRole(data.value); 
   }

  const handleSubmit = (event) => {
    event.preventDefault();
    const {target} = event;
    valideteForm(target)
  };
  const valideteForm=async (targets)=>{ 
    await requester.connectTokenAsync();
    if(targets.firstName.value!==''&& targets.lastName.value!==''&& targets.userName.value!==''&& targets.mail.value!==''&& targets.userPhone.value!=='' && targets.identityNumber.value!=='' && targets.address.value!=='')
    {   
         
      var model={
          firstName:targets.firstName.value,
          lastName:targets.lastName.value,
          userName:targets.userName.value,
          email:targets.mail.value,
          phoneNumber:targets.userPhone.value,
          identityNumber:targets.identityNumber.value,
          address:targets.address.value,
          roles:[selectRole],
          password:targets.password.value
      }
    
      var userResponse = await requester.signUpAsync(model);
 
        if(userResponse.error!==null){
          console.log(userResponse)
          setinputValidate({
            type:'error',
            visible:true,
            validateMessage:'Üzgünüz Ufak Bir Hata İle Karşılaşıldı.',
            header:'Hata'
        })
        }
        else {
          console.log(userResponse)
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
                  label='Adı'
                  name='firstName'
                  placeholder='Adı' 
                  type='text'/>
              </Form.Group>
              <Form.Group width={12}>
                <Form.Field
                  control={Input}
                  label='Soy Adı'
                  name='lastName' 
                  placeholder='Soy Adı'
                  type='text'/>
              </Form.Group>
              <Form.Group width={12}>
                <Form.Field
                  control={Input}
                  label='Tc Kimlik'
                  name='identityNumber'
                  placeholder='Tc Kimlik'
                  type='text'/>
              </Form.Group>
              <Form.Group width={12}>
                <Form.Field
                  control={Input}
                  label='Adres'
                  name='address'
                  placeholder='Adres'
                  type='text'/>
              </Form.Group>
              <Form.Group width={12}>
                <Form.Field
                  control={Input}
                  label='Kullanıcı Adı'
                  name='userName'
                  
                  placeholder='Kullanıcı Adı'
                  type='text'/>
              </Form.Group>
              <Form.Group width={12}>
                <Form.Field
                  control={Input}
                  label='Şifre'
                  name='password' 
                  placeholder='Şifre'
                  type='password'/>
              </Form.Group>
              <Form.Group width={12}>
                <Form.Field
                  control={Input}
                  label='E-mail'
                  name='mail' 
                  placeholder='E-mail'
                  type='email'/>
              </Form.Group>
              <Form.Group width={12}>
                <Form.Field
                  control={Input}
                  label='Tel'
                  name='userPhone'
                   
                  placeholder='Tel'
                  type='tel'/>
              </Form.Group>
              <Form.Group width={8}>   
                                         <Form.Select fluid options={roleOptions}  label='Rol' placeholder='Rol' name='role' onChange={onSelectChange}/>
              </Form.Group> 
              
              <Button positive type='submit'>Ekle</Button> 
              <Link className='ui button' to="/Users">
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

 

export default UserAdd;