using Newtonsoft.Json;

namespace WebServiceModel
{
    /// <summary>
    /// Definition of a product in Json
    /// </summary>
    public class ProductJson
    {
        /// <summary>
        /// Gets or sets the product ID
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the product name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the product category
        /// </summary>
        [JsonProperty("category")]
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the product price
        /// </summary>
        [JsonProperty("price")]
        public double Price { get; set; }

        // Declare a single-dimensional array of 5 integers.
        [JsonProperty("arrayProducts")]
        public int[] arrayProducts = new int[5];
        
    }
    

    // public class RootObject
    // {
    //     public int Id {get; set; }
    //     public string Name {get; set; }
    //     public string Catrgory {get; set; }
    //     public float Price  {get; set; }

    // }
}
