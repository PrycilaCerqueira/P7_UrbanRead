using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P7_UrbanRead
{
    internal class Booking
    {
        private Person _Requester;
        private Person _Requestee;
        private string _Subject;
        private string _Body;
        private DateTime _PickupDateTime;
        private bool _ApprovalStatus;
        private Address _PickupAddress;

        public Person Requester
        {
            get { return _Requester; }
            set { _Requester = value; }
        }
        public Person Requestee
        {
            get { return _Requestee; }
            set { _Requestee = value; }
        }
        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }
        public string Body
        {
            get { return _Body; }
            set { _Body = value; }
        }
        public DateTime PickupDateTime
        {
            get { return _PickupDateTime; }
            set { _PickupDateTime = value; }
        }
        public bool ApprovalStatus
        {
            get { return _ApprovalStatus; }
            set { _ApprovalStatus = value; }
        }
        public Address PickupAddress
        {
            get { return _PickupAddress; }
            set { _PickupAddress = value; }
        }


    }
}
