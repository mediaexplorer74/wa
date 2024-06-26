﻿// Decompiled with JetBrains decompiler
// Type: ZXing.InvertedLuminanceSource
// Assembly: zxing.wp8.0, Version=0.14.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DD293DF0-BBAA-4BF0-BAC7-F5FAF5AC94ED
// Assembly location: C:\Users\Admin\Desktop\RE\WABeta\zxing.wp8.0.dll
// XML documentation location: C:\Users\Admin\Desktop\RE\WABeta\zxing.wp8.0.xml

#nullable disable
namespace ZXing
{
  /// <summary>
  /// A wrapper implementation of {@link LuminanceSource} which inverts the luminances it returns -- black becomes
  /// white and vice versa, and each value becomes (255-value).
  /// </summary>
  /// <author>Sean Owen</author>
  public sealed class InvertedLuminanceSource : LuminanceSource
  {
    private readonly LuminanceSource @delegate;
    private byte[] invertedMatrix;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:ZXing.InvertedLuminanceSource" /> class.
    /// </summary>
    /// <param name="delegate">The @delegate.</param>
    public InvertedLuminanceSource(LuminanceSource @delegate)
      : base(@delegate.Width, @delegate.Height)
    {
      this.@delegate = @delegate;
    }

    /// <summary>
    /// Fetches one row of luminance data from the underlying platform's bitmap. Values range from
    /// 0 (black) to 255 (white). Because Java does not have an unsigned byte type, callers will have
    /// to bitwise and with 0xff for each value. It is preferable for implementations of this method
    /// to only fetch this row rather than the whole image, since no 2D Readers may be installed and
    /// getMatrix() may never be called.
    /// </summary>
    /// <param name="y">The row to fetch, 0 &lt;= y &lt; Height.</param>
    /// <param name="row">An optional preallocated array. If null or too small, it will be ignored.
    /// Always use the returned object, and ignore the .length of the array.</param>
    /// <returns>An array containing the luminance data.</returns>
    public override byte[] getRow(int y, byte[] row)
    {
      row = this.@delegate.getRow(y, row);
      int width = this.Width;
      for (int index = 0; index < width; ++index)
        row[index] = (byte) ((int) byte.MaxValue - ((int) row[index] & (int) byte.MaxValue));
      return row;
    }

    /// <summary>
    /// Fetches luminance data for the underlying bitmap. Values should be fetched using:
    /// int luminance = array[y * width + x] &amp; 0xff;
    /// </summary>
    /// <returns> A row-major 2D array of luminance values. Do not use result.length as it may be
    /// larger than width * height bytes on some platforms. Do not modify the contents
    /// of the result.
    ///   </returns>
    public override byte[] Matrix
    {
      get
      {
        if (this.invertedMatrix == null)
        {
          byte[] matrix = this.@delegate.Matrix;
          int length = this.Width * this.Height;
          this.invertedMatrix = new byte[length];
          for (int index = 0; index < length; ++index)
            this.invertedMatrix[index] = (byte) ((int) byte.MaxValue - ((int) matrix[index] & (int) byte.MaxValue));
        }
        return this.invertedMatrix;
      }
    }

    /// <summary>
    /// </summary>
    /// <returns> Whether this subclass supports cropping.</returns>
    public override bool CropSupported => this.@delegate.CropSupported;

    /// <summary>
    /// Returns a new object with cropped image data. Implementations may keep a reference to the
    /// original data rather than a copy. Only callable if CropSupported is true.
    /// </summary>
    /// <param name="left">The left coordinate, 0 &lt;= left &lt; Width.</param>
    /// <param name="top">The top coordinate, 0 &lt;= top &lt;= Height.</param>
    /// <param name="width">The width of the rectangle to crop.</param>
    /// <param name="height">The height of the rectangle to crop.</param>
    /// <returns>A cropped version of this object.</returns>
    public override LuminanceSource crop(int left, int top, int width, int height)
    {
      return (LuminanceSource) new InvertedLuminanceSource(this.@delegate.crop(left, top, width, height));
    }

    /// <summary>
    /// </summary>
    /// <returns> Whether this subclass supports counter-clockwise rotation.</returns>
    public override bool RotateSupported => this.@delegate.RotateSupported;

    /// <summary>Inverts this instance.</summary>
    /// <returns>original delegate {@link LuminanceSource} since invert undoes itself</returns>
    public override LuminanceSource invert() => this.@delegate;

    /// <summary>
    /// Returns a new object with rotated image data by 90 degrees counterclockwise.
    /// Only callable if {@link #isRotateSupported()} is true.
    /// </summary>
    /// <returns>A rotated version of this object.</returns>
    public override LuminanceSource rotateCounterClockwise()
    {
      return (LuminanceSource) new InvertedLuminanceSource(this.@delegate.rotateCounterClockwise());
    }

    /// <summary>
    /// Returns a new object with rotated image data by 45 degrees counterclockwise.
    /// Only callable if {@link #isRotateSupported()} is true.
    /// </summary>
    /// <returns>A rotated version of this object.</returns>
    public override LuminanceSource rotateCounterClockwise45()
    {
      return (LuminanceSource) new InvertedLuminanceSource(this.@delegate.rotateCounterClockwise45());
    }
  }
}
