using CYC.DigitalHub.CodingStandards.CSharp.ViewModels.DataController;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;

/// <summary>
/// This controller is an example of a WebApi2 controller that you would use to send json/xml to a client.
/// A client might be an clientside app or a server, anything that consumes your data.
/// </summary> 

// We use route based attributes wherever possible as it is easier to reference and clearer.
// WebApi controllers should always sit behind the api keyword. http://localhost:5000/api/Data in this case.
[Route("api/[controller]")]
public class DataController : Controller
{
    /// <summary>
    /// Get 10 random numbers
    /// </summary>
    /// <returns>10 random integer values.</returns>

    // This is the default get action so we need to map it using root value
    // The [action] route maps to /api/data/get too so you can be specific in your consumer if you prefer.
    [Route("")]
    [Route("[action]")]
    [HttpGet]
    public IEnumerable<DataApiUserViewModel> Get()
    {
        // Only comment complicated code, try to keep code simple so it is effectively self commenting.
        var random = new Random();
        var returnValue = new List<DataApiUserViewModel>();

        // Counter variables can be a single letter, usually an i.
        // Nested counters generally proceed down the alphabet e.g. j, k, l though you may choose a more appropriate name.
        for (var i = 0; i < 10; i++)
        {
            returnValue.Add(new DataApiUserViewModel
            {
                Id = random.Next(),
                JobTitle = "Developer",
                Name = "Data API user"
            });
        }

        return returnValue;
    }


    /// <summary>
    /// Get a DataController user by id
    /// </summary>
    /// <param name="id">User Id</param>
    /// <returns></returns>
    [Route("{id}")]
    [Route("[action]/{id}")]
    [HttpGet]
    public DataApiUserViewModel Get(int id)
    {
        // This would most likely be returned from a service that is searching a DB / cache solution.
        return new DataApiUserViewModel
        {
            Id = id,
            Name = "Data API user",
            JobTitle = "Developer"
        };
    }


    /// <summary>
    /// Create a new User
    /// </summary>
    /// <param name="user">User that should be created</param>
    /// <returns>HTTP status code indicating outcome</returns>
    [Route("")]
    [Route("[action]")]
    [Route("create")]
    [HttpPost]
    public IActionResult Post([FromBody]DataApiUserViewModel user)
    {
        // Where possible use data annotations to perform validation
        if (!ModelState.IsValid)
        {
            // Return a 409 conflict if the information passed was not in a usable form (validation etc).
            // See https://www.w3.org/Protocols/rfc2616/rfc2616-sec10.html#sec10.4.10
            return StatusCode(409);
        }

        // Processing logic to store the new user would be called here.
        // ...

        // Successful POST returns 200 OK.
        return Ok();
    }

    [Route("")]
    [Route("[action]")]
    [Route("update")]
    [HttpPut]
    public IActionResult Put([FromBody]DataApiUserUpdateViewModel user)
    {
        if(!ModelState.IsValid)
        {
            return StatusCode(409);
        }

        // We would normally have logic here to ensure the user exists.
        // In this case, we're just seeing if the id is odd or even.
        if (user.Id % 2 == 0)
        {
            // If the user does not exist return 404 not found.
            return NotFound();
        }

        // Processing logic to update user would be called here.
        // ...

        //Successful PUT returns 200 OK
        return Ok();
    }
}