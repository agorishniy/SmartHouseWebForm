namespace SmartHouse.Models
{
    public class Fan : Device, IDevSpeed
    {
        private Param speed;

        public Fan(string nameDev, bool stateDev, byte speedFan)
            : base(nameDev, stateDev)
        {
            speed = new Param(speedFan, 1, 5);
        }

        public Param Speed
        {
            get
            {
                return speed;
            }
        }

        public Param Param
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}