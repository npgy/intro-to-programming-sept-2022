using MongoDB.Bson.Serialization.Attributes;

namespace Banking.Api.Domain;

public class AccountEntity
{
    [BsonElement("_id")]
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}
