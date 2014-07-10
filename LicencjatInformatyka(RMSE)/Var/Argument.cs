namespace LicencjatInformatyka_RMSE_.NewFolder2
{
    public class Argument
    {
        private string ArgumentName { get; set; }
        private float Value { get; set; }

        public Argument(string argument, float value)
        {
            this.ArgumentName = argument;
            this.Value = value;
        }
    }
}
