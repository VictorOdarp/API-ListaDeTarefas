﻿using APIListaDeTarefas.Dto.User;
using APIListaDeTarefas.Models;

namespace APIListaDeTarefas.Interfaces
{
    public interface IUserInterface
    {
        public Task<ResponseModel<List<UserModel>>> ListUsers();
        public Task<ResponseModel<UserModel>> GetUserById(int id);
        public Task<ResponseModel<UserModel>> GetUserByIdTask(int id);
        public Task<ResponseModel<List<UserModel>>> CreateUser(UserCriacaoDto newUser);
        public Task<ResponseModel<List<UserModel>>> EditUser(UserEdicaoDto editUser);
        public Task<ResponseModel<List<UserModel>>> DeleteUser(int id);
    }
}
