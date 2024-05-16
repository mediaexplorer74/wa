﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.OneDrive.Sdk.Video
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
  public class Video
  {
    [DataMember(Name = "bitrate", EmitDefaultValue = false, IsRequired = false)]
    public int? Bitrate { get; set; }

    [DataMember(Name = "duration", EmitDefaultValue = false, IsRequired = false)]
    public long? Duration { get; set; }

    [DataMember(Name = "height", EmitDefaultValue = false, IsRequired = false)]
    public int? Height { get; set; }

    [DataMember(Name = "width", EmitDefaultValue = false, IsRequired = false)]
    public int? Width { get; set; }

    [JsonExtensionData(ReadData = true)]
    public IDictionary<string, object> AdditionalData { get; set; }
  }
}
