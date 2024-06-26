﻿using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Models;

namespace EmployeeRequestTrackerAPI.Intefaces
{
    public interface IUserService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<EmployeeUserDTO> Register(EmployeeUserDTO employeeDTO);
        public Task<UserStatusDTO> UpdateUserStatus(UserStatusDTO userStatusDTO);
    }
}
