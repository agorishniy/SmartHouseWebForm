using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse.Models
{
    public class Param
    {
        public Param(byte Value, byte Min, byte Max)
        {
            min = Min;
            max = Max;
            value = Value;
        }

        private byte min;
        private byte max;

        private byte value;
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