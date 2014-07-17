namespace LicencjatInformatyka_RMSE_.NewFolder2
{
    public class Argument
    {
        public string ArgumentName { get; set; }
        public string Value { get; set; }

        public Argument()
        { }
        public Argument(string argument, string value)
        {
            this.ArgumentName = argument;
            this.Value = value;
        }
    }
}
