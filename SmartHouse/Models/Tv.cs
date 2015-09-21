namespace SmartHouse.Models
{
    public class Tv: Device, IDevBright, IDevVolume 
    {
        override public string Type
        {
            get
            {
                return "tv";
            }
        }

        public Tv(string Name, bool State, Channels Channel, byte Volume, byte Bright)
            : base(Name, State)
        {
            channel = Channel;
            volume = new Param(Volume, 1, 5);
            bright = new Param(Bright, 1, 5);
        }

        private Param bright;

        public Param Bright
        {
            get
            {
                return bright;
            }
        }


        private Param volume;

        public Param Volume
        {
            get
            {
                return volume;
            }
        }



        private Channels channel;
        public Channels Channel
        {
            get
            {
                return channel;
            }
        }

        
        public void NextChannel()
        {
            if ((int)channel < System.Enum.GetValues(typeof(Channels)).Length - 1)
            {
                channel++;
            }
        }

        public void PreviousChannel()
        {
            if ((int)channel > 0)
            {
                channel--;
            }
        }

    }
}