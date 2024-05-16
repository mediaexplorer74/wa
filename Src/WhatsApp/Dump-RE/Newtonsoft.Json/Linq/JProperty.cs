﻿// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JProperty
// Assembly: Newtonsoft.Json, Version=7.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: 0D551458-BD0A-4E39-8947-735723526F43
// Assembly location: C:\Users\Admin\Desktop\RE\WABeta\Newtonsoft.Json.dll
// XML documentation location: C:\Users\Admin\Desktop\RE\WABeta\Newtonsoft.Json.xml

using Newtonsoft.Json.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

#nullable disable
namespace Newtonsoft.Json.Linq
{
  /// <summary>Represents a JSON property.</summary>
  public class JProperty : JContainer
  {
    private readonly JProperty.JPropertyList _content = new JProperty.JPropertyList();
    private readonly string _name;

    /// <summary>Gets the container's children tokens.</summary>
    /// <value>The container's children tokens.</value>
    protected override IList<JToken> ChildrenTokens => (IList<JToken>) this._content;

    /// <summary>Gets the property name.</summary>
    /// <value>The property name.</value>
    public string Name
    {
      [DebuggerStepThrough] get => this._name;
    }

    /// <summary>Gets or sets the property value.</summary>
    /// <value>The property value.</value>
    public JToken Value
    {
      [DebuggerStepThrough] get => this._content._token;
      set
      {
        this.CheckReentrancy();
        JToken jtoken = value ?? (JToken) JValue.CreateNull();
        if (this._content._token == null)
          this.InsertItem(0, jtoken, false);
        else
          this.SetItem(0, jtoken);
      }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JProperty" /> class from another <see cref="T:Newtonsoft.Json.Linq.JProperty" /> object.
    /// </summary>
    /// <param name="other">A <see cref="T:Newtonsoft.Json.Linq.JProperty" /> object to copy from.</param>
    public JProperty(JProperty other)
      : base((JContainer) other)
    {
      this._name = other.Name;
    }

    internal override JToken GetItem(int index)
    {
      if (index != 0)
        throw new ArgumentOutOfRangeException();
      return this.Value;
    }

    internal override void SetItem(int index, JToken item)
    {
      if (index != 0)
        throw new ArgumentOutOfRangeException();
      if (JContainer.IsTokenUnchanged(this.Value, item))
        return;
      if (this.Parent != null)
        ((JObject) this.Parent).InternalPropertyChanging(this);
      base.SetItem(0, item);
      if (this.Parent == null)
        return;
      ((JObject) this.Parent).InternalPropertyChanged(this);
    }

    internal override bool RemoveItem(JToken item)
    {
      throw new JsonException("Cannot add or remove items from {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) typeof (JProperty)));
    }

    internal override void RemoveItemAt(int index)
    {
      throw new JsonException("Cannot add or remove items from {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) typeof (JProperty)));
    }

    internal override void InsertItem(int index, JToken item, bool skipParentCheck)
    {
      if (item != null && item.Type == JTokenType.Comment)
        return;
      if (this.Value != null)
        throw new JsonException("{0} cannot have multiple values.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) typeof (JProperty)));
      base.InsertItem(0, item, false);
    }

    internal override bool ContainsItem(JToken item) => this.Value == item;

    internal override void MergeItem(object content, JsonMergeSettings settings)
    {
      if (!(content is JProperty jproperty) || jproperty.Value == null || jproperty.Value.Type == JTokenType.Null)
        return;
      this.Value = jproperty.Value;
    }

    internal override void ClearItems()
    {
      throw new JsonException("Cannot add or remove items from {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) typeof (JProperty)));
    }

    internal override bool DeepEquals(JToken node)
    {
      return node is JProperty container && this._name == container.Name && this.ContentsEqual((JContainer) container);
    }

    internal override JToken CloneToken() => (JToken) new JProperty(this);

    /// <summary>
    /// Gets the node type for this <see cref="T:Newtonsoft.Json.Linq.JToken" />.
    /// </summary>
    /// <value>The type.</value>
    public override JTokenType Type
    {
      [DebuggerStepThrough] get => JTokenType.Property;
    }

    internal JProperty(string name)
    {
      ValidationUtils.ArgumentNotNull((object) name, nameof (name));
      this._name = name;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JProperty" /> class.
    /// </summary>
    /// <param name="name">The property name.</param>
    /// <param name="content">The property content.</param>
    public JProperty(string name, params object[] content)
      : this(name, (object) content)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JProperty" /> class.
    /// </summary>
    /// <param name="name">The property name.</param>
    /// <param name="content">The property content.</param>
    public JProperty(string name, object content)
    {
      ValidationUtils.ArgumentNotNull((object) name, nameof (name));
      this._name = name;
      this.Value = this.IsMultiContent(content) ? (JToken) new JArray(content) : JContainer.CreateFromContent(content);
    }

    /// <summary>
    /// Writes this token to a <see cref="T:Newtonsoft.Json.JsonWriter" />.
    /// </summary>
    /// <param name="writer">A <see cref="T:Newtonsoft.Json.JsonWriter" /> into which this method will write.</param>
    /// <param name="converters">A collection of <see cref="T:Newtonsoft.Json.JsonConverter" /> which will be used when writing the token.</param>
    public override void WriteTo(JsonWriter writer, params JsonConverter[] converters)
    {
      writer.WritePropertyName(this._name);
      JToken jtoken = this.Value;
      if (jtoken != null)
        jtoken.WriteTo(writer, converters);
      else
        writer.WriteNull();
    }

    internal override int GetDeepHashCode()
    {
      return this._name.GetHashCode() ^ (this.Value != null ? this.Value.GetDeepHashCode() : 0);
    }

    /// <summary>
    /// Loads an <see cref="T:Newtonsoft.Json.Linq.JProperty" /> from a <see cref="T:Newtonsoft.Json.JsonReader" />.
    /// </summary>
    /// <param name="reader">A <see cref="T:Newtonsoft.Json.JsonReader" /> that will be read for the content of the <see cref="T:Newtonsoft.Json.Linq.JProperty" />.</param>
    /// <returns>A <see cref="T:Newtonsoft.Json.Linq.JProperty" /> that contains the JSON that was read from the specified <see cref="T:Newtonsoft.Json.JsonReader" />.</returns>
    public static JProperty Load(JsonReader reader)
    {
      if (reader.TokenType == JsonToken.None && !reader.Read())
        throw JsonReaderException.Create(reader, "Error reading JProperty from JsonReader.");
      while (reader.TokenType == JsonToken.Comment)
        reader.Read();
      JProperty jproperty = reader.TokenType == JsonToken.PropertyName ? new JProperty((string) reader.Value) : throw JsonReaderException.Create(reader, "Error reading JProperty from JsonReader. Current JsonReader item is not a property: {0}".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) reader.TokenType));
      jproperty.SetLineInfo(reader as IJsonLineInfo);
      jproperty.ReadTokenFrom(reader);
      return jproperty;
    }

    private class JPropertyList : 
      IList<JToken>,
      ICollection<JToken>,
      IEnumerable<JToken>,
      IEnumerable
    {
      internal JToken _token;

      public IEnumerator<JToken> GetEnumerator()
      {
        if (this._token != null)
          yield return this._token;
      }

      IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

      public void Add(JToken item) => this._token = item;

      public void Clear() => this._token = (JToken) null;

      public bool Contains(JToken item) => this._token == item;

      public void CopyTo(JToken[] array, int arrayIndex)
      {
        if (this._token == null)
          return;
        array[arrayIndex] = this._token;
      }

      public bool Remove(JToken item)
      {
        if (this._token != item)
          return false;
        this._token = (JToken) null;
        return true;
      }

      public int Count => this._token == null ? 0 : 1;

      public bool IsReadOnly => false;

      public int IndexOf(JToken item) => this._token != item ? -1 : 0;

      public void Insert(int index, JToken item)
      {
        if (index != 0)
          return;
        this._token = item;
      }

      public void RemoveAt(int index)
      {
        if (index != 0)
          return;
        this._token = (JToken) null;
      }

      public JToken this[int index]
      {
        get => index != 0 ? (JToken) null : this._token;
        set
        {
          if (index != 0)
            return;
          this._token = value;
        }
      }
    }
  }
}
