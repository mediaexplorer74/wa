﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Graph.SubscribedSkuRequestBuilder
// Assembly: MsGraphSdk, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B6767127-13D0-4992-B741-2642C0E7F410
// Assembly location: C:\Users\Admin\Desktop\RE\WABeta\MsGraphSdk.dll

using System.Collections.Generic;

#nullable disable
namespace Microsoft.Graph
{
  public class SubscribedSkuRequestBuilder : 
    EntityRequestBuilder,
    ISubscribedSkuRequestBuilder,
    IEntityRequestBuilder,
    IBaseRequestBuilder
  {
    public SubscribedSkuRequestBuilder(string requestUrl, IBaseClient client)
      : base(requestUrl, client)
    {
    }

    public ISubscribedSkuRequest Request() => this.Request((IEnumerable<Option>) null);

    public ISubscribedSkuRequest Request(IEnumerable<Option> options)
    {
      return (ISubscribedSkuRequest) new SubscribedSkuRequest(this.RequestUrl, this.Client, options);
    }
  }
}
