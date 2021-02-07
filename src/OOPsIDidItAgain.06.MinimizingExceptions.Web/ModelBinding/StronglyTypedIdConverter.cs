using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Domain;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.ModelBinding
{
    public class StronglyTypedIdConverter : JsonConverter<IStronglyTypedId>
    {
        public override bool CanConvert(Type typeToConvert)
            => typeof(IStronglyTypedId).IsAssignableFrom(typeToConvert);


        public override void Write(Utf8JsonWriter writer, IStronglyTypedId value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Value);
        }

        public override IStronglyTypedId Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var guid = reader.GetGuid();
            if (typeToConvert == typeof(CartId))
            {
                return new CartId(guid);
            }

            if (typeToConvert == typeof(ItemId))
            {
                return new ItemId(guid);
            }

            throw new NotImplementedException();
        }
    }
}