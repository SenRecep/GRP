import React, {useState, useEffect } from "react"; 
import {Button, Form, Input, Message} from 'semantic-ui-react';
import axios from 'axios';
import rop_axios from '../js/identityServerClient/rop_axios.js';
import { Link } from "react-router-dom";
import identityServerRequest from '../js/identityServerClient/identityServerRequest.js';
const requester = new identityServerRequest(); 
const UserEdit = (props) => {
    const [userData, setUserData] = useState([]);
    const [inputValidate, setinputValidate] = useState({type: null, visible: false, validateMessage: null, header: null});
    const [selectRole, setSelectRole] = useState();
    const [roleOptions, setRoleOptions] = useState([]);
    useEffect(async() => {
      await requester.connectTokenAsync();
      const getData = async () => {
          var rolesResponse = await requester.getRoles();
          setRoleOptions(rolesResponse.data.map(x=>( { key: Math.random(), text: x, value: x })));
      };
      const getUserDatas = async () => {
        var user = await requester.getUserAsync(props.match.params.user);

        console.log(user)
        var selected=user.data.roles[0];
        setSelectRole(selected); 
        setUserData(user.data);
      };

    getUserDatas();
      getData();
      console.log(userData)

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
        
    if(targets.firstName.value!==''&& targets.lastName.value!==''&& targets.userName.value!==''&& targets.userMail.value!==''&& targets.userPhone.value!=='' && targets.identityNumber.value!=='' && targets.address.value!=='')
    {  
      console.log({
        id: props.match.params.user ,
        firstName:targets.firstName.value,
        lastName:targets.lastName.value,
        userName:targets.userName.value,
        email:targets.userMail.value,
        phoneNumber:targets.userPhone.value,
        identityNumber:targets.identityNumber.value,
        address:targets.address.value,
        roles:[selectRole],
        password:targets.password.value
      });

      var userResponse = await requester.updateUserAsync({
        id: props.match.params.user ,
        firstName:targets.firstName.value,
        lastName:targets.lastName.value,
        userName:targets.userName.value,
        email:targets.userMail.value,
        phoneNumber:targets.userPhone.value,
        identityNumber:targets.identityNumber.value,
        address:targets.address.value,
        roles:[selectRole],
        password:targets.password.value
      });
      if(userResponse.error!==null){
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
                  label='Adı'
                  name='firstName'
                  placeholder='Adı'
                  defaultValue={userData.firstName}
                  type='text'/>
              </Form.Group>
              <Form.Group width={12}>
                <Form.Field
                  control={Input}
                  label='Soy Adı'
                  name='lastName'
                  defaultValue={userData.lastName}
                  placeholder='Soy Adı'
                  type='text'/>
              </Form.Group>
              <Form.Group width={12}>
                <Form.Field
                  control={Input}
                  label='Tc Kimlik'
                  name='identityNumber'
                  defaultValue={userData.identityNumber}
                  placeholder='Tc Kimlik'
                  type='text'/>
              </Form.Group>
              <Form.Group width={12}>
                <Form.Field
                  control={Input}
                  label='Adres'
                  name='address'
                  placeholder='Adres'
                  defaultValue={userData.address}
                  type='text'/>
              </Form.Group>
              <Form.Group width={12}>
                <Form.Field
                  control={Input}
                  label='Kullanıcı Adı'
                  name='userName'
                  defaultValue={userData.userName}
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
                  name='userMail'
                  defaultValue={userData.email}
                  placeholder='E-mail'
                  type='email'/>
              </Form.Group>
              <Form.Group width={12}>
                <Form.Field
                  control={Input}
                  label='Tel'
                  name='userPhone'
                  defaultValue={userData.phoneNumber}
                  placeholder='Tel'
                  type='tel'/>
              </Form.Group>
              <Form.Group width={8}>   
                                         <Form.Select fluid value={selectRole} options={roleOptions}  label='Rol' placeholder='Rol' name='role' onChange={onSelectChange}/>
              </Form.Group> 
              
              <Button positive type='submit'>Düzenle</Button> 
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

 

export default UserEdit;