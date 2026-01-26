using Knowledge.Application.Features.SubKnowledgeCategories.Command.Delete;
using Knowledge.Application.Features.SubKnowledgeCategories.Command.Post;
using Knowledge.Application.Features.SubKnowledgeCategories.Command.Put;
using Knowledge.Application.Features.SubKnowledgeCategories.Query.GetAll;

namespace Knowledge.API.Controllers
{
    [AllowAnonymous]
    [RequestSizeLimit(1048576000)] // 100 MB)
    [RequestFormLimits(MultipartBodyLengthLimit = 1048576000)] // 100 MB)

    public class SubKnowledgeController:BaseController
	{
		private readonly IMediator _mediator;
		public SubKnowledgeController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public Task<ResponseDTO> PostSubKnowledge([FromForm] PostSubKnowledgeDto subKnowledgeDto)
		{
			return _mediator.Send(new PostSubKnowledgeCommand { SubKnowledgeDto = subKnowledgeDto });
		}

		[HttpPut("{subKnowledgeId}")]
		public Task<ResponseDTO> PutSubKnowledge([FromForm] PutSubKnowledgeDto blogDto,Guid subKnowledgeId)
		{
			return _mediator.Send(new PutSubKnowledgeCommand { SubKnowledgeId = subKnowledgeId,SubKnowledgeDto = blogDto });
		}

		[HttpDelete("{subKnowledgeId}")]
		public Task<ResponseDTO> DeleteSubKnowledge(Guid subKnowledgeId)
		{
			return _mediator.Send(new DeleteSubKnowledgeCommand() { SubKnowledgeId = subKnowledgeId });
		}

        #region subKnowledgeCategory
        [HttpPost]
        [Route("PostSubKnowledgeCategory")]
        public async Task<ResponseDTO> PostSubKnowledgeCategory(PostSubKnowledgeCategoriesCommand command) => await _mediator.Send(command);

        [HttpGet]
        [Route("GetAllSubKnowledgeCategories")]
        public async Task<ResponseDTO> GetAllSubKnowledgeCategories()
        {
            var query = new GetAllSubKnowledgeCategoryQuery();
            return await _mediator.Send(query);
        }

        [HttpPut]
        [Route("PutSubKnowledgeCategory/{id}")]
        public async Task<ResponseDTO> PutSubKnowledgeCategory([FromRoute] Guid id, PutSubKnowledgeCategoryCommand command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }

        [HttpDelete]
        [Route("DeleteSubKnowledgeCategory/{id}")]
        public async Task<ResponseDTO> DeleteSubKnowledgeCategory(Guid id) => await _mediator.Send(new DeleteSubKnowledgeCategoryCommand() { Id = id });
        #endregion
    }
}
