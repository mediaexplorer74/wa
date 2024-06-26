﻿// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Phone.Controls.AboutPrompt
// Assembly: Coding4Fun.Phone.Controls, Version=1.6.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 5583BFDF-52F3-4F66-A397-92165DEE5729
// Assembly location: C:\Users\Admin\Desktop\RE\WABeta\Coding4Fun.Phone.Controls.dll

using Coding4Fun.Phone.Controls.Data;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

#nullable disable
namespace Coding4Fun.Phone.Controls
{
  public class AboutPrompt : ActionPopUp<object, PopUpResult>
  {
    public static readonly DependencyProperty IsPromptModeProperty = DependencyProperty.Register(nameof (IsPromptMode), typeof (bool), typeof (AboutPrompt), new PropertyMetadata((object) true, new PropertyChangedCallback(AboutPrompt.OnIsPromptModeChanged)));
    public static readonly DependencyProperty WaterMarkProperty = DependencyProperty.Register(nameof (WaterMark), typeof (object), typeof (AboutPrompt), new PropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty VersionNumberProperty = DependencyProperty.Register(nameof (VersionNumber), typeof (object), typeof (AboutPrompt), new PropertyMetadata((object) ("v" + PhoneHelper.GetAppAttribute("Version").Replace(".0.0", ""))));
    public static readonly DependencyProperty BodyProperty = DependencyProperty.Register(nameof (Body), typeof (object), typeof (AboutPrompt), new PropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty FooterProperty = DependencyProperty.Register(nameof (Footer), typeof (object), typeof (AboutPrompt), new PropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof (Title), typeof (string), typeof (AboutPrompt), new PropertyMetadata((object) PhoneHelper.GetAppAttribute(nameof (Title))));

    public bool IsPromptMode
    {
      get => (bool) ((DependencyObject) this).GetValue(AboutPrompt.IsPromptModeProperty);
      set => ((DependencyObject) this).SetValue(AboutPrompt.IsPromptModeProperty, (object) value);
    }

    public object WaterMark
    {
      get => ((DependencyObject) this).GetValue(AboutPrompt.WaterMarkProperty);
      set => ((DependencyObject) this).SetValue(AboutPrompt.WaterMarkProperty, value);
    }

    public string VersionNumber
    {
      get => (string) ((DependencyObject) this).GetValue(AboutPrompt.VersionNumberProperty);
      set => ((DependencyObject) this).SetValue(AboutPrompt.VersionNumberProperty, (object) value);
    }

    public object Body
    {
      get => ((DependencyObject) this).GetValue(AboutPrompt.BodyProperty);
      set => ((DependencyObject) this).SetValue(AboutPrompt.BodyProperty, value);
    }

    public object Footer
    {
      get => ((DependencyObject) this).GetValue(AboutPrompt.FooterProperty);
      set => ((DependencyObject) this).SetValue(AboutPrompt.FooterProperty, value);
    }

    public string Title
    {
      get => (string) ((DependencyObject) this).GetValue(AboutPrompt.TitleProperty);
      set => ((DependencyObject) this).SetValue(AboutPrompt.TitleProperty, (object) value);
    }

    public AboutPrompt()
    {
      this.DefaultStyleKey = (object) typeof (AboutPrompt);
      RoundButton roundButton = new RoundButton();
      ((ButtonBase) roundButton).Click += new RoutedEventHandler(this.ok_Click);
      this.ActionPopUpButtons.Add((Button) roundButton);
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.SetIsPromptMode(this.IsPromptMode);
    }

    private static void OnIsPromptModeChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs e)
    {
      AboutPrompt aboutPrompt = (AboutPrompt) o;
      if (aboutPrompt == null || aboutPrompt.ActionButtonArea == null || e.NewValue == e.OldValue)
        return;
      aboutPrompt.SetIsPromptMode((bool) e.NewValue);
    }

    private void SetIsPromptMode(bool value)
    {
      if (this.ActionButtonArea == null)
        return;
      ((UIElement) this.ActionButtonArea).Visibility = value ? (Visibility) 0 : (Visibility) 1;
    }

    private void ok_Click(object sender, RoutedEventArgs e)
    {
      this.OnCompleted(new PopUpEventArgs<object, PopUpResult>()
      {
        PopUpResult = PopUpResult.Ok
      });
    }

    public void Show(
      string authorName,
      string twitterName = null,
      string emailAddress = null,
      string websiteUrl = null)
    {
      List<AboutPersonItem> aboutPersonItemList = new List<AboutPersonItem>()
      {
        new AboutPersonItem()
        {
          Role = "me",
          AuthorName = authorName
        }
      };
      if (!string.IsNullOrEmpty(twitterName))
        aboutPersonItemList.Add(new AboutPersonItem()
        {
          Role = "twitter",
          WebSiteUrl = "http://www.twitter.com/" + twitterName.TrimStart('@')
        });
      if (!string.IsNullOrEmpty(websiteUrl))
        aboutPersonItemList.Add(new AboutPersonItem()
        {
          Role = "web",
          WebSiteUrl = websiteUrl
        });
      if (!string.IsNullOrEmpty(emailAddress))
        aboutPersonItemList.Add(new AboutPersonItem()
        {
          Role = "email",
          EmailAddress = emailAddress
        });
      this.Show(aboutPersonItemList.ToArray());
    }

    public void Show(params AboutPersonItem[] people)
    {
      if (people != null && people.Length > 0)
      {
        StackPanel stackPanel1 = new StackPanel();
        ((FrameworkElement) stackPanel1).HorizontalAlignment = (HorizontalAlignment) 3;
        ((FrameworkElement) stackPanel1).VerticalAlignment = (VerticalAlignment) 3;
        StackPanel stackPanel2 = stackPanel1;
        for (int index = people.Length - 1; index >= 0; --index)
          ((PresentationFrameworkCollection<UIElement>) ((Panel) stackPanel2).Children).Insert(0, (UIElement) people[index]);
        this.Body = (object) stackPanel2;
      }
      this.Show();
    }
  }
}
