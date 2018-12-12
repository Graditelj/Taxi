using System;
using System.Collections.Generic;

namespace TaxiDispatcher.App.Models
{
    public class Taxi
    {
        #region Properties

        public TaxiDriver Driver { get; set; }
        public TaxiCompany Company { get; set; }
        public int Location { get; set; }

        #endregion
    }
}
