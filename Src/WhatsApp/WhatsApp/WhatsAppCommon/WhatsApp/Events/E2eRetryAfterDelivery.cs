﻿// Decompiled with JetBrains decompiler
// Type: WhatsApp.Events.E2eRetryAfterDelivery
// Assembly: WhatsAppCommon, Version=2.18.370.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D438F5E-0D32-4352-9FB4-5035480A3050
// Assembly location: C:\Users\Admin\Desktop\RE\WABeta\WhatsAppCommon.dll


namespace WhatsApp.Events
{
  public class E2eRetryAfterDelivery : WamEvent
  {
    public void Reset()
    {
    }

    public override uint GetCode() => 894;

    public override void SerializeFields()
    {
    }
  }
}
