using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hunty.Chat.Back.Application.Repository.Implementations;
using Hunty.Chat.Back.Application.Services.V1.Interfaces;
using Hunty.Chat.Back.Database.Entities;
using Hunty.Chat.Transverse.Helpers;
using Hunty.Chat.Transverse.Models.Response.City;
using Microsoft.Extensions.Options;
using Hunty.Chat.Back.Application.Utilities.AppSettingsKeys;
using Hunty.Chat.Transverse.ExternalServices;
using System.Net.Http;
using Hunty.Chat.Transverse.Models.Response;
using Hunty.Chat.Back.Application.Utilities.Authentication;
using Hunty.Chat.Back.Application.ExternalChat;
using Hunty.Chat.Back.Application.Models.ExternalChat.Response;
using Hunty.Chat.Back.Application.Models;
using System;

namespace Hunty.Chat.Back.Application.Services.V1.Implementations
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepository;
        private readonly UserExtChat _userExtChat;

        public UserService(IMapper mapper, UserRepository userRepository, UserExtChat userExtChat)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userExtChat = userExtChat;
        }

        public async Task<UserModel> Get(string codeUser)
        {
            Users user = await _userRepository.GetUserByCode(codeUser);
            return _mapper.Map<Users, UserModel>(user);
        }

        public async Task<UserModel> Create(string codeUser)
        {
            DateTime nowDate = DateTime.Now;
            GetAccessTokenResponse accessToken = await _userExtChat.GetAccessToken(codeUser);
            if (accessToken is null)
                return null;

            GetUserResponse userResponse = await _userExtChat.Get(codeUser);
            Users user = _mapper.Map<GetUserResponse, Users>(userResponse);
            user.AccessToken = accessToken.access_token;
            user.ExpirationToken = nowDate.AddSeconds(accessToken.expires_in);
            user = await _userRepository.CreateAsync(user);

            return _mapper.Map<Users, UserModel>(user);
        }

        public async Task<UserModel> Update(UserModel userModel)
        {
            Users user = _mapper.Map<UserModel, Users>(userModel);
            user = await _userRepository.UpdateUserAsync(user);

            return _mapper.Map<Users, UserModel>(user);
        }

        public async Task<UserModel> GetAccessToken(UserModel userModel)
        {
            DateTime nowDate = DateTime.Now;
            GetAccessTokenResponse accessToken = await _userExtChat.GetAccessToken(userModel.Code);
            userModel.AccessToken = accessToken.access_token;
            userModel.ExpiredDate = nowDate.AddSeconds(accessToken.expires_in);

            return await Update(userModel);
        }

        public async Task<UserModel> GetUserWithAuthAlive(string codeUser)
        {
            UserModel userModel = await Get(codeUser);

            if (userModel is null)
                userModel = await Create(codeUser);

            if (userModel.ExpiredDate <= DateTime.Now)
                userModel = await GetAccessToken(userModel);

            return userModel;
        }
    }
}