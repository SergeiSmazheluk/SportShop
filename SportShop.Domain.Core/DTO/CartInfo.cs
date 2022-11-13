namespace SportShop.Domain.Core.DTO
{
    public class CartInfo
    {
        public CartDto Cart { get; set; } = new();

        public string ReturnUrl { get; set; } = "/";

    }
}
