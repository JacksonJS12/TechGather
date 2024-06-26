﻿namespace TechGather.Services
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
                City = model.City,
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
        public async Task<IEnumerable<AllEventViewModel>> GetAllEventsAsync()
        {
            return await this.dbContext
                .Events
                .Select(e => new AllEventViewModel
                {
                    Id = e.Id.ToString(),
                    Name = e.Name,
                    Date = e.Date.ToString("dd/MM/yyyy HH:mm"),
                    City = e.City,
                    Lectures = e.Lecturers,
                    Category = e.Category.Name,

                }).ToArrayAsync();
        }
    }
}
