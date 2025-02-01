namespace LibraryInventory.API.RequestModels
{
    public record SearchItemRequest
    {
        public string[]? ItemTypes { get; set; }
        public string[]? Properties { get; set; }
    }
}
