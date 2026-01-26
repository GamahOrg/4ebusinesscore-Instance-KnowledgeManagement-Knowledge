namespace Knowledge.API.Controllers
{
	public class FavouriteController:BaseController
	{
		private readonly IMediator _mediator;
		public FavouriteController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public Task<ResponseDTO> PostFavouriteSubKnowledge(PostFavouriteSubKnowledgeQuery favouriteSubKnowledge)
		{
			return _mediator.Send(favouriteSubKnowledge);
		}

		[HttpGet]
		public Task<ResponseDTO> GetAllFavouriteSubKnowledges(int pageNumber, int pageSize)
		{
			return _mediator.Send(new GetAllFavouriteSubKnowledgesQuery {PageIndex = pageNumber, PageSize = pageSize });
		}
	}
}
