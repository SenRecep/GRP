import React from 'react';   
import { Dropdown, Input, Checkbox, Radio } from 'semantic-ui-react';
import ReactDOM from 'react-dom';
class InputCompanent extends React.Component{
    constructor(props) {
        super(props); 
        if (this.props.type === 'radiogroup') { 
            this.state = {radioValue:this.props.defaultValue}; 
        }
        if (this.props.type === 'checkbox') {
            this.state = {checkValue:this.props.defaultValue};
        }
        if (this.props.type === 'text') {
            this.state = {textValue:this.props.defaultValue};
        }
        if (this.props.type === 'number') {
            this.state = {numberValue:this.props.defaultValue};
        }
        if (this.props.type === 'select') {
            this.state = {selectValue:this.props.defaultValue};
        } 
       
      } 

    
    
    textValueChange=(e) => { 
        this.setState({
            textValue: e.target.value
        },()=>this.props.parentHandler(this.state.textValue, e.target.id));  
        
      }
      numberValueChange=(e) => { 
        this.setState({
            numberValue: e.target.value
        },()=>this.props.parentHandler(this.state.numberValue, e.target.id));  
        
      }
   
      radioValueChange = (e, {value}) => 
      {
          let node=ReactDOM.findDOMNode(e.target).parentNode; 
        this.setState({radioValue:value },()=>this.props.parentHandler(this.state.radioValue,ReactDOM.findDOMNode(node).childNodes[0].name))
      }
      selectValueChange = (e, value) => 
      {
          
        this.setState({selectValue:value.value },()=>this.props.parentHandler(this.state.selectValue, value.id))
      }
     
      checkValueChange=(e) => {
        this.setState({
            checkValue: e.target.checked
        },()=>this.props.parentHandler(this.state.checkValue, e.target.id));  
      }
      
   
    
    render(){  
        return(

            <div key={this.props.inputId}>
                {
                    this.props.type==='checkbox' ? 
                    <Checkbox label={this.props.label} data-key={this.props.inputName} defaultChecked = {this.state.checkValue}  id={this.props.inputUUID} onChange = {e => this.checkValueChange(e,this.props.inputUUID)} /> // kontrollü elemente nasıl çevrilir araştırılcak
                    : this.props.type==='text' ? 
                    <Input placeholder='Search...'   type="text" data-key={this.props.inputName}  defaultValue={this.state.textValue}   onBlur={e => this.textValueChange(e)} id={this.props.inputUUID} />
                   
                     : this.props.type==='number' ? 
                     <Input placeholder='Search...' type="number"  data-key={this.props.inputName}  defaultValue={this.state.numberValue}  onBlur={e => this.numberValueChange(e)}   id={this.props.inputUUID}  />
                      
                    : this.props.type==='radiogroup' ? 
                   
                        <>
 
                        <p>{this.props.question}</p>
 
                        {
                              this.props.radios.map((radio,key)=>
                        
                              {
                              
                                return <div  key={key}> <Radio  label={radio.label}  name={this.props.inputUUID}  value={radio.value}  checked={this.state.radioValue === radio.value} onChange={this.radioValueChange}  /> </div>
                                
                              }   
                                 
                              ) 
                        }
 





                        </>

                  



                    : this.props.type==='select' ? 
                    <>
                    <p>{this.props.label}</p>
                    <Dropdown onChange={this.selectValueChange} placeholder={this.props.label} defaultValue={this.state.selectValue }  id={this.props.inputUUID}   options={this.props.options}  selection /> 
                    </>
                    : console.log("boş")
                }
            </div>

        ) 
      }
      

}
export default InputCompanent; 