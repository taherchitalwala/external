using System.Text.Json.Serialization;

namespace alvazaratAPI53.Models.Masters
{
    public class allJamaatList
    {
        [JsonPropertyName("jamiatId")]
        public short jamiat_id { get; set; }

        [JsonPropertyName("jamiatName")]
        public string jamiat_name { get; set; }
        
        [JsonPropertyName("jamaatId")]
        public short jamaat_id { get; set; }

        [JsonPropertyName("jamaatName")]
        public string jamaat_name { get; set; }

        [JsonPropertyName("jamaatTypeName")]
        public string jamaat_type_name { get; set; }

        [JsonPropertyName("ilaqaId")]
        public short ilaqa_id { get; set; }

        [JsonPropertyName("ilaqaName")]
        public string ilaqa_name { get; set; }

        [JsonPropertyName("aamilITS")]
        public int aamil_ITS { get; set; }

        [JsonPropertyName("aamilName")]
        public string aamil_name { get; set; }

        [JsonPropertyName("aamilNameArabic")]
        public string aamil_name_arabic { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }       
    }
}
