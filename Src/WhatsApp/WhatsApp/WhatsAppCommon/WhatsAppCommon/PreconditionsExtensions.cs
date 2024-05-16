﻿// Decompiled with JetBrains decompiler
// Type: WhatsAppCommon.PreconditionsExtensions
// Assembly: WhatsAppCommon, Version=2.18.370.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D438F5E-0D32-4352-9FB4-5035480A3050
// Assembly location: C:\Users\Admin\Desktop\RE\WABeta\WhatsAppCommon.dll

using System;


namespace WhatsAppCommon
{
  public static class PreconditionsExtensions
  {
    public static T CheckNotNull<T>(this T obj, string message)
    {
      return (object) obj != null ? obj : throw new NullReferenceException(message);
    }
  }
}
