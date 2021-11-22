import React, { Component } from 'react';
import {Link} from 'react-router-dom';   
import logo from '../logo.svg';

class SideBar extends Component {
    render() { 
        return (
            <ul className="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">
                    
                     
                       <div className="sidebar-brand d-flex align-items-center justify-content-center" >
                       <center>
                           <img className="sidebar-card-illustration mb-2" src={logo} alt="logo" style={{width:'120px',marginTop:'40px'}}/>
                            </center>
                           
                       </div>
            
           
                       <hr className="sidebar-divider"  style={{marginTop:'40px'}}/>
                       <li className="nav-item">
                       <Link  className="nav-link"  to="/">  
                       <i className="fas fa-fw fa-tachometer-alt"></i> Grp Hesapla    
                      </Link>
                     
                       </li> 
                       <hr className="sidebar-divider" />
                       <li className="nav-item">
                       <Link  className="nav-link"  to="/Users">  
                       <i className="fas fa-fw fa-tachometer-alt"></i> Users    
                      </Link>
                     
                       </li> 
                     
                       <hr className="sidebar-divider" />
                       <li className="nav-item">
                       <Link  className="nav-link"  to="/Veriler">  
                       <i className="fas fa-fw fa-tachometer-alt"></i> Veriler    
                      </Link>
                     
                       </li> 
                       
             </ul>



        );
    }
}

export default SideBar;