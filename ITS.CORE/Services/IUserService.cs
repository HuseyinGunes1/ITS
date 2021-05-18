using ITS.CORE.Dto;
using ITS.CORE.Entites;
using ITS.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITS.CORE.Services
{
   public interface IUserService
    {
        Task<Response<CavusDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<Response<CavusDto>> GetUserByNameAsync(string userName);

        //Task<IEnumerable<CreateUserDto>> GetUser();
        //Task<Response<NoDataDto>> Update(CreateUserDto dto, string id);
    }
}
