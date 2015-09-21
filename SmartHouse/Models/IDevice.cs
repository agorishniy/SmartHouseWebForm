namespace SmartHouse.Models
{
    public interface IDevice
    {
        string Name
        {
            get;
        }

        string Type
        {
            get;
        }

        bool State
        {
            get;
        }

        void OnOff();
    }

}
