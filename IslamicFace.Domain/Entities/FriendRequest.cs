using IslamicFace.Domain.Enums;

namespace IslamicFace.Domain.Entities
{
    public class FriendRequest
    {
        public decimal Id { get; set; }
        public int senderID { get; set; }
        public int ReceiverID { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public DateTime? ResponseAt { get; set; }
        public DateTime DateSend { get; internal set; }

        public User? Sender { get; set; }  
        public User? Receiver { get; set; }
    }
}
