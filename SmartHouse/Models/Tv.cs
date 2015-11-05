namespace SmartHouse.Models
{
    public class Tv : Device, IDevBright, IDevVolume 
    {
        private Param bright;
        private Param volume;
        private Channels channel;

        public Tv(string nameTv, bool stateTv, Channels channelCur, byte volumeCur, byte brightCur)
            : base(nameTv, stateTv)
        {
            channel = channelCur;
            volume = new Param(volumeCur, 1, 5);
            bright = new Param(brightCur, 1, 5);
        }

        public Param Bright
        {
            get
            {
                return bright;
            }
        }

        public Param Volume
        {
            get
            {
                return volume;
            }
        }

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