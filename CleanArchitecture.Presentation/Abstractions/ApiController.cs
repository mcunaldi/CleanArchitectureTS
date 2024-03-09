using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Presentation.Abstractions;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public abstract class ApiController() : ControllerBase
{
    public readonly IMediator _mediator;

    protected ApiController(IMediator mediator) : this()
    {
        _mediator = mediator;
    }
}
