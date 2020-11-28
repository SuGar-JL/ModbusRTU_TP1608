using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Entiry.Bluetooth_Gateway
{
    public class BluetoothGateway
    {
        public string Gateway { get; set; }
        public string NodeId { get; set; }
        public string SystemId { get; set; }
        public string Type { get; set; }
        public BluetoothBeacon[] online { get; set; }


    }

    public class BluetoothBeacon
    {
        public string addr { get; set; }
        public string adv { get; set; }
        public string advType { get; set; }
        public string nodeType { get; set; }
        public string rssi { get; set; }

    }
}
