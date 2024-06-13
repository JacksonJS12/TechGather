namespace TechGather.Web.ViewModels.Event
{
    using System.ComponentModel.DataAnnotations;

    using Enums;

    using static Common.GeneralApplicationConstants;

    public class AllEventQueryViewModel
    {
        public AllEventQueryViewModel()
        {
            CurrentPage = DefaultPage;
            EventsPerPage = EntitiesPerPage;

            Categories = new HashSet<string>();
            Events = new HashSet<AllEventViewModel>();
        }
        public string? Category { get; set; }

        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort Events By")]
        public EventSorting EventSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Show Events On Page")]
        public int EventsPerPage { get; set; }

        public int TotalEvents { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<AllEventViewModel> Events { get; set; }
    }
}
