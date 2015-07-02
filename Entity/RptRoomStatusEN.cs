using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{

    public class RptRoomStatusEN
    {
        public RptRoomStatusEN()
        {
            this.DateIndex = 0;
            this.RoomSku = string.Empty;
            this.Text = string.Empty;
            this.NumberCustomer = 0;
            this.ListCustomers = new List<string>();
            this.ListIDBookingR = new List<int?>();
            this.ListIDBookingRooms = new List<int?>();
        }

        private int _DateIndex;
        private string _RoomSku;
        private string _Text;
        private int _NumberCustomer;
        private List<string> _ListCustomers;
        private List<int?> _ListIDBookingR;
        private List<int?> _ListIDBookingRooms;

        public int DateIndex
        {
            get { return this._DateIndex; }
            set { this._DateIndex = value; }
        }
        public string RoomSku
        {
            get { return this._RoomSku; }
            set { this._RoomSku = value; }
        }

        public string Text
        {
            get { return this._Text; }
            set { this._Text = value; }
        }

        public int NumberCustomer
        {
            get { return this._NumberCustomer; }
            set { this._NumberCustomer = value; }
        }

        public List<string> ListCustomers
        {
            get { return this._ListCustomers; }
            set { this._ListCustomers = value; }
        }
        public List<int?> ListIDBookingR
        {
            get { return this._ListIDBookingR; }
            set { this._ListIDBookingR = value; }
        }
        public List<int?> ListIDBookingRooms
        {
            get { return this._ListIDBookingR; }
            set { this._ListIDBookingRooms = value; }
        }

    }

    public class RptRoomStatusForShowEN
    {
        public string CodeRoom{set ; get ; }
        public string Sku{set ; get ; }
        public int TotalCustomer{set ; get ; }

        public string Date1{set ; get ; }
        public string Date2{set ; get ; }
        public string Date3{set ; get ; }
        public string Date4{set ; get ; }
        public string Date5{set ; get ; }
        public string Date6{set ; get ; }
        public string Date7{set ; get ; }
        public string Date8{set ; get ; }

        public string Date9{set ; get ; }
        public string Date10{set ; get ; }
        public string Date11{set ; get ; }
        public string Date12{set ; get ; }
        public string Date13{set ; get ; }
        public string Date14{set ; get ; }
        public string Date15{set ; get ; }
        public string Date16{set ; get ; }

        public string Date17{set ; get ; }
        public string Date18{set ; get ; }
        public string Date19{set ; get ; }
        public string Date20{set ; get ; }
        public string Date21{set ; get ; }
        public string Date22{set ; get ; }
        public string Date23{set ; get ; }
        public string Date24{set ; get ; }

        public string Date25{set ; get ; }
        public string Date26{set ; get ; }
        public string Date27{set ; get ; }
        public string Date28{set ; get ; }

        public string Date29{set ; get ; }
        public string Date30{set ; get ; }
        public string Date31{set ; get ; }
     

    }

}
