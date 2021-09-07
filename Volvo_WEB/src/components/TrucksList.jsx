import React, { useState, useEffect } from "react";
import TruckDataService from "../services/TruckService";
import { Link } from "react-router-dom";

const TrucksList = () => {
  const [Trucks, setTrucks] = useState([]);
  const [currentTruck, setCurrentTruck] = useState(null);
  const [currentIndex, setCurrentIndex] = useState(-1);

  useEffect(() => {
    retrieveTrucks();
  }, []);

  const retrieveTrucks = () => {
    TruckDataService.getAll()
      .then(response => {
        setTrucks(response.data);
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  };

  const setActiveTruck = (Truck, index) => {
    setCurrentTruck(Truck);
    setCurrentIndex(index);
  };

  return (
    <div className="row">
      <div className="col-md-8">
        <h4>Trucks List</h4>

        <ul className="list-group">
          {Trucks &&
            Trucks.map((Truck, index) => (
              <li
                className={
                  "list-group-item " + (index === currentIndex ? "active" : "")
                }
                onClick={() => setActiveTruck(Truck, index)}
                key={index}
              >
                <span>{Truck.serialNumber} - {Truck.truckModel.model} - {Truck.fabricationYear}/{Truck.modelYear}</span>
              </li>
            ))}
        </ul>
      </div>
      <div className="col-md-4">
        {currentTruck ? (
          <div>
            <h4>Truck</h4>
            <div>
              <label>
                <strong>ID:</strong>
              </label>{" "}
              {currentTruck.id}
            </div>
            <div>
              <label>
                <strong>Fabrication Year:</strong>
              </label>{" "}
              {currentTruck.fabricationYear}
            </div>
            <div>
              <label>
                <strong>Truck Model:</strong>
              </label>{" "}
              {currentTruck.truckModel.model}
            </div>
            <div>
              <label>
                <strong>Model Year:</strong>
              </label>{" "}
              {currentTruck.modelYear}
            </div>
            <div>
              <label>
                <strong>Serial Number:</strong>
              </label>{" "}
              {currentTruck.serialNumber}
            </div>
            <Link
              to={"/Trucks/" + currentTruck.id}
              className="badge badge-warning"
            >
              Edit
            </Link>
          </div>
        ) : (
          <div>
            <br />
            <p>Please click on a Truck...</p>
          </div>
        )}
      </div>
    </div>
  );
};

export default TrucksList;