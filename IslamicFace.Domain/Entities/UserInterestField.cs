namespace IslamicFace.Domain.Entities;
public class UserInterestField
{
    public Guid UserId { get; set; }
    public byte InterestFieldId { get; set; }

    public InterestField? InterestField { get; set; }
}
