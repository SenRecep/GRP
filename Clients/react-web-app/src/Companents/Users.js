import React from "react";  
// import { Datatable } from 'react-semantic-ui-datatable';
import { Modal, Button } from 'semantic-ui-react' 
import { ThemeProvider } from "@mui/styles";
import { createTheme, responsiveFontSizes } from '@mui/material/styles';
import MUIDataTable from "mui-datatables";
class Users extends React.Component {
    constructor(props){
      super(props) 
      this.state = {  
        muidata:[
          { id:"1",name: "Joe James", company: "Test Corp", city: "Yonkers", state: "NY" },
          { id:"2", name: "John Walsh", company: "Test Corp", city: "Hartford", state: "CT" },
          { id:"3", name: "Bob Herm", company: "Test Corp", city: "Tampa", state: "FL" },
          { id:"4", name: "James Houston", company: "Test Corp", city: "Dallas", state: "TX" },
          { id:"5", name: "James Houston", company: "Test Corp", city: "Dallas", state: "TX" },
          { id:"6", name: "James Houston", company: "Test Corp", city: "Dallas", state: "TX" },
          { id:"7", name: "James Houston", company: "Test Corp", city: "Dallas", state: "TX" },
          { id:"8", name: "James Houston", company: "Test Corp", city: "Dallas", state: "TX" },
          { id:"9", name: "James Houston", company: "Test Corp", city: "Dallas", state: "TX" },
          { id:"10", name: "James Houston", company: "Test Corp", city: "Dallas", state: "TX" },
          { id:"11", name: "James Houston", company: "Test Corp", city: "Dallas", state: "TX" },
          { id:"12", name: "James Houston", company: "Test Corp", city: "Dallas", state: "TX" },
          { id:"13", name: "James Houston", company: "Test Corp", city: "Dallas", state: "TX" },
          { id:"14", name: "James Houston", company: "Test Corp", city: "Dallas", state: "TX" },
          { id:"15", name: "James Houston", company: "Test Corp", city: "Dallas", state: "TX" },
          { id:"16", name: "James Houston", company: "Test Corp", city: "Dallas", state: "TX" },
          { id:"17", name: "James Houston", company: "Test Corp", city: "Dallas", state: "TX" },
          { id:"18", name: "James Houston", company: "Test Corp", city: "Dallas", state: "TX" },
         ]
      };
    }
     
    refreshTable=() => { 
      this.setState({ muidata:[
          { id:"1",name: "Joe James", company: "Test Corp", city: "Yonkers", state: "NY" },
          { id:"2", name: "John Walsh", company: "Test Corp", city: "Hartford", state: "CT" }
         ]})
    }

    redirectEditUser=(id) => { 
      this.props.history.push(`/UserEdit/${id}`)
    }

    deleteUser=(id) => { 
      console.log(id); 
    }

    render() {
      
       
      
      let theme = createTheme();
      theme = responsiveFontSizes(theme);
      const columns = [
        {
          name: "id",
          options: {
          display: false,
          }
        },
        {
          name: "name",
          label: "Name",
          options: {
            filter: true,
            sort: true,
           }
         },
         {
          name: "company",
          label: "Company",
          options: {
            filter: true,
            sort: true,
           }
         },
         {
          name: "city",
          label: "City",
          options: {
            filter: true,
            sort: true,
           }
         },
         {
          name: "state",
          label: "State",
          options: {
            filter: true,
            sort: true,
           }
         },
         {
          name: "Actions",
          label: "Actions",
          options: {
              customBodyRender: (value, tableMeta, updateValue) => { 
                  return (
                   
                    <>
                    <Button className="action-btn" onClick={() => this.redirectEditUser(tableMeta.rowData[0])} circular primary icon='edit' />
                    <Modal trigger={ <Button className="action-btn" circular negative icon='trash' />} header='Dikkat!' content={`${tableMeta.rowData[1]} silmek istediğinizden emin misiniz?`} actions={['İptal', { key: 'done', content: 'Sil', negative: true, onClick:() => this.deleteUser(tableMeta.rowData[0])}]} /> 
                    </>
                  )
              }
          }
        }
    ];
 
      
      const options = { 
        selectableRows: 'none',
        download: false,
        print: false
      };
      
         
        return (
     
           
 
           
            <div className="container-fluid">

              
                

               
                <div className="row">
        
                    <div className="col-xl-12 col-lg-12">
                                    <div className="card shadow mb-4"> 
                                      
                                        <div className="card-body">
                                            <h1>Users</h1>
                                            {/* <Datatable sortable paginated columns={colDefs} datasource={this.state.datasource} serverSide onQueryChange={this.initialData}/> */}
                                            {/* <Button content='Next' icon='right arrow' onClick={this.refreshData}/>  */}
                                            <div className="row">

                                            <ThemeProvider theme={theme}>
                                                <MUIDataTable
                                                    title={"Employee List"}
                                                    data={this.state.muidata}
                                                    columns={columns}
                                                    options={options}
                                                  />
                                            </ThemeProvider>
                                            <Button content='Next' icon='right arrow' onClick={this.refreshTable}/> 
                                            </div>
                                            
                                            
           

                                        </div>
                                    </div>
                                </div>
                    </div>

               

              

            </div>
            

       
            
            
            
            
        );
    }
}

export default Users;