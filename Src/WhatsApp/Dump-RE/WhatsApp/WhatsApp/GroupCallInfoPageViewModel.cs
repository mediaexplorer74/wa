﻿// Decompiled with JetBrains decompiler
// Type: WhatsApp.GroupCallInfoPageViewModel
// Assembly: WhatsApp, Version=2.18.370.0, Culture=neutral, PublicKeyToken=null
// MVID: 47CEDC7C-4E10-4203-B2F2-D2BD8D77633D
// Assembly location: C:\Users\Admin\Desktop\RE\WABeta\WhatsApp.dll

using Microsoft.Phone.Controls;
using WhatsApp.WaViewModels;

#nullable disable
namespace WhatsApp
{
  public class GroupCallInfoPageViewModel : PageViewModelBase
  {
    private CallRecord callRecord;

    public CallRecord CallRecord
    {
      get => this.callRecord;
      set => this.callRecord = this.CallRecord;
    }

    public override string PageTitle => AppResources.CallScreenLabelIncomingGroupWACall;

    public GroupCallInfoPageViewModel(CallRecord callRecord, PageOrientation orientation)
      : base(orientation)
    {
      this.CallRecord = callRecord;
    }
  }
}
