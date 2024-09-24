namespace CarBiddingSite
{
    public class Utils
    {
        private string FormatPrice(decimal? price)
        {
            if (price is null)
            {
                throw new ArgumentNullException(nameof(price));
            }
            else
            {
                return price.Value.ToString("N0");
            }
        }
    }
}
