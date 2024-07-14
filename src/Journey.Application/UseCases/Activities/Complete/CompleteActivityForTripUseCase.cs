using Journey.Exception;
using Journey.Infrastructure;
using Journey.Infrastructure.Enums;

namespace Journey.Application.UseCases.Activities.Complete
{
    public class CompleteActivityForTripUseCase
    {
        public void Execute(Guid tripId, Guid activityId)
        {
            var dbContext = new JourneyDbContext();

            var activity = dbContext
                .Activities
                .FirstOrDefault(x => x.Id == activityId && x.TripId == tripId);

            if(activity is null)
            {
                throw new NotFiniteNumberException(ResourceErrorMessages.ACTIVITY_NOT_FOUND);
            }

            activity.Status = ActivityStatus.Done;

            dbContext.Activities.Update(activity);
            dbContext.SaveChanges();
        }
    }
}
