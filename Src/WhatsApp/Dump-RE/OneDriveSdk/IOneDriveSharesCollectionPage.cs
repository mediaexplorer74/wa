﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.OneDrive.Sdk.IOneDriveSharesCollectionPage
// Assembly: OneDriveSdk, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5E7A8391-E23E-498D-A6DC-9ACB59AE0E08
// Assembly location: C:\Users\Admin\Desktop\RE\WABeta\OneDriveSdk.dll

using Microsoft.Graph;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Microsoft.OneDrive.Sdk
{
  [JsonConverter(typeof (InterfaceConverter<OneDriveSharesCollectionPage>))]
  public interface IOneDriveSharesCollectionPage : 
    ICollectionPage<Share>,
    IList<Share>,
    ICollection<Share>,
    IEnumerable<Share>,
    IEnumerable
  {
    IOneDriveSharesCollectionRequest NextPageRequest { get; }

    void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
  }
}
