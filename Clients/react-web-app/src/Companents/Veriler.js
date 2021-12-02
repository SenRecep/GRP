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
          var inputresponse = await rop_axios.get("/watertankcalculator/Defaults"); 
          this.setState({
            data: inputresponse.data.products
          })
        }, 1000)
      }
    
      componentDidMount(){
        this.getData();
      }
      handleOnBlurInput = (value, key ) => { 
          console.log("Değer:  "+ value +" Id:    "+ key) 
          // rop_axios.post(`/staticdata/staticdatas`, {
          //  key:key,
          //  value:value
          // });
      }
    render() {
        return (

            
 
           
            <div className="container-fluid">

              
                

               
                <div className="row">
        
                    <div className="col-xl-12 col-lg-12">
                                    <div className="card shadow mb-4"> 
                                      
                                        <div className="card-body">
                                        {
            this.state.data.map(el=>{
               
              return <InputCompanent  key={el.key} inputId ={el.id} inputUUID={el.id}     defaultValue={el.unitPrice} inputName={el.inputName} type={'number'} label={el.name} value={el.unitPrice} parentHandler={this.handleOnBlurInput} />
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