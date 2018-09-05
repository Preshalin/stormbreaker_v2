using AutoMapper;
using Microsoft.Extensions.Configuration;
using stormbreaker.api.Models.Database;
using stormbreaker.api.Models.Database.Models;
using stormbreaker.api.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stormbreaker.api.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly StormbreakerContext _stormbreakerContext;
        private readonly IMapper _mapper;

        public UserRepository(StormbreakerContext stormbreakerContext, IMapper mapper)
        {
            _stormbreakerContext = stormbreakerContext;
            _mapper = mapper;
        }

        public List<UserDTO> GetAllUsers()
        {
            return _mapper.Map<List<UserDTO>>(_stormbreakerContext.Users.ToList());
        }

        public UserDTO GetUser(int id)
        {
            var user = _mapper.Map<User, UserDTO>(_stormbreakerContext.Users.FirstOrDefault(x => x.Id == id));

            if (user == null)
            {
                throw new Exception("The specified user does not exist");
            }

            return user;
        }

        public void AddUser(UserDTO userDTO)
        {
            var user = _stormbreakerContext.Users.FirstOrDefault(x => x.Email == userDTO.Email);

            if (user != null)
            {
                throw new Exception("A user with the specified email address already exists");
            }
            else
            {
                try
                {
                    _stormbreakerContext.Users.Add(_mapper.Map<UserDTO, User>(userDTO));
                    _stormbreakerContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void UpdateUser(int id, UserDTO userDTO)
        {
            var user = _stormbreakerContext.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                throw new Exception("The specified user does not exist");
            }
            else
            {
                if (user.Email == userDTO.Email)
                {
                    if (user.UserName != userDTO.UserName && !string.IsNullOrWhiteSpace(userDTO.UserName))
                    {
                        user.UserName = userDTO.UserName;
                    }
                    if (user.FirstNames != userDTO.FirstNames && !string.IsNullOrWhiteSpace(userDTO.FirstNames))
                    {
                        user.FirstNames = userDTO.FirstNames;
                    }
                    if (user.LastName != userDTO.LastName && !string.IsNullOrWhiteSpace(userDTO.LastName))
                    {
                        user.LastName = userDTO.LastName;
                    }
                }
                else
                {
                    throw new Exception("Unable to update the user because the email addresses do not match");
                }
                try
                {
                    _stormbreakerContext.Users.Update(user);
                    _stormbreakerContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void DeleteUser(int id)
        {
            var user = _stormbreakerContext.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                throw new Exception("The specified user does not exist");
            }
            else
            {
                _stormbreakerContext.Users.Remove(user);
                _stormbreakerContext.SaveChanges();
            }
        }
    }
}
