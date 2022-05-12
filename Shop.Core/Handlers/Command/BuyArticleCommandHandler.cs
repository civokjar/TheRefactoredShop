using MediatR;
using Shop.Core.Handlers.Request;
using Shop.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Core.Handlers.Command
{
    public class BuyArticleCommandHandler : IRequestHandler<BuyArticleCommand, BuyArticleCommandResult>
    {

        private readonly IArticlePurchaseRepository _articlePurchaseRepository;
        private readonly IMediator _mediator; 

        public BuyArticleCommandHandler(IArticlePurchaseRepository articlePurchaseRepository, IMediator mediator)
        {
            _articlePurchaseRepository = articlePurchaseRepository;
            _mediator = mediator;
        }
        public async Task<BuyArticleCommandResult> Handle(BuyArticleCommand command, CancellationToken cancellationToken)
        {
            var availableArticle = await _mediator.Send(new GetArticleQuery { Id = command.Id});


            if (availableArticle == null)
                return null;

            await _articlePurchaseRepository.Save(command.Id, availableArticle.Name, availableArticle.Price, command.BuyerId, cancellationToken);
            return new BuyArticleCommandResult { Id = command.Id, Name = availableArticle.Name, SupplierName = availableArticle.SupplierName, Price = availableArticle.Price };
        }
    }
}
