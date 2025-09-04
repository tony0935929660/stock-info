namespace Api.Models
{
    public class Summary
    {
        public int Id { get; set; }
        public string? Date { get; set; }
        public decimal Taiex { get; set; }
        public decimal ForeignInvestor { get; set; }
        public decimal InvestmentTrust { get; set; }
        public decimal DealerSelf { get; set; }
        public decimal MarginBalance { get; set; }
        public decimal GoldPrice { get; set; }
        public decimal UsdExchange { get; set; }
        public decimal Sp500 { get; set; }
        public decimal Nasdaq { get; set; }
        public decimal Dji { get; set; }
        public decimal Sox { get; set; }
        public decimal Vix { get; set; }
        public decimal UsGovernmentBound { get; set; }
    }
}
