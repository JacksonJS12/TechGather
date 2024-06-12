namespace TechGather.Services.Interfaces
{
    using Web.ViewModels.Event;


    public interface IEventService
    {
        Task AddEventAsync(AddEventViewModel model);
        Task<AddEventViewModel> GetNewAddEventViewModelAsync();
    }
}
