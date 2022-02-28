using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyExampleV1
{
    public enum Cities { Delhi, Mumbai, Chenni, Kolkata, Bengaluru, Hyderbad }
    public class Customer
    {
        public Customer(int CustId, string CustName, bool Status, double Balance, Cities City, string State)
        {
            this._custId = CustId; this._custName = CustName; this.City = City;
            this._Status = Status; this._Balance = Balance; this._State = State;
        }
        int _custId; string _custName; bool _Status;
        double _Balance; Cities _City; string _State;
        public int CustId { get { return _custId; } set { _custId = value; } }        
        public string CustName { get { return _custName; } set { if(Status == true) _custName = value; } }        
        public bool Status { get { return _Status; } set { _Status = value; } }       
        public double Balance { get { return _Balance; } 
            set 
            {
                //Status should be active and value should be greater than or equal to 500
                // Then only assignment will be done.
                if (Status == true && value >= 500) _Balance = value;
            } 
        }
        public Cities City { get { return _City; } set { if (Status == true) _City = value; } }
        public string State {  get { return _State; } protected set { if (Status == true) _State = value; } }
        //Auto-Implemented Property & Auto-Property Initializer 
        public string Country { get; } = "India";
    }
}
