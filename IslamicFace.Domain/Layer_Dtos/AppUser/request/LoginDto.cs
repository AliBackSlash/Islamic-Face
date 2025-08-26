namespace IslamicFace.Domain.Layer_Dtos.AppUser.request;

public record LoginDto(string UserNameOrEmail, string? Password);
