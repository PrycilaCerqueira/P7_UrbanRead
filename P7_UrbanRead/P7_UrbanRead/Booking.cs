namespace P7_UrbanRead
{
    internal class Booking
    {
        private Person _Requester;
        private Person _Requestee;
        private string _EmailSubject;
        private string _EmailBody;
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
            get { return _EmailSubject; }
            set { _EmailSubject = value; }
        }
        public string Body
        {
            get { return _EmailBody; }
            set { _EmailBody = value; }
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
