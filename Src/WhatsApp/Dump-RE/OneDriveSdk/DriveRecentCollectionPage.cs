﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.OneDrive.Sdk.DriveRecentCollectionPage
// Assembly: OneDriveSdk, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5E7A8391-E23E-498D-A6DC-9ACB59AE0E08
// Assembly location: C:\Users\Admin\Desktop\RE\WABeta\OneDriveSdk.dll

using Microsoft.Graph;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Microsoft.OneDrive.Sdk
{
  public class DriveRecentCollectionPage : 
    CollectionPage<Microsoft.OneDrive.Sdk.Item>,
    IDriveRecentCollectionPage,
    ICollectionPage<Microsoft.OneDrive.Sdk.Item>,
    IList<Microsoft.OneDrive.Sdk.Item>,
    ICollection<Microsoft.OneDrive.Sdk.Item>,
    IEnumerable<Microsoft.OneDrive.Sdk.Item>,
    IEnumerable
  {
    public IDriveRecentRequest NextPageRequest { get; private set; }

    public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
    {
      if (string.IsNullOrEmpty(nextPageLinkString))
        return;
      this.NextPageRequest = (IDriveRecentRequest) new DriveRecentRequest(nextPageLinkString, client, (IEnumerable<Option>) null);
    }
  }
}
