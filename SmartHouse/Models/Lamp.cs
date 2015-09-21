namespace SmartHouse.Models
{
    public class Lamp : Device
    {
        override public string Type
        {
            get
            {
                return "lamp";
            }
        }

        public Lamp(string Name, bool State)
            : base(Name, State)
        {
        }
    }


}