﻿namespace LibraryInventory.Model.RequestModels.Item
{
    public abstract record SearchRequest
    {
        public string? SearchText { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
