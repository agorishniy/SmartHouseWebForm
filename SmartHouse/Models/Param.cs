using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse.Models
{
    public class Param
    {
        private byte min;
        private byte max;
        private byte value;

        public Param(byte valueCurrent, byte minVal, byte maxVal)
        {
            min = minVal;
            max = maxVal;
            value = valueCurrent;
        }


        public byte Value
        {
            get
            {
                return value;
            }
        }

        public void Up()
        {
            if (value < max)
                value++;
        }

        public void Down()
        {
            if (value > min)
                value--;
        }
    }
}