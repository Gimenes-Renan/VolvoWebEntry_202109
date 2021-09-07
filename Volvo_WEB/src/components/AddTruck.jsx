import React, { useState, useEffect } from "react";
import TruckDataService from "../services/TruckService";
import TruckModelDataService from "../services/TruckModelService";

const AddTruck = () => {
  const initialTruckState = {
    id: null,
    fabricationYear: 0,
    modelYear: 0,
    truckModelId: 0,
    serialNumber:""
  };

  const [Truck, setTruck] = useState(initialTruckState);
  const [TruckModel, setTruckModel] = useState([]);
  const [submitted, setSubmitted] = useState(false);
  const [message, setMessage] = useState("");

  useEffect(() => {
    retrievetruckModels();
  }, []);

  const retrievetruckModels = () => {
    TruckModelDataService.getAll()
      .then(response => {
        setTruckModel(response.data);
        console.log(response.data);
        setMessage("");
      })
      .catch(e => {
        console.log(e);
        setMessage("Failed to load Truck Models..." + {e})
      });
  };

  const handleInputChange = event => {
    const { name, value } = event.target;
    setTruck({ ...Truck, [name]: value });
  };

  const saveTruck = () => {
    var data = {
      fabricationYear: Truck.fabricationYear,
      modelYear: Truck.modelYear,
      truckModelId: Truck.truckModelId,
      serialNumber: Truck.serialNumber
    };

    if(Truck.truckModelId == 0){
      setMessage("Model not selected");
      return;
    } else {
      setMessage("");
    }

    TruckDataService.create(data)
      .then(response => {
        setTruck({
          id: response.data.id,
          fabricationYear: response.data.fabricationYear,
          modelYear: response.data.modelYear,
          truckModelId: response.data.truckModelId,
          serialNumber: response.data.serialNumber
        });
        setSubmitted(true);
        setMessage("");
        console.log(response.data);
      })
      .catch(e => {
        setMessage(e.response.data);
        console.log(e);
      });
  };

  const newTruck = () => {
    setTruck(initialTruckState);
    setSubmitted(false);
  };

  return (
    <div className="submit-form">
      {submitted ? (
        <div>
          <h4>You submitted successfully!</h4>
          <button className="btn btn-success" onClick={newTruck}>
            Add
          </button>
        </div>
      ) : (
        <div>
          <div className="form-group">
            <label htmlFor="fabricationYear">Fabrication Year</label>
            <input
              type="text"
              className="form-control"
              id="fabricationYear"
              required
              value={Truck.fabricationYear}
              onChange={handleInputChange}
              name="fabricationYear"
            />
          </div>

          <div className="form-group">
            <label htmlFor="modelYear">Model Year</label>
            <input
              type="text"
              className="form-control"
              id="modelYear"
              required
              value={Truck.modelYear}
              onChange={handleInputChange}
              name="modelYear"
            />
          </div>
          <div className="form-group">
            <label htmlFor="serialNumber">Serial Number</label>
            <input
              type="text"
              className="form-control"
              id="serialNumber"
              required
              value={Truck.serialNumber}
              onChange={handleInputChange}
              name="serialNumber"
            />
          </div>
          <div className="form-group">
          <label htmlFor="truckModelId">Model</label>
            <select className="form-control" name="truckModelId" onChange={handleInputChange}>
            <option name="truckModelId" value={0}>Select model</option>
              {TruckModel.map((item, index) => <option key={index} name="truckModelId" value={item.id}>{item.id} - {item.model}</option>)}
            </select>
          </div>
          <div>
            {message.length > 0 && <p style={{color:'red'}}>Ops... Error: {message}</p>}
          </div>
          <button onClick={saveTruck} className="btn btn-success">
            Submit
          </button>
        </div>
      )}
    </div>
  );
};

export default AddTruck;