﻿// Decompiled with JetBrains decompiler
// Type: WhatsApp.UtilsFrontend.IVideoPlaybackDownloadCallbacks
// Assembly: WhatsApp, Version=2.18.370.0, Culture=neutral, PublicKeyToken=null
// MVID: 47CEDC7C-4E10-4203-B2F2-D2BD8D77633D
// Assembly location: C:\Users\Admin\Desktop\RE\WABeta\WhatsApp.dll


namespace WhatsApp.UtilsFrontend
{
  public interface IVideoPlaybackDownloadCallbacks
  {
    void UpdateVideoDownloadProgress(double progress);

    void VideoDownloadComplete(string localFileUrl);
  }
}
