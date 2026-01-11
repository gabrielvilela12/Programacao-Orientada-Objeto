namespace Sistema_Bancário_Simples.Domain.Entities
{
    public class PaymentHistory
    {
        public int Id { get; set; }
        public int UserLogedId { get; set; }
        public int UserTransferenceId { get; set; }
        public decimal transferAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
