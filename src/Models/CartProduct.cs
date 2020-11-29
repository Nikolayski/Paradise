namespace Models
{
    public class CartProduct
    {
        public int Id { get; set; }

        public string CartId { get; set; }
        public virtual Cart Cart { get; set; }

        public string ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
