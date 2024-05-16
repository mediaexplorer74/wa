﻿// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.JsonRequiredAttribute
// Assembly: Newtonsoft.Json, Version=7.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: 0D551458-BD0A-4E39-8947-735723526F43
// Assembly location: C:\Users\Admin\Desktop\RE\WABeta\Newtonsoft.Json.dll
// XML documentation location: C:\Users\Admin\Desktop\RE\WABeta\Newtonsoft.Json.xml

using System;

#nullable disable
namespace Newtonsoft.Json
{
  /// <summary>
  /// Instructs the <see cref="T:Newtonsoft.Json.JsonSerializer" /> to always serialize the member, and require the member has a value.
  /// </summary>
  [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
  public sealed class JsonRequiredAttribute : Attribute
  {
  }
}
