using System.Threading;
using System.Threading.Tasks;
using ApiApplication.Apis.Showtimes.Messages;
using MediatR;

namespace ApiApplication.Apis.Showtimes.Handlers;

public class DeleteShowtimeByIdRequestHandler : IRequestHandler<DeleteShowtimeByIdRequest, Unit>
{
    public async Task<Unit> Handle(DeleteShowtimeByIdRequest request, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }
}