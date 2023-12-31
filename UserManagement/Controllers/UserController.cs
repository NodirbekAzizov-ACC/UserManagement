﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersManagement.Helpers;
using UsersManagement.Helpers.Exceptions;
using UsersManagement.Services;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserServices _services;
        public UserController(IUserServices services)
        {
            _services = services;
        }
        [HttpPut("/users")]
        public async Task<IActionResult> UpdateDatabaseFromCsv([FromForm] IFormFileCollection file)
        {
            try
            {
                if (!await _services.MergeFromCsvToDatabase(file[0]))
                    return Ok("Database is Up-to-date");
                return Ok("Database Updated Successfully");
            }

            catch (Exception ex) when (ex is BadRequestException)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex) when (ex is NotFoundException)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex) when (ex is DbUpdateException)
            {
                return StatusCode(500, "There was problem with update of the database");
            }
        }

        [HttpGet("/users")]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(_services.GetUsersFromDatabase());
            }
            catch(Exception ex) when (ex is NotFoundException)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("/users/order={order}/{numberofobjects:int}")]
        public IActionResult GetAllUsers(OrderBy order, int numberofobjects)
        {
            try
            {
                return Ok(_services.GetUsersFromDatabase(orderBy: order, numberOfUsers: numberofobjects));
            }
            catch (Exception ex) when (ex is NotFoundException)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

