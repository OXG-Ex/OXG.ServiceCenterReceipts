using System;

namespace OXG.ServiceCenterReceipts
{
    static class Master
    {
        static public string Name { get; set; }
        static public double Percent { get; set; }
        static Master()
        {
            Name = "Default";
            Percent = 0.4;
        }
    }
}
