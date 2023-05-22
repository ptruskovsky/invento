using System.Text.Json.Serialization;

namespace Invento.Api.Models
{
    [Serializable]
    public class RealmRole
    {
        [JsonPropertyName("roles")]
        public IEnumerable<string> Roles { get; set; } = Enumerable.Empty<string>();
    }
}
