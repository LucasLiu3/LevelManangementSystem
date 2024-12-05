using Microsoft.EntityFrameworkCore;

namespace LevelManangementSystem.web.Services.Periods
{
    public class PeriodsService(ApplicationDbContext _context) :IPeriodsService
    {

        public async Task<Period> GetCurrentPeriod()
        {
            var currentDate = DateTime.Now;
            var period = await _context.Periods.SingleAsync(each => each.EndDay.Year == currentDate.Year);

            return period;
        }
    }
}
