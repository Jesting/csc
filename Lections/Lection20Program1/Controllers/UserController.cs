﻿using Lection20Program1.Dto;
using Lection20Program1.Repo;
using Microsoft.AspNetCore.Mvc;

namespace Lection20Program1.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private IUserRepository _repository;
    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpPost(template: "AddUser")]
    public ActionResult AddUser(UserDto user)
    {
        _repository.AddUser(user);

        return Ok();
    }

    [HttpGet(template: "Exists")]
    public ActionResult<bool> Exists(string email)
    {
        return Ok(_repository.Exists(email));
    }

    [HttpGet(template: "ExistsId")]
    public ActionResult<bool> ExistsId(Guid id)
    {
        return Ok(_repository.Exists(id));
    }

    [HttpGet(template: "List")]
    public ActionResult<IEnumerable<UserDto>> List()
    {
        return Ok(_repository.ListUsers());
    }
}

