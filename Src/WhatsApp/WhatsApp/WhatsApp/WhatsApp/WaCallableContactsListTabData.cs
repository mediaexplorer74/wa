﻿// Decompiled with JetBrains decompiler
// Type: WhatsApp.WaCallableContactsListTabData
// Assembly: WhatsApp, Version=2.18.370.0, Culture=neutral, PublicKeyToken=null
// MVID: 47CEDC7C-4E10-4203-B2F2-D2BD8D77633D
// Assembly location: C:\Users\Admin\Desktop\RE\WABeta\WhatsApp.dll

#nullable disable
namespace WhatsApp
{
  public class WaCallableContactsListTabData : WaContactsListTabData
  {
    public override UserStatus[] LoadFromDb(ContactsContext db) => db.GetCallableContacts();
  }
}
