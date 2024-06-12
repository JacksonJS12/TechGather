namespace TechGather.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TechGather.Services;
    using TechGather.Services.Interfaces;
    using TechGather.Web.ViewModels.Event;

    public class EventController : Controller
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddEventViewModel model = await eventService.GetNewAddEventViewModelAsync();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await eventService.AddEventAsync(model);

            return RedirectToAction("All", "Event");
        }

    }
}
