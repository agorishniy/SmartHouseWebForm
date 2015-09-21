namespace SmartHouse.Models
{
    abstract public class Device : IDevice
    {
        public Device(string Name, bool State)
        {
            name = Name;
            state = State;
        }

        protected string name;
        public string Name
        {
            get
            {
                return name;
            }
        }

        abstract public string Type { get; }

        protected bool state;

        public bool State
        {
            get
            {
                return state;
            }
        }

        public void OnOff()
        {
            if (state)
            {
                state = false;
            }
            else
            {
                state = true;
            }
        }
    }
}
