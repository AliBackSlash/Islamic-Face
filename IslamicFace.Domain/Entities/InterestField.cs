namespace IslamicFace.Domain.Entities;

public class InterestField
{
    public byte Id { get; set; }
    public required string FieldName_ENG { get; set; }
    public required string FieldName_ARB { get; set; }

    public ICollection<UserInterestField> userInterestFields { get; set; } = new List<UserInterestField>();
}
