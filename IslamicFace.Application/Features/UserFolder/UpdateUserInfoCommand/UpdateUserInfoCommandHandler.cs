
using IslamicFace.Domain.Entities;
using System.Xml.Linq;

namespace IslamicFace.Application.Features.UserFolder.UpdateUserInfoCommand;

internal class UpdateUserInfoCommandHandler(IAppUserService userService) : ICommandHandler<UpdateUserInfoCommand, UpdateUserInfoCommandResponse>
{
    public async Task<Result<UpdateUserInfoCommandResponse>> Handle(UpdateUserInfoCommand command, CancellationToken cancellationToken)
    {
        var createResult = await userService.UpdateUserInfoAsync
            (new(command.Id,command.fName, command.lName, command.countryID, command.cityID,
             command.dateOfBirth, command.gender, command.bio, command.PhoneNumber, command.settingId));

        if (createResult.IsFailure)
            return Result.Failure<UpdateUserInfoCommandResponse>(createResult.Errors);

        return Result.Success(new UpdateUserInfoCommandResponse
        {
            Id = createResult.Value.Id,
            fName = createResult.Value.fName,
            lName = createResult.Value.lName,
            countryID = createResult.Value.countryID,
            cityID = createResult.Value.cityID,
            dateOfBirth = createResult.Value.dateOfBirth,
            gender = createResult.Value.gender,
            bio = createResult.Value.bio,
            PhoneNumber = createResult.Value.PhoneNumber,
            settingId = createResult.Value.settingId
        });
        
    }
}
