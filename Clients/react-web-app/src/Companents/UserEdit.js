import React, {useState, useEffect } from "react"; 
import {Button, Form, Input, Message} from 'semantic-ui-react';
import axios from 'axios';
import rop_axios from '../js/identityServerClient/rop_axios.js';
import { Link } from "react-router-dom";

const UserEdit = (props) => {
    const [userData, setUserData] = useState([]);
    const [inputValidate, setinputValidate] = useState({type: null, visible: false, validateMessage: null, header: null});
    const [selectRole, setSelectRole] = useState(null);
    
    useEffect(() => {
      const getUserData = async () => {
        let id=props.match.params.id
        let res= await rop_axios.get(`/user/users/getUser/${id}`); 
        setUserData(res.data); 
      }; 
      getUserData();
  }, []);
  const onSelectChange = (evt, data) => { 
    setSelectRole({selectRole:data.value}); 
   }
  const roleOptions = [
    { key: 'a', text: 'Yönetici', value: '0' },
    { key: 'f', text: 'Muhasebe', value: '1' }, 
    { key: 'm', text: 'Mühendis', value: '2' }, 
  ]
  const handleSubmit = (event) => {
    event.preventDefault();
    const {target} = event;
    valideteForm(target)
  };
  const valideteForm=async (targets)=>{
        
    if(targets.firstName.value!==''&& targets.lastName.value!==''&& targets.userName.value!==''&& targets.userMail.value!==''&& targets.userPhone.value!==''&& targets.role.value!=='')
    {    

      var userResponse = await rop_axios.put("/company/companies", {
        id: props.match.params.id ,
        firstName:targets.firstName.value,
        lastName:targets.lastName.value,
        userName:targets.userName.value,
        userMail:targets.userMail.value,
        userPhone:targets.userPhone.value,
        role:selectRole,
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
                  defaultValue={userData.userMail}
                  placeholder='E-mail'
                  type='email'/>
              </Form.Group>
              <Form.Group width={12}>
                <Form.Field
                  control={Input}
                  label='Tel'
                  name='userPhone'
                  defaultValue={userData.userPhone}
                  placeholder='Tel'
                  type='tel'/>
              </Form.Group>
              <Form.Group width={8}>   
                                         <Form.Select fluid options={roleOptions}  label='Rol' placeholder='Rol' name='role' onChange={onSelectChange}/>
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