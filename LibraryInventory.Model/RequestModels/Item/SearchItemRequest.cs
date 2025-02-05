namespace LibraryInventory.Model.RequestModels.Item
{
    public record SearchItemRequest : SearchRequest
    {
        public string[]? ItemTypes { get; set; }
        public string[]? Properties { get; set; }
    }
}
