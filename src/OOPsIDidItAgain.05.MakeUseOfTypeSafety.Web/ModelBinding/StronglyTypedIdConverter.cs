using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.Shared;

namespace OOPsIDidItAgain._05.MakeUseOfTypeSafety.Web.ModelBinding
{
    public class StronglyTypedIdConverter : JsonConverter<IStronglyTypedId>
    {
        public override bool CanConvert(Type typeToConvert)
            => typeof(IStronglyTypedId).IsAssignableFrom(typeToConvert);

        
        public override void Write(Utf8JsonWriter writer, IStronglyTypedId value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Value);
        }
        
        // don't need read for now, model binding handles input, Write handles output 
        public override IStronglyTypedId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => throw new NotImplementedException();
    }
}