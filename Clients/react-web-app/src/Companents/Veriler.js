import React from "react"; 
import InputCompanent from '../Companents/InputCompanent';

class Veriler extends React.Component {
     
      handleOnBlurInput = (value, key ) => { 
          console.log("Değer:  "+ value +" Id:    "+ key) 
      }
    render() {
        return (

            
 
           
            <div className="container-fluid">

              
                

               
                <div className="row">
        
                    <div className="col-xl-12 col-lg-12">
                                    <div className="card shadow mb-4"> 
                                      
                                        <div className="card-body">
                                        {
            this.props.datas.map(el=>{
               
              return <InputCompanent  key={el.inputId} inputId ={el.inputId} inputUUID={el.inputUUID}  options={el.options}    defaultValue={el.defaultValue} inputName={el.inputName} type={el.inputType} label={el.label} value={el.value} parentHandler={this.handleOnBlurInput} radios={el.radios} question={el.question}/>
            })

          }
                                        </div>
                                    </div>
                                </div>
                    </div>

               

              

            </div>
            

     
            
            
            
            
            
        
       
        );
    }
}

export default Veriler;