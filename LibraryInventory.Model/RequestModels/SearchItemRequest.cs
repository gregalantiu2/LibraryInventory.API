namespace LibraryInventory.Model.RequestModels
{
    public record SearchItemRequest : SearchRequest
    {
        public string[]? ItemTypes { get; set; }
        public string[]? Properties { get; set; }
    }
}
