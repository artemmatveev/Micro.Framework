namespace Micro.Framework.Rest.Controllers
{
    public abstract class BaseController<TController> : ControllerBase where TController : ControllerBase
    {
        protected IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
