﻿// Decompiled with JetBrains decompiler
// Type: ZXing.IBarcodeReaderGeneric`1
// Assembly: zxing.wp8.0, Version=0.14.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DD293DF0-BBAA-4BF0-BAC7-F5FAF5AC94ED
// Assembly location: C:\Users\Admin\Desktop\RE\WABeta\zxing.wp8.0.dll
// XML documentation location: C:\Users\Admin\Desktop\RE\WABeta\zxing.wp8.0.xml

using System;
using System.Collections.Generic;
using ZXing.Common;

#nullable disable
namespace ZXing
{
  /// <summary>
  /// Interface for a smart class to decode the barcode inside a bitmap object
  /// </summary>
  /// <typeparam name="T">gives the type of the input data</typeparam>
  public interface IBarcodeReaderGeneric<T>
  {
    /// <summary>event is executed when a result point was found</summary>
    event Action<ResultPoint> ResultPointFound;

    /// <summary>event is executed when a result was found via decode</summary>
    event Action<Result> ResultFound;

    /// <summary>
    /// Gets or sets a flag which cause a deeper look into the bitmap
    /// </summary>
    /// <value>
    ///   <c>true</c> if [try harder]; otherwise, <c>false</c>.
    /// </value>
    [Obsolete("Please use the Options.TryHarder property instead.")]
    bool TryHarder { get; set; }

    /// <summary>Image is a pure monochrome image of a barcode.</summary>
    /// <value>
    ///   <c>true</c> if monochrome image of a barcode; otherwise, <c>false</c>.
    /// </value>
    [Obsolete("Please use the Options.PureBarcode property instead.")]
    bool PureBarcode { get; set; }

    /// <summary>
    /// Specifies what character encoding to use when decoding, where applicable (type String)
    /// </summary>
    /// <value>The character set.</value>
    [Obsolete("Please use the Options.CharacterSet property instead.")]
    string CharacterSet { get; set; }

    /// <summary>
    /// Image is known to be of one of a few possible formats.
    /// Maps to a {@link java.util.List} of {@link BarcodeFormat}s.
    /// </summary>
    /// <value>The possible formats.</value>
    [Obsolete("Please use the Options.PossibleFormats property instead.")]
    IList<BarcodeFormat> PossibleFormats { get; set; }

    /// <summary>
    /// Specifies some options which influence the decoding process
    /// </summary>
    DecodingOptions Options { get; set; }

    /// <summary>
    /// Decodes the specified barcode bitmap which is given by a generic byte array.
    /// </summary>
    /// <param name="rawRGB">The barcode bitmap.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <param name="format">The format.</param>
    /// <returns>the result data or null</returns>
    Result Decode(byte[] rawRGB, int width, int height, RGBLuminanceSource.BitmapFormat format);

    /// <summary>
    /// Tries to decode a barcode within an image which is given by a luminance source.
    /// That method gives a chance to prepare a luminance source completely before calling
    /// the time consuming decoding method. On the other hand there is a chance to create
    /// a luminance source which is independent from external resources (like Bitmap objects)
    /// and the decoding call can be made in a background thread.
    /// </summary>
    /// <param name="luminanceSource">The luminance source.</param>
    /// <returns></returns>
    Result Decode(LuminanceSource luminanceSource);

    /// <summary>Decodes the specified barcode bitmap.</summary>
    /// <param name="barcodeBitmap">The barcode bitmap.</param>
    /// <returns>the result data or null</returns>
    Result Decode(T barcodeBitmap);
  }
}
