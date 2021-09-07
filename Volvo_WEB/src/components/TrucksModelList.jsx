import React, { useState, useEffect } from "react";
import truckModelDataService from "../services/truckModelService";

const truckModelsList = () => {
  const [truckModels, settruckModels] = useState([]);
  const [currenttruckModel, setCurrenttruckModel] = useState(null);
  const [currentIndex, setCurrentIndex] = useState(-1);

  useEffect(() => {
    retrievetruckModels();
  }, []);

  const retrievetruckModels = () => {
    truckModelDataService.getAll()
      .then(response => {
        settruckModels(response.data);
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  };

  const refreshList = () => {
    retrievetruckModels();
    setCurrenttruckModel(null);
    setCurrentIndex(-1);
  };

  const setActivetruckModel = (truckModel, index) => {
    setCurrenttruckModel(truckModel);
    setCurrentIndex(index);
  };


  return (
    <div className="list row">
      <div className="col-md-8">
      </div>
      <div className="col-md-6">
        <h4>truckModels List</h4>

        <ul className="list-group">
          {truckModels &&
            truckModels.map((truckModel, index) => (
              <li
                className={
                  "list-group-item " + (index === currentIndex ? "active" : "")
                }
                onClick={() => setActivetruckModel(truckModel, index)}
                key={index}
              >
                {truckModel.fabricationYear}
              </li>
            ))}
        </ul>

        <button
          className="m-3 btn btn-sm btn-danger"
          onClick={removeAlltruckModels}
        >
          Remove All
        </button>
      </div>
      <div className="col-md-6">
        {currenttruckModel ? (
          <div>
            <h4>truckModel</h4>
            <div>
              <label>
                <strong>ID:</strong>
              </label>{" "}
              {currenttruckModel.id}
            </div>
            <div>
              <label>
                <strong>Model:</strong>
              </label>{" "}
              {currenttruckModel.model}
            </div>
          </div>
        ) : (
          <div>
            <br />
            <p>Please click on a truckModel...</p>
          </div>
        )}
      </div>
    </div>
  );
};

export default truckModelsList;