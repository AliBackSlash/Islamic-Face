using IslamicFace.Application.Messaging;

namespace IslamicFace.Application.Features.UserFeatures.Commands.AddNewUser;

public record AddUserCommandResponse
{
    public int Id { get; set; }
    public required string name { get; set; }
    public required string email { get; set; }
    public required string password { get; set; }
    public required string userName { get; set; }
    public required string country { get; set; }
    public required string city { get; set; }
    public DateOnly dateOfBirth { get; set; }
    public bool gender { get; set; }
    public required string bio { get; set; }
}
public class AddUserCommand : ICommand<AddUserCommandResponse>
{

}

