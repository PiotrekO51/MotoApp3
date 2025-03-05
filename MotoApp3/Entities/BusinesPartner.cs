
namespace MotoApp3.Entities
{
    public class BusinesPartner : EntityBase
    {
        public string? FirstName { get; set; }
        public override string ToString() => $"Id: {Id}, Name: {FirstName}";   
    }
}
