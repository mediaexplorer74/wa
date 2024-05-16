﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Graph.IDriveRecentRequest
// Assembly: MsGraphSdk, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B6767127-13D0-4992-B741-2642C0E7F410
// Assembly location: C:\Users\Admin\Desktop\RE\WABeta\MsGraphSdk.dll

using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Microsoft.Graph
{
  public interface IDriveRecentRequest : IBaseRequest
  {
    Task<IDriveRecentCollectionPage> GetAsync();

    Task<IDriveRecentCollectionPage> GetAsync(CancellationToken cancellationToken);

    IDriveRecentRequest Expand(string value);

    IDriveRecentRequest Select(string value);

    IDriveRecentRequest Top(int value);

    IDriveRecentRequest Filter(string value);

    IDriveRecentRequest Skip(int value);

    IDriveRecentRequest OrderBy(string value);
  }
}
