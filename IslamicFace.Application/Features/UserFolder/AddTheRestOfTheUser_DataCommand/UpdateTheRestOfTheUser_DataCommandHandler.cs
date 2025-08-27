
using IslamicFace.Domain.Entities;
using System.Xml.Linq;

namespace IslamicFace.Application.Features.UserFolder.AddTheRestOfTheUser_DataCommand;

internal class AddTheRestOfTheUser_DataCommandHandler(IAppUserService userService) : ICommandHandler<AddTheRestOfTheUser_DataCommand, AddTheRestOfTheUser_DataCommandResponse>
{
    public async Task<Result<AddTheRestOfTheUser_DataCommandResponse>> Handle(AddTheRestOfTheUser_DataCommand command, CancellationToken cancellationToken)
    {
        var createResult = await userService.UpdateTheRestOfTheUser_DataAsync
            (new(command.Id,command.fName, command.lName, command.countryID, command.cityID,
             command.dateOfBirth, command.gender, command.profilePictureURL, command.bio, command.PhoneNumber, command.settingId));

        if (createResult.IsFailure)
            return Result.Failure<AddTheRestOfTheUser_DataCommandResponse>(createResult.Errors);

        return Result.Success(new AddTheRestOfTheUser_DataCommandResponse
        {
            Id = createResult.Value.Id,
            fName = createResult.Value.fName,
            lName = createResult.Value.lName,
            countryID = createResult.Value.countryID,
            cityID = createResult.Value.cityID,
            dateOfBirth = createResult.Value.dateOfBirth,
            gender = createResult.Value.gender,
            profilePictureURL = createResult.Value.profilePictureURL,
            bio = createResult.Value.bio,
            PhoneNumber = createResult.Value.PhoneNumber,
            settingId = createResult.Value.settingId
        });
        
    }
}
