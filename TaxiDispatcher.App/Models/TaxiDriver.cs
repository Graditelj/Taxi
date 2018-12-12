namespace TaxiDispatcher.App.Models
{
    public class TaxiDriver
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }

        #endregion

        public static int IdCounter = 1;

        public TaxiDriver(string DriverName)
        {
            Id = IdCounter++;
            Name = DriverName;
        }
    }
}
