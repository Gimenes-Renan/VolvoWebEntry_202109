import React, { useState, useEffect } from "react";
import TruckDataService from "../services/TruckService";
import TruckModelDataService from "../services/TruckModelService";

const Truck = props => {
  const initialTruckState = {
    id: null,
    fabricationYear: "",
    modelYear: "",
    truckModelId: "",
    modelYear: "",
    serialNumber: "",
    truckModel: {
      id:null,
      model:""
    }
  };
  const [currentTruck, setCurrentTruck] = useState(initialTruckState);
  const [message, setMessage] = useState("");
  const [TruckModel, setTruckModel] = useState([]);

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
        setMessage("Ops... Error:" + {e})
      });
  };

  const getTruck = id => {
    TruckDataService.get(id)
      .then(response => {
        setCurrentTruck(response.data);
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  };

  useEffect(() => {
    getTruck(props.match.params.id);
  }, [props.match.params.id]);

  const handleInputChange = event => {
    const { name, value } = event.target;
    setCurrentTruck({ ...currentTruck, [name]: value });
  };

  const updateTruck = () => {
    TruckDataService.update(currentTruck.id, currentTruck)
      .then(response => {
        console.log(response.data);
        setMessage("The Truck was updated successfully!");
      })
      .catch(e => {
        console.log(e);
      });
  };

  const deleteTruck = () => {
    TruckDataService.remove(currentTruck.id)
      .then(response => {
        console.log(response.data);
        props.history.push("/Trucks");
      })
      .catch(e => {
        console.log(e);
      });
  };

  return (
    <div>
      {currentTruck ? (
        <div className="edit-form">
          <form>
            <div className="form-group">
              <label htmlFor="id">ID</label>
              <input
                type="text"
                className="form-control"
                id="id"
                name="id"
                value={currentTruck.id}
                onChange={handleInputChange}
                disabled
              />
            </div>
            <div className="form-group">
              <label htmlFor="fabricationYear">Fabrication Year</label>
              <input
                type="text"
                className="form-control"
                id="fabricationYear"
                name="fabricationYear"
                value={currentTruck.fabricationYear}
                onChange={handleInputChange}
                disabled
              />
            </div>

            <div className="form-group">
              <label htmlFor="modelYear">Model Year</label>
              <input
                type="text"
                className="form-control"
                id="modelYear"
                name="modelYear"
                value={currentTruck.modelYear}
                onChange={handleInputChange}
                disabled
              />
            </div>

            <div className="form-group">
              <label htmlFor="serialNumber">Serial Number</label>
              <input
                type="text"
                className="form-control"
                id="serialNumber"
                name="serialNumber"
                value={currentTruck.serialNumber}
                onChange={handleInputChange}
              />
            </div>

            <div className="form-group">
            <label htmlFor="truckModelId">Model</label>
            <select className="form-control" name="truckModelId" value={currentTruck.truckModelId} onChange={handleInputChange}>
              {TruckModel.map((item, index) => <option key={index} name="truckModelId" value={item.id}>{item.id} - {item.model}</option>)}
            </select>
          </div>

          </form>

          <button className="badge badge-danger mr-2" onClick={deleteTruck}>
            Delete
          </button>

          <button
            type="submit"
            className="badge badge-success"
            onClick={updateTruck}
          >
            Update
          </button>
          <p>{message}</p>
        </div>
      ) : (
        <div>
          <br />
          <p>Please click on a Truck...</p>
        </div>
      )}
    </div>
  );
};

export default Truck;