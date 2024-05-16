﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Graph.ExtensionRequestBuilder
// Assembly: MsGraphSdk, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B6767127-13D0-4992-B741-2642C0E7F410
// Assembly location: C:\Users\Admin\Desktop\RE\WABeta\MsGraphSdk.dll

using System.Collections.Generic;

#nullable disable
namespace Microsoft.Graph
{
  public class ExtensionRequestBuilder : 
    EntityRequestBuilder,
    IExtensionRequestBuilder,
    IEntityRequestBuilder,
    IBaseRequestBuilder
  {
    public ExtensionRequestBuilder(string requestUrl, IBaseClient client)
      : base(requestUrl, client)
    {
    }

    public IExtensionRequest Request() => this.Request((IEnumerable<Option>) null);

    public IExtensionRequest Request(IEnumerable<Option> options)
    {
      return (IExtensionRequest) new ExtensionRequest(this.RequestUrl, this.Client, options);
    }
  }
}
