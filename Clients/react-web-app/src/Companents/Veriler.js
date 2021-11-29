import React from "react"; 
import InputCompanent from '../Companents/InputCompanent';
import rop_axios from '../js/identityServerClient/rop_axios.js';
class Veriler extends React.Component {
    constructor(props){
        super(props);
        this.state = {
          data: []
        }
      }
    getData(){
        setTimeout(async () => { 
          var inputresponse = await rop_axios.get("/staticdata"); 
          this.setState({
            data: inputresponse.data
          })
        }, 1000)
      }
    
      componentDidMount(){
        this.getData();
      }
      handleOnBlurInput = (value, key ) => { 
          console.log("Değer:  "+ value +" Id:    "+ key) 
          rop_axios.post(`/staticdata/staticdatas`, {
           key:key,
           value:value
          });
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