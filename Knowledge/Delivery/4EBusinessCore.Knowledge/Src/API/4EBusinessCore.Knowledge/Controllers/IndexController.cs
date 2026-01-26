


using Knowledge.Application.Features.IndexFeature.Query;
using Knowledge.Application.Features.IndexFeature.Query.GetUserAndIOrgIndicators;

namespace Knowledge.API.Controllers
{
    public class IndexController : BaseController
    {
        private readonly IMediator _mediator;

        public IndexController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ResponseDTO> Get()
        {
            return await _mediator.Send(new IndexQuery());
        }


        //[HttpGet("UserAndIOrgIndicators")]
        //public async Task<ResponseDTO> GetUserAndIOrgIndicators()
        //{
        //    return await _mediator.Send(new GetUserAndIOrgIndicatorsQuery());
        //}

    }
}
