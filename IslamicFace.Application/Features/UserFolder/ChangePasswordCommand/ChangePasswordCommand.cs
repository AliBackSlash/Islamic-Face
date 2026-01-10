namespace IslamicFace.Application.Features.UserFolder.ChangePasswordCommand;

public record ChangePasswordCommand(string id,string currentPassword,string newPassword, string ConfermPassword) : ICommand<ChangePasswordCommandResponse>;
