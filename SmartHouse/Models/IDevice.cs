namespace SmartHouse.Models
{
    public interface IDevice
    {
        string Name
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
