using FocusFlow.DTOs;

namespace FocusFlow.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<ZenQuoteDTO> Quotes { get; set; } = new List<ZenQuoteDTO>();
    }
}
