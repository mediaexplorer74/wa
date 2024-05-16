﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.OneDrive.Sdk.Audio
// Assembly: OneDriveSdk, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5E7A8391-E23E-498D-A6DC-9ACB59AE0E08
// Assembly location: C:\Users\Admin\Desktop\RE\WABeta\OneDriveSdk.dll

using Microsoft.Graph;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

#nullable disable
namespace Microsoft.OneDrive.Sdk
{
  [DataContract]
  [JsonConverter(typeof (DerivedTypeConverter))]
  public class Audio
  {
    [DataMember(Name = "album", EmitDefaultValue = false, IsRequired = false)]
    public string Album { get; set; }

    [DataMember(Name = "albumArtist", EmitDefaultValue = false, IsRequired = false)]
    public string AlbumArtist { get; set; }

    [DataMember(Name = "artist", EmitDefaultValue = false, IsRequired = false)]
    public string Artist { get; set; }

    [DataMember(Name = "bitrate", EmitDefaultValue = false, IsRequired = false)]
    public long? Bitrate { get; set; }

    [DataMember(Name = "composers", EmitDefaultValue = false, IsRequired = false)]
    public string Composers { get; set; }

    [DataMember(Name = "copyright", EmitDefaultValue = false, IsRequired = false)]
    public string Copyright { get; set; }

    [DataMember(Name = "disc", EmitDefaultValue = false, IsRequired = false)]
    public short? Disc { get; set; }

    [DataMember(Name = "discCount", EmitDefaultValue = false, IsRequired = false)]
    public short? DiscCount { get; set; }

    [DataMember(Name = "duration", EmitDefaultValue = false, IsRequired = false)]
    public long? Duration { get; set; }

    [DataMember(Name = "genre", EmitDefaultValue = false, IsRequired = false)]
    public string Genre { get; set; }

    [DataMember(Name = "hasDrm", EmitDefaultValue = false, IsRequired = false)]
    public bool? HasDrm { get; set; }

    [DataMember(Name = "isVariableBitrate", EmitDefaultValue = false, IsRequired = false)]
    public bool? IsVariableBitrate { get; set; }

    [DataMember(Name = "title", EmitDefaultValue = false, IsRequired = false)]
    public string Title { get; set; }

    [DataMember(Name = "track", EmitDefaultValue = false, IsRequired = false)]
    public int? Track { get; set; }

    [DataMember(Name = "trackCount", EmitDefaultValue = false, IsRequired = false)]
    public int? TrackCount { get; set; }

    [DataMember(Name = "year", EmitDefaultValue = false, IsRequired = false)]
    public int? Year { get; set; }

    [JsonExtensionData(ReadData = true)]
    public IDictionary<string, object> AdditionalData { get; set; }
  }
}
