﻿using System;

namespace Shares.Model
{
    public class ShareDay
    {
        public byte[] Bytes { get; set; }
        public Tf Tf { get; set; }
        public Byte Unknown1 { get; set; }
        public DateTime Date { get; set; }
        public Decimal Open { get; set; }
        public Decimal High { get; set; }
        public Decimal Low { get; set; }
        public Decimal Close { get; set; }
        public UInt32 Volume { get; set; }
        public UInt16 OpenInt { get; set; }
        public Byte[] Unknown2 { get; set; }
        public int Row { get; set; }

        public ShareDay ShallowClone()
        {
            return (ShareDay) MemberwiseClone();
        }

        public ShareDay DeepClone()
        {
            return ShallowClone();
        }

        public override string ToString()
        {
            var fields = new[]
            {
                ((byte)Tf).ToString("X"),
                Date.ToString("yyyyMMdd"),
                Open.ToString("00.000"),
                High.ToString("00.000"),
                Low.ToString("00.000"),
                Close.ToString("00.000"),
                Volume.ToString("00000000"),
                OpenInt.ToString("00000")
            };

            return String.Join("  ", fields);
        }
    }
}