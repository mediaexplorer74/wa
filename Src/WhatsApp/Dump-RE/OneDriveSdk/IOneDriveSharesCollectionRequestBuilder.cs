﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.OneDrive.Sdk.IOneDriveSharesCollectionRequestBuilder
// Assembly: OneDriveSdk, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5E7A8391-E23E-498D-A6DC-9ACB59AE0E08
// Assembly location: C:\Users\Admin\Desktop\RE\WABeta\OneDriveSdk.dll

using Microsoft.Graph;
using System.Collections.Generic;

#nullable disable
namespace Microsoft.OneDrive.Sdk
{
  public interface IOneDriveSharesCollectionRequestBuilder
  {
    IOneDriveSharesCollectionRequest Request();

    IOneDriveSharesCollectionRequest Request(IEnumerable<Option> options);

    IShareRequestBuilder this[string id] { get; }
  }
}
