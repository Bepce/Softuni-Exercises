using System.Text;

namespace StockMarket
{
    public class Stock
    {
        public string CompanyName { get; set; }
        public string Director { get; set; }
        public decimal PricePerShare { get; set; }
        public int TotalNumberOfShares { get; set; }
        public decimal MarketCapitalization { get; set; }

        public Stock(string CompanyName, string Director, decimal PricePerShare, int TotalNumberOfShares)
        {
            this.CompanyName = CompanyName;
            this.Director = Director;
            this.PricePerShare = PricePerShare;
            this.TotalNumberOfShares = TotalNumberOfShares;
            this.MarketCapitalization = TotalNumberOfShares * PricePerShare;
        }

        public override string ToString()
        {
            return @$"Company: {this.CompanyName}
Director: { this.Director}
Price per share: ${this.PricePerShare}
Market capitalization: ${this.MarketCapitalization}";

        }
    }
}
