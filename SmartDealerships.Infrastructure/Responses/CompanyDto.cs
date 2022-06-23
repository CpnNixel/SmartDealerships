namespace SmartDealerships.Infrastructure.Responses
{
    public class CompanyDto
    {

        public int Id { get; set; }

        public CompanyDto(int id, string name, string description, byte[]? logoImage, IEnumerable<ProductDto> products, IEnumerable<OrderDto> orders)
        {
            Id = id;
            Name = name;
            Description = description;
            LogoImage = logoImage;
            Products = products;
            Orders = orders;
        }

        public string Name { get; set; }

        public string DateCreated { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");

        public string Description { get; set; }

        public byte[]? LogoImage { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }
        public IEnumerable<OrderDto> Orders { get; set; }
    }
}
