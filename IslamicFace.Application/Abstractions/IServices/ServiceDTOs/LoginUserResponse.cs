namespace IslamicFace.Application.Abstractions.IServices.ServiceDTOs;

public class LoginUserResponse
{
    public required Guid Id {  get; set; }
    public required string Email { get; set; }
    public required string UserName { get; set; }
    public required string Message {  get; set; }
}