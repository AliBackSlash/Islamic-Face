namespace IslamicFace.Presentation.API.Controllers.v1.UserController.DTOs;

    public class AddUserRequest
    {
        public required string name {  get; set; }
        public required string email { get; set; }
        public required string password { get; set; }
        public required string userName { get; set; }
        public required short countryId { get; set; }
        public required short cityId { get; set; }
        public required DateOnly dateOfBirth { get; set; }
        public string? profilePictureURL { get; set; }
        public required bool gender { get; set; }
        public string? bio { get; set; }
        public required byte settingId { get; set; }
}
