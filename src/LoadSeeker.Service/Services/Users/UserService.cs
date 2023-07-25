using CargoSeeker.DataAccess.Interfaces.Users;
using CargoSeeker.Domain.Entities.Users;
using CargoSeeker.Domain.Enums.UserEnums;
using CargoSeeker.Domain.Exceptions.Files;
using CargoSeeker.Domain.Exceptions.UserExceptions;
using CargoSeeker.Service.Common.Helpers;
using CargoSeeker.Service.DTO.Users;
using CargoSeeker.Service.Interfaces.Commons;
using CargoSeeker.Service.Interfaces.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoSeeker.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IUsersRepository _repository;
    private readonly IFileService _fileService;
    public UserService(IUsersRepository usersRepository,IFileService fileService)
    {
        this._repository = usersRepository;
        this._fileService = fileService;
    }

    public async Task<bool> CreateAsync(UserCreateDto dto)
    {
        //UserStatus statuss = UserStatus.Verified;
      
        string imagepath = await _fileService.UploadImageAsync(dto.userPhotoPath);
     

        User user = new User()
        {
            
            first_name = dto.first_name,                        
            tel_number = dto.tel_number,            
            passwordHash = dto.passwordHash,
            salt = dto.salt,
            //userPhotoPath = imagepath,
            //DocumentPicture_id = dto.DocumentPicture_id,                                                
            created_at = TimeHelpers.GetDateTime(),
            updated_at = TimeHelpers.GetDateTime() 
        };
       
        var result = await _repository.CreateAsync(user);
        return result>0;
        
    }

    public async Task<bool> DeleteAsync(long UserId)
    {
        var user = await _repository.GetByIdAsync(UserId);
        if(user is null) { throw new UserNotFoundException(); }

        var result = await _fileService.DeleteImageAsync(user.userPhotoPath);
        if(result==false) { throw new ImageNotFoundException(); }

        var dbResult = await _repository.DeleteAsync(UserId);
        return dbResult > 0;

    }

    public Task<bool> GetByIdAsync(long UserId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(long UserId, UserUpdateDto dto)
    {
        var user = await _repository.GetByIdAsync(UserId);
        if(user is null) { throw new UserNotFoundException(); };

        user.first_name = dto.first_name;
        user.second_name = dto.second_name;
        user.country = dto.country;
        user.tel_number = dto.tel_number;
        user.email = dto.email;
        user.passwordHash = dto.passwordHash;
        user.salt = dto.salt;        
        //user.DocumentPicture_id = dto.DocumentPicture_id;
        user.status = dto.status;        
        user.rating = dto.rating;        
        user.lattitude = dto.lattitude;
        user.longtitude = dto.longtitude;

        if(dto.userPhotoPath is not null) 
        {
            //delete old image
            var deleteResult = await _fileService.DeleteImageAsync(user.userPhotoPath);
            if(deleteResult == false) throw new ImageNotFoundException();
            //ploading new image
            string newImagePath = await _fileService.UploadImageAsync(dto.userPhotoPath);
            // parse new path to user
            user.userPhotoPath = newImagePath;
        }
        //else category old image have to save 
        user.updated_at = TimeHelpers.GetDateTime();
        var result = await _repository.UpdateAsync(UserId, user);
        return result > 0;



    }
}
