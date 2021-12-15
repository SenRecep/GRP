import React from "react"; 
import InputCompanent from '../Companents/InputCompanent';
import rop_axios from '../js/identityServerClient/rop_axios.js';
class Veriler extends React.Component {
    constructor(props){
        super(props);
        this.state = {
          products: [],
          rats:[],
          constants:{}
        }
      }
    getData(){
        setTimeout(async () => { 
          var inputresponse = await rop_axios.get("/watertankcalculator/Defaults"); 
          this.setState({
            products: inputresponse.data.products,
            rats: inputresponse.data.rats,
            constants:inputresponse.data.constants
          })
        }, 1000)
      }
    
      componentDidMount(){
        this.getData();
      }

      handleConstantsInput = async (value, key ) => { 
        console.log("Değer:  "+ value +" Id:    "+ key) 
        var constants= this.state.constants;
        if(constants){
          constants[key]=value;
          var updateresponse= await rop_axios.put("/watertankcalculator/Defaults/constantupdate",constants);
          console.log(updateresponse);
        }
       
    }
      handleOnBlurInput = async (value, key ) => { 
          var product = this.state.products.find(x=>x.id==key);
          if(product){
            product.unitPrice=value;
            var updateresponse= await rop_axios.put("/watertankcalculator/Defaults/productUpdate",product);
            console.log(updateresponse);
          }
         
      }
      ratInputHandler= async(value,key)=>{
        var items=key.split('-');
        var prop=items.at(-1);
        var id=items.splice(0,items.length-2).join('-');
        var rat=this.state.rats.find(x=>x.id==id);
        if(rat){
          rat[prop]=value;
          var updateresponse= await rop_axios.put("/watertankcalculator/Defaults/ratupdate",rat);
          console.log(updateresponse);
        }
      }
    render() {
      var constants=this.state.constants;
      console.log(constants);
        return (

            
 
           
            <div className="container-fluid">

<div className="row">
        
        <div className="col-xl-12 col-lg-12">
                        <div className="card shadow mb-4"> 
                          
                            <div className="card-body">
                              {
   
              <InputCompanent  key={constants.id}  inputUUID={"grpKgPrice"}     defaultValue={constants.grpKgPrice}  type={'number'} label={"GRRP KG"} value={constants.grpKgPrice} parentHandler={  this.handleConstantsInput} />
              

                    }

{
   
   <InputCompanent  key={constants.id}  inputUUID={"transportation"}     defaultValue={constants.transportation}  type={'number'} label={"Nakliye"} value={constants.transportation} parentHandler={  this.handleConstantsInput} />
   

         }
                            </div>
                        </div>
                    </div>
        </div>
                

               
                <div className="row">
        
                    <div className="col-xl-12 col-lg-12">
                                    <div className="card shadow mb-4"> 
                                      
                                        <div className="card-body">
                                        {
            this.state.products.map(el=>{
               
              return <InputCompanent  key={el.id}  inputUUID={el.id}     defaultValue={el.unitPrice}  type={'number'} label={el.name} value={el.unitPrice} parentHandler={  this.handleOnBlurInput} />
            })

          }
                                        </div>
                                    </div>
                                </div>
                    </div>
                    

               


                    <div className="row">
        
        <div className="col-xl-12 col-lg-12">
                        <div className="card shadow mb-4"> 
                          
                            <div className="card-body">
                            {
this.state.rats.map(el=>{
   
  return <div className="row">
  <label>{el.name}</label>
  <InputCompanent  key={`${el.id}-${el.key}-dip`}    inputUUID={`${el.id}-${el.key}-dip`}     defaultValue={el.dip}  type={'number'} label={"Daldırma"} value={el.dip} parentHandler={  this.ratInputHandler} />
  <InputCompanent  key={`${el.id}-${el.key}-dkps`}     inputUUID={`${el.id}-${el.key}-dkps`}     defaultValue={el.dkps} type={'number'} label={"DKP Sac"} value={el.dkps} parentHandler={  this.ratInputHandler} />
  <InputCompanent  key={`${el.id}-${el.key}-lc`}   inputUUID={`${el.id}-${el.key}-lc`}     defaultValue={el.lc} type={'number'} label={"lazer kesim"} value={el.lc} parentHandler={  this.ratInputHandler} />
  <InputCompanent  key={`${el.id}-${el.key}-weight`}   inputUUID={`${el.id}-${el.key}-weight`}     defaultValue={el.weight} type={'number'} label={"AĞIRLIK"} value={el.weight} parentHandler={  this.ratInputHandler} />
  <InputCompanent  key={`${el.id}-${el.key}-rub`}   inputUUID={`${el.id}-${el.key}-rub`}     defaultValue={el.rub} type={'number'} label={"Ovalama"} value={el.rub} parentHandler={  this.ratInputHandler} />

  </div>
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