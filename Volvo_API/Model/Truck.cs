using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Volvo_API.Models
{
    public class Truck
    {
        public long Id { get; set; }
        public int FabricationYear { get; set; }
        public int ModelYear { get; set; }

        public long TruckModelId { get; set; }
        public TruckModel TruckModel { get; set; }

        public string SerialNumber { get; set; }
    }
}
