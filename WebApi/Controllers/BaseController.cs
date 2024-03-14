using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

public class BaseController : ControllerBase
{
    // Mediator daha önce enjekte edilmiş mi kontrol et. Edilmemişse servis olarak çağır.
    private IMediator? _mediator;
    protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
