namespace SmartHouse.Models
{
    abstract public class Device : IDevice
    {
        protected string name;
        protected bool state;

        public Device(string nameDev, bool stateDev)
        {
            name = nameDev;
            state = stateDev;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

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
