namespace IslamicFace.Domain.Layer_Dtos.AppUser.response;

public record AddReminderInfoForUserResponseDto(Guid Id, string Email, string UserName, string? Message);
