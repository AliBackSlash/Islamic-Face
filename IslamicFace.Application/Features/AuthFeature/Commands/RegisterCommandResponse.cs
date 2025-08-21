
namespace IslamicFace.Application.Features.AuthFeature.Commands;

public record RegisterCommandResponse
{
    public Guid Id { get; set; }
    public string? Token { get; set; }
    public string? ConfirmationLink {  get; set; }
}
