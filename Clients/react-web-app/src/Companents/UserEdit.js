import React from 'react';
import axios from 'axios';
class UserEdit extends React.Component{
    constructor(props){
        super(props);
        this.state = {userr:''};
    }
    async componentDidMount(){
        let userId=this.props.match.params.user
        let response=await axios.get(`https://jsonplaceholder.typicode.com/users/${userId}`);
        
        this.setState({
            user: response.data.name
        }) 
    }
    render() {

     

        return (
        
           
 
           
            <div className="container-fluid">

              
                

               
                <div className="row">
        
                    <div className="col-xl-12 col-lg-12">
                                    <div className="card shadow mb-4"> 
                                      
                                        <div className="card-body">
                                            <h1>{this.state.user}</h1>
                                        </div>
                                    </div>
                                </div>
                    </div>

               

              

            </div>
            

       
            
            
            
        );
    }
}

export default UserEdit;