﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Graph.DeviceRegisteredOwnersCollectionWithReferencesRequest
// Assembly: MsGraphSdk, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B6767127-13D0-4992-B741-2642C0E7F410
// Assembly location: C:\Users\Admin\Desktop\RE\WABeta\MsGraphSdk.dll

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Microsoft.Graph
{
  public class DeviceRegisteredOwnersCollectionWithReferencesRequest : 
    BaseRequest,
    IDeviceRegisteredOwnersCollectionWithReferencesRequest,
    IBaseRequest
  {
    public DeviceRegisteredOwnersCollectionWithReferencesRequest(
      string requestUrl,
      IBaseClient client,
      IEnumerable<Option> options)
      : base(requestUrl, client, options)
    {
    }

    public Task<IDeviceRegisteredOwnersCollectionWithReferencesPage> GetAsync()
    {
      return this.GetAsync(CancellationToken.None);
    }

    public async Task<IDeviceRegisteredOwnersCollectionWithReferencesPage> GetAsync(
      CancellationToken cancellationToken)
    {
      this.Method = "GET";
      DeviceRegisteredOwnersCollectionWithReferencesResponse referencesResponse = await this.SendAsync<DeviceRegisteredOwnersCollectionWithReferencesResponse>((object) null, cancellationToken).ConfigureAwait(false);
      if (referencesResponse == null || referencesResponse.Value == null || referencesResponse.Value.CurrentPage == null)
        return (IDeviceRegisteredOwnersCollectionWithReferencesPage) null;
      if (referencesResponse.AdditionalData != null)
      {
        object obj;
        referencesResponse.AdditionalData.TryGetValue("@odata.nextLink", out obj);
        string nextPageLinkString = obj as string;
        if (!string.IsNullOrEmpty(nextPageLinkString))
          referencesResponse.Value.InitializeNextPageRequest(this.Client, nextPageLinkString);
        referencesResponse.Value.AdditionalData = referencesResponse.AdditionalData;
      }
      return referencesResponse.Value;
    }

    public IDeviceRegisteredOwnersCollectionWithReferencesRequest Top(int value)
    {
      this.QueryOptions.Add(new QueryOption("$top", value.ToString()));
      return (IDeviceRegisteredOwnersCollectionWithReferencesRequest) this;
    }

    public IDeviceRegisteredOwnersCollectionWithReferencesRequest OrderBy(string value)
    {
      this.QueryOptions.Add(new QueryOption("$orderby", value));
      return (IDeviceRegisteredOwnersCollectionWithReferencesRequest) this;
    }
  }
}
