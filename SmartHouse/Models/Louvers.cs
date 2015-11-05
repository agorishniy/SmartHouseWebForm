namespace SmartHouse.Models
{
    public class Louvers : Device, IDevOpen
    {
        private Param open;

        public Louvers(string nameDev, bool stateDev, byte openPercent)
            : base(nameDev, stateDev)
        {
            open = new Param(openPercent, 0, 2);
        }

        public Param Open
        {
            get
            {
                return open;
            }
        }
    }
}