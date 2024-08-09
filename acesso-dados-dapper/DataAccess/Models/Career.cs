namespace DataAccess.Models
{
    public class Career
    {
        public Career()
        {
            CareerItems = [];
        }

        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public IList<CareerItem> CareerItems { get; set; }
    }
}