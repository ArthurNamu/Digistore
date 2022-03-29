using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Contracts.V1;
using StoreAPI.Contracts.V1.Requests;
using StoreAPI.Contracts.V1.Response;
using StoreAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identiryService;

        public IdentityController(IIdentityService identiryService)
        {
            _identiryService = identiryService;
        }

        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> CreateAsync([FromBody] RegisterRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = ModelState.Values.SelectMany(err => err.Errors.Select(errors => errors.ErrorMessage))
                });
            }
            var authResponse = await _identiryService.CreateAsync(request.UserName, request.Password);
            if (authResponse.Sucess == false)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }
            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token
            });
         }
        [HttpPost(ApiRoutes.Identity.Login)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = ModelState.Values.SelectMany(err => err.Errors.Select(errors => errors.ErrorMessage))
                });
            }
            var authResponse = await _identiryService.LoginAsync(request.UserName, request.Password);
            if (authResponse.Sucess == false)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }
            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token
            });
        }
    }

    }

