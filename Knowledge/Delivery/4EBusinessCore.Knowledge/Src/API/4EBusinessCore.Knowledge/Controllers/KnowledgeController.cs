using Knowledge.Application.Features.KnowledgeFeatures.Query.GetById;
using Knowledge.Application.Services;

namespace Knowledge.API.Controllers
{
    [ApiController]
    public class KnowledgeController : BaseController
    {
        private readonly IMediator _mediator;

        public KnowledgeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("PostKnowledgeCategory")]
        public async Task<ResponseDTO> PostKnowledgeCategory(PostKnowledgeCategoryCommand command) => await _mediator.Send(command);

        [HttpGet]
        [Route("GetAllKnowledgeCategories")]
        public async Task<ResponseDTO> GetAllKnowledgeCategories()
        {
            var query = new GetAllKnowledgeCategoriesQuery();
            return await _mediator.Send(query);
        }

        [HttpPut]
        [Route("PutKnowledgeCategory/{id}")]
        public async Task<ResponseDTO> PutKnowledgeCategory([FromRoute] Guid id, PutKnowledgeCategoryCommand command)
        {
            command.KnowledgeCategoryId = id;
            return await _mediator.Send(command);
        }

        [HttpDelete]
        [Route("DeleteKnowledgeCategory/{id}")]
        public async Task<ResponseDTO> DeleteKnowledgeCategory(Guid id) => await _mediator.Send(new DeleteKnowledgeCategoryCommand(id));

        [HttpPost]
        [Route("PostKnowledge")]
        public async Task<ResponseDTO> PostKnowledge(PostKnowledgeCommand command) => await _mediator.Send(command);

        [HttpPut]
        [Route("PutKnowledge/{id}")]
        public async Task<ResponseDTO> PutKnowledge([FromRoute] Guid id, PutKnowledgeCommand command)
        {
            command.KnowledgeId = id;
            return await _mediator.Send(command);
        }

        [HttpDelete]
        [Route("DeleteKnowledge/{id}")]
        public async Task<ResponseDTO> DeleteKnowledge(Guid id) => await _mediator.Send(new DeleteKnowledgeCommand(id));

        [HttpGet]
        [Route("GetAllPublicKnowledgePaginated")]
        public async Task<ResponseDTO> GetAllKnowledgePaginated(int pageNumber, int pageSize, string? searchTerm)
        {
            var query = new GetAllKnowledgePaginatedQuery(pageNumber, pageSize, searchTerm);
            return await _mediator.Send(query);
        }

        [HttpGet("{knowledgeId}")]
        public Task<ResponseDTO> GetByIdKnowledge(Guid knowledgeId, KnowledgeType knowledgeType)
        {
            return _mediator.Send(new GetByIdKnowledgeQuery { KnowledgeId = knowledgeId, KnowledgeType = knowledgeType });
        }

        //[HttpGet]
        //[Route("GetAllPrivateKnowledgePaginated")]
        //public async Task<ResponseDTO> GetAllPrivateKnowledgePaginated(int pageNumber, int pageSize, string? searchTerm)
        //{
        //    var orgs = new List<Guid>(); 

        //    var query = new GetAllPrivateKnowledgeQuery(pageNumber, pageSize, searchTerm ,orgs );
        //    return await _mediator.Send(query);
        //}

        [HttpPost]
        [Route("PostSubKnowledgeLikeDisLike")]
        public async Task<ResponseDTO> PostSubKnowledgeLikeDisLike([FromBody] PostSubKnowledgeLikeCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost]
        [Route("PostSubKnowledgeRate")]
        public async Task<ResponseDTO> PostSubKnowledgeRate([FromBody] PostSubKnowledgeRateCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
