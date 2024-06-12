namespace TechGather.Services
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using Interfaces;
    using Web.ViewModels.Category;
    using Web.ViewModels.Event;


    public class EventService : IEventService
    {
        private readonly TechGatherDbContext dbContext;

        public EventService(TechGatherDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddEventAsync(AddEventViewModel model)
        {
            Event eEvent = new Event
            {
                Name = model.Name,
                CategoryId = model.CategoryId,
                Description = model.Description,
                Date = model.Date,
                Lecturers = model.Lectures
            };

            await dbContext.Events.AddAsync(eEvent);
            await dbContext.SaveChangesAsync();
        }

        public async Task<AddEventViewModel> GetNewAddEventViewModelAsync()
        {
            var categories = await dbContext
                .Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();

            var model = new AddEventViewModel
            {
                Categories = categories
            };

            return model;
        }
    }
}
