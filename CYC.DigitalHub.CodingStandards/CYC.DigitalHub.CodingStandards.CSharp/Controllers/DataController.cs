using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

    // This is the default get action so we need to map it using root values and the action keyword
    [Route("")]
    [Route("~/")]
    [Route("[action]")]
    [HttpGet]
    public IEnumerable<int> Get()
    {
        // Only comment complicated code, try to keep code simple so it is effectively self commenting.
        var random = new Random();
        var returnValue = new List<int>();

        // Counter variables can be a single letter, usually an i.
        // Nested counters generally proceed down the alphabet e.g. j, k, l though you may choose a more appropriate name.
        for(var i = 0; i < 10; i++)
        {
            returnValue.Add(random.Next());
        }

        return returnValue;
    }
}