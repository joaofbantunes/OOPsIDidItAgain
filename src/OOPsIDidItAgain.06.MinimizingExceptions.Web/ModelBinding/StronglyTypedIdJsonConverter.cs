using System.ComponentModel;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.ModelBinding;

public class StronglyTypedIdJsonConverter<TId> : JsonConverter<TId> where TId : IStronglyTypedId<TId>
{
    public override bool CanConvert(Type typeToConvert)
        => typeof(IStronglyTypedId<TId>).IsAssignableFrom(typeToConvert);

    public override void Write(Utf8JsonWriter writer, TId value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.AsString());

    public override TId? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
        => TId.TryParse(reader.GetString(), out var result)
            ? result
            : default;
}

public class StronglyTypedIdTypeConverter<TId> : TypeConverter where TId : IStronglyTypedId<TId>
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        => sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        var stringValue = value as string;
        if (TId.TryParse(stringValue, out var result))
        {
            return result;
        }

        return base.ConvertFrom(context, culture, value);
    }
}