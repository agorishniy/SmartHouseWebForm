namespace SmartHouse.Models
{
    public class Louvers : Device, IDevOpen
    {
        override public string Type
        {
            get
            {
                return "louvers";
            }
        }

        private Param open;

        public Param Open
        {
            get
            {
                return open;
            }
        }

        public Louvers(string Name, bool State, byte Open)
            : base(Name, State)
        {
            open = new Param(Open, 0, 2);
        }

    }
}