﻿// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.CustomCreationConverter`1
// Assembly: Newtonsoft.Json, Version=7.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: 0D551458-BD0A-4E39-8947-735723526F43
// Assembly location: C:\Users\Admin\Desktop\RE\WABeta\Newtonsoft.Json.dll
// XML documentation location: C:\Users\Admin\Desktop\RE\WABeta\Newtonsoft.Json.xml

using System;

#nullable disable
namespace Newtonsoft.Json.Converters
{
  /// <summary>Create a custom object</summary>
  /// <typeparam name="T">The object type to convert.</typeparam>
  public abstract class CustomCreationConverter<T> : JsonConverter
  {
    /// <summary>Writes the JSON representation of the object.</summary>
    /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
    /// <param name="value">The value.</param>
    /// <param name="serializer">The calling serializer.</param>
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      throw new NotSupportedException("CustomCreationConverter should only be used while deserializing.");
    }

    /// <summary>Reads the JSON representation of the object.</summary>
    /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
    /// <param name="objectType">Type of the object.</param>
    /// <param name="existingValue">The existing value of object being read.</param>
    /// <param name="serializer">The calling serializer.</param>
    /// <returns>The object value.</returns>
    public override object ReadJson(
      JsonReader reader,
      Type objectType,
      object existingValue,
      JsonSerializer serializer)
    {
      if (reader.TokenType == JsonToken.Null)
        return (object) null;
      T target = this.Create(objectType);
      if ((object) target == null)
        throw new JsonSerializationException("No object created.");
      serializer.Populate(reader, (object) target);
      return (object) target;
    }

    /// <summary>
    /// Creates an object which will then be populated by the serializer.
    /// </summary>
    /// <param name="objectType">Type of the object.</param>
    /// <returns>The created object.</returns>
    public abstract T Create(Type objectType);

    /// <summary>
    /// Determines whether this instance can convert the specified object type.
    /// </summary>
    /// <param name="objectType">Type of the object.</param>
    /// <returns>
    /// 	<c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
    /// </returns>
    public override bool CanConvert(Type objectType) => typeof (T).IsAssignableFrom(objectType);

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:Newtonsoft.Json.JsonConverter" /> can write JSON.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this <see cref="T:Newtonsoft.Json.JsonConverter" /> can write JSON; otherwise, <c>false</c>.
    /// </value>
    public override bool CanWrite => false;
  }
}
