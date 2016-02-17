using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Claytondus.Square.Models
{
    public class SquareItem
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }

        [JsonProperty(PropertyName = "visibility")]
        public string Visibility { get; set; }

        [JsonProperty(PropertyName = "available_online")]
        public bool AvailableOnline { get; set; }

        [JsonProperty(PropertyName = "master_image")]
        public SquareItemImage MasterImage { get; set; }

        [JsonProperty(PropertyName = "category")]
        public SquareCategory Category { get; set; }

        [JsonProperty(PropertyName = "variations")]
        public List<SquareItemVariation> Variations { get; set; }

        [JsonProperty(PropertyName = "modifier_lists")]
        public List<SquareModifierList> ModifierLists { get; set; }

        [JsonProperty(PropertyName = "fees")]
        public List<SquareFee> Fees { get; set; }

    }

    public class SquareItemImage
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }

    public class SquareItemVariation
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "item_id")]
        public string ItemId { get; set; }

        [JsonProperty(PropertyName = "ordinal")]
        public int Ordinal { get; set; }

        [JsonProperty(PropertyName = "pricing_type")]
        public string PricingType { get; set; }

        [JsonProperty(PropertyName = "price_money")]
        public SquareMoney PriceMoney { get; set; }

        [JsonProperty(PropertyName = "sku")]
        public string Sku { get; set; }

        [JsonProperty(PropertyName = "track_inventory")]
        public bool TrackInventory { get; set; }

        [JsonProperty(PropertyName = "inventory_alert_type")]
        public string InventoryAlertType { get; set; }

        [JsonProperty(PropertyName = "inventory_alert_threshold")]
        public int InventoryAlertThreshold { get; set; }

        [JsonProperty(PropertyName = "user_data")]
        public string UserData { get; set; }
    }

    public class SquareCategory
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    public class SquareModifierList
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "selection_type")]
        public string SelectionType { get; set; }

        [JsonProperty(PropertyName = "modifier_options")]
        public List<SquareModifierOption> ModifierOptions { get; set; }
    }

    public class SquareModifierOption
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "price_money")]
        public SquareMoney PriceMoney { get; set; }

        [JsonProperty(PropertyName = "on_by_default")]
        public bool OnByDefault { get; set; }

        [JsonProperty(PropertyName = "ordinal")]
        public int Ordinal { get; set; }

        [JsonProperty(PropertyName = "modifier_list_id")]
        public string ModifierListId { get; set; }
    }

    public class SquareFee
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "rate")]
        public string Rate { get; set; }

        [JsonProperty(PropertyName = "calculation_phase")]
        public string CalculationPhase { get; set; }

        [JsonProperty(PropertyName = "adjustment_type")]
        public string AdjustmentType { get; set; }

        [JsonProperty(PropertyName = "applies_to_custom_amounts")]
        public bool AppliesToCustomAmounts { get; set; }

        [JsonProperty(PropertyName = "enabled")]
        public bool Enabled { get; set; }

        [JsonProperty(PropertyName = "inclusion_type")]
        public string InclusionType { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}