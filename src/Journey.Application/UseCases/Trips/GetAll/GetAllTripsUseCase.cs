using Journey.Communication.Responses;
using Journey.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.GetAll
{
    public class GetAllTripsUseCase
    {
        public ResponseTripsJson Execute()
        {
            var dbContext = new JourneyDbContext();

            var trips = dbContext
                        .Trips
                        .Include(x => x.Activities)
                        .ToList();

            return new ResponseTripsJson
            {
                Trips = trips.Select(x => new ResponseShortTripJson
                {
                    Id = x.Id,
                    EndDate = x.EndDate,
                    Name = x.Name,
                    StartDate = x.StartDate
                }).ToList()
            };
        }
    }
}
