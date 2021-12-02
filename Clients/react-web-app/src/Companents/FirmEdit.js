import React, {useState, useEffect } from "react"; 
import {Button, Form, Input, Message} from 'semantic-ui-react'; 
import rop_axios from '../js/identityServerClient/rop_axios.js';
import { Link } from "react-router-dom";

const FirmEdit = (props) => {
    const [firmData, setFirmData] = useState([]);
    const [inputValidate, setinputValidate] = useState({type: null, visible: false, validateMessage: null, header: null});
    useEffect(() => {
      const getFirmData = async () => {
        let id=props.match.params.id 
        let res= await rop_axios.get(`/company/companies/${id}`); 
          setFirmData(res.data);
      };
  
      getFirmData();
  }, []);
  const handleSubmit = (event) => {
    event.preventDefault();
    const {target} = event;
    valideteForm(target)
  };
  const valideteForm=async (targets)=>{
        
    if(targets.title.value!==''&& targets.phone.value!==''&& targets.fax.value!==''&& targets.mail.value!==''&& targets.address.value!==''&& targets.taxAdministration.value!==''&& targets.taxNumber.value!==''&& targets.authorizedPerson.value!=='' && targets.currentAccountCode.value!==''  )
    {   
       
    
         
        
       
    var companyResponse = await rop_axios.put("/company/companies", {
        id: props.match.params.id ,
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
    setinputValidate({
      type:'success',
      visible:true, 
      validateMessage:'Başarılı bir şekilde firma cari düzenlendi yönlendiriliyorsunuz..',
      header:'Başarılı'
  }) 

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
                  defaultValue={firmData.title}
                  type='text'/>
              </Form.Group>
              <Form.Group width={12}>
                <Form.Field
                  control={Input}
                  label='Firma Telefon'
                  name='phone'
                  defaultValue={firmData.phone}
                  placeholder='Firma Telefon'
                  type='tel'/>
              </Form.Group>
              
              <Form.Group width={12}>
                <Form.Field
                  control={Input}
                  label='Firma Fax'
                  name='fax'
                  defaultValue={firmData.fax}
                  placeholder='Firma Fax'
                  type='tel'/>
              </Form.Group>
              <Form.Group width={12}>
                <Form.Field
                  control={Input}
                  label='Firma E-mail'
                  name='mail'
                  defaultValue={firmData.mail}
                  placeholder='Firma E-mail'
                  type='email'/>
              </Form.Group>
              <Form.Group width={12}>
                <Form.Field
                  control={Input}
                  label='Cari Kodu'
                  name='currentAccountCode'
                  defaultValue={firmData.currentAccountCode}
                  placeholder='Cari Kodu'
                  type='text'/>
              </Form.Group>
              
              <Form.Group width={12}>
                <Form.Field
                  control={Input}
                  label='Firma Adres'
                  name='address'
                  defaultValue={firmData.address}
                  placeholder='Firma Adres'
                  type='text'/>
              </Form.Group>
              <Form.Group width={12}>
                <Form.Field
                  control={Input}
                  label='Firma Vergi Dairesi'
                  name='taxAdministration'
                  defaultValue={firmData.taxAdministration}
                  placeholder='Firma Vergi Dairesi'
                  type='text'/>
              </Form.Group>
              <Form.Group width={12}>
                <Form.Field
                  control={Input}
                  label='Firma Vergi No'
                  name='taxNumber'
                  defaultValue={firmData.taxNumber}
                  placeholder='Firma Vergi No'
                  type='text'/>
              </Form.Group>
              <Form.Group width={12}>
                <Form.Field
                  control={Input}
                  label='Firma Yetkili Kişi'
                  name='authorizedPerson'
                  defaultValue={firmData.authorizedPerson}
                  placeholder='Firma Yetkili Kişi'
                  type='text'/>
              </Form.Group>
              <Button positive type='submit'>Kaydet</Button> 
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

 

export default FirmEdit;