using System.Threading;
using System.Threading.Tasks;
using Application.Orders.Queries.Keuken;
using AutoMapper;
using Infra.Persistence;
using Xunit;

namespace Tests.Application.Queries.Keuken
{
    [Collection("QueryTests")]
    public class GetKeukenQueryTest
    {
    

            private readonly ApplicationDbContext _context;
     

            public GetKeukenQueryTest(QueryTestFixture fixture)
            {
                _context = fixture.Context;
            }

            [Fact]
            public async Task Handle_ReturnsCorrectListCount()
            {
                var query = new GetAlleKeukenBestellingenQuery();

                var handler = new GetAlleKeukenBestellingenQuery.GetKitchenQueryHandler(_context);

                var result = await handler.Handle(query, CancellationToken.None);

                var list = result.Count;

                Assert.Equal(1, list);
            }
     
    }
}