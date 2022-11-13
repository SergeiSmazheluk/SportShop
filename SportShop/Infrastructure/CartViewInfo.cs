namespace SportShop.Infrastructure
{
    public class CartViewInfo
    {
        public CartFeatures Cart { get; set; } = new();

        public string ReturnUrl { get; set; } = "/";
    }
}
