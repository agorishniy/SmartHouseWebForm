namespace SmartHouse.Models
{
    public class Fan : Device, IDevSpeed
    {
        override public string Type
        {
            get
            {
                return "fan";
            }
        }

        private Param speed;

        public Param Speed
        {
            get
            {
                return speed;
            }
        }

        public Fan(string Name, bool State, byte Speed)
            : base(Name, State)
        {
            speed = new Param(Speed, 1, 5);
        }

    }
}