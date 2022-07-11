import React from 'react'
import axios from "axios";
import { useState, useEffect } from "react";
import Table from 'react-bootstrap/Table'; 
import 'bootstrap/dist/css/bootstrap.min.css';
import {Modal} from 'react-bootstrap';
 

function Items() {
const [show, setShow] = useState(false);

const [id, setId] = useState(0);
const [itemName, setItemName] = useState('');
const [itemDescription, setItemDescription] = useState('');
const [itemStatus, setItemStatus] = useState(0);
const [editItem, setEditItem] = useState(false);
 
const [items, setItems] = useState([]);
const apiEndPoint = 'http://localhost:5257/api/Items';

useEffect(() => {
    
    getItems();
  }, []);

  const getItems = async () => {
    const { data: res } = await axios.get(apiEndPoint)      
    .catch((err) => {
      console.log("Err: ", err);
    });
    setItems(res);
  };
 

  const addOrUpdateItems = async (e) => {   
    e.preventDefault();

    if(editItem == true)
    {
      const post = { 
        id : id,
        itemName: itemName,
        itemDescription: itemDescription,
        itemStatus: Number(itemStatus),       
        itemCreatedDate:new Date()   
      };
      
      try
      {
        await axios.put(apiEndPoint, post);       
      }
      catch(err)
      {        
        console.log("Err: ", err);
      }

    }
    else
    {
      const post = { 
        itemName: itemName,
        itemDescription: itemDescription,
        itemStatus: Number(itemStatus),       
        itemCreatedDate:new Date()         
      };
      
      try
      {
        await axios.post(apiEndPoint, post);
      }
      catch(err)
      {       
        console.log("Err: ", err);
      }
    }

    handleClose();
    getItems();  
      
  };


  const handleDelete = async (items) => {
    await axios.delete(apiEndPoint + "/" + items.id )
    .catch((err) => {
        console.log("Err: ", err);
      });     
      getItems();     
  };

  const showModal = async () => 
  {
    setShow(true);
  };

  const showEditModal = async (item) => 
  {    
    setShow(true);
    setEditItem(true);

    setId(item.id);
    setItemName(item.itemName);
    setItemDescription(item.itemDescription);

    setItemStatus(item.itemStatus);
  };

  const itemNameOnChange = (event) => 
  {   
    setItemName(event.target.value);
  };

  const itemDescriptionOnChange = (event) => 
  {
    setItemDescription(event.target.value);
  }; 

  const itemStatusOnChange = (event) => {
    setItemStatus(event.target.value);
  };


  const handleClose = () => setShow(false);

    return (
        <div className="container">
            <h3> My Todo Items </h3>

            <div className="container">
          <div className="row">
              <div className="col-md-12 bg-light text-left">
              <button onClick={() => showModal(items)}  className="btn btn-primary">Add New Item</button>
              </div>
          </div>
      </div>

            <Modal show={show} onHide={() => handleClose()}>

            <Modal.Header closebutton>
                <Modal.Title>Add Todo Items</Modal.Title>
            </Modal.Header>

            <Modal.Body>
              <div className="form-group">
                <label for="inputItemName">Item Name</label>
                <input value={itemName} onChange={itemNameOnChange} type="text" className="form-control" id="inputItemName" placeholder="Enter Name"/>
                 </div>
              <div className="form-group">
                <label for="inputItemDescription">Item Description</label>
                <input value={itemDescription} onChange={ itemDescriptionOnChange}  type="text" className="form-control" id="inputItemDescription" placeholder="Enter Description"/>
              </div>

              <div class="form-group">
            <label for="inputItemStatus">Item Status</label>
           <select value={itemStatus} onChange={itemStatusOnChange}>
            <option value="0">Incomplete</option>
            <option value="1">Complete</option>       
          </select>

          </div>
               
            </Modal.Body>

            <Modal.Footer>
                <button variant="secondary" onClick={() => handleClose()}>
                    Close
                </button>
                <button variant="primary" onClick={addOrUpdateItems}>
                    Submit
                </button>
            </Modal.Footer>

          </Modal>

            <Table striped bordered hover>
              <thead>
                 <th>Item Id</th>
                  <th>Item Name</th>
                  <th>Item Description</th>
                  <th>Item Status</th>        
                  <th>Actions</th>          
              </thead>
              <tbody>
            {items.map((items,index) => (
              <tr key={index}>
                <td> {items.id} </td>
                <td> {items.itemName} </td> 
                <td> {items.itemDescription} </td>
                <td> {items.itemStatus} </td>                    
                <td>
                  <button
                    onClick={() => showEditModal(items)}
                    className="btn btn-primary" 
                  >
                    Edit
                  </button>
                  <button
                    onClick={() => handleDelete(items)}
                    className="btn btn-danger btn-sm"
                  >
                    Delete
                  </button>
                </td>               
              </tr>
            ))}
          </tbody>
          </Table>
      </div>
    );
  }
  
  export default Items;