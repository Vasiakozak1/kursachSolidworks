using Newtonsoft.Json;

namespace kursowa
{
    public class AssemblyParameters
    {
        [JsonProperty(PropertyName = "wheelRadius")]
        public double WheelRadius { get; set; }
        [JsonProperty(PropertyName =  "wheelWidth")]
        public double WheelWidth { get; set; }
        [JsonProperty(PropertyName = "spoilerLength")]
        public double SpoilerLength { get; set; }
        [JsonProperty(PropertyName = "spoilerWidth")]
        public double SpoilerWidth { get; set; }
        [JsonProperty(PropertyName = "spoilerThickness")]
        public double SpoilerThickness { get; set; }
        [JsonProperty(PropertyName = "spoilerVerticalPosition")]
        public double SpoilerVerticalPosition { get; set; }
        [JsonProperty(PropertyName = "frontSpoilerLength")]
        public double FrontSpoilerLength { get; set; }
        [JsonProperty(PropertyName = "frontSpoilerThickness")]
        public double FrontSpoilerThickness { get; set; }
        [JsonProperty(PropertyName = "frontSpoilerVerticalPosition")]
        public double FrontSpoilerVerticalPosition { get; set; }
        [JsonProperty(PropertyName = "frontSpolierHorizontalPosition")]
        public double FrontSpolierHorizontalPosition { get; set; }
    }
}
