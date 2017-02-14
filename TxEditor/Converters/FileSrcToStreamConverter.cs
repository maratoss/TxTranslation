namespace Unclassified.TxEditor.Converters
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.IO;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;

    public class FileSrcToStreamConverter : IValueConverter
    {
        public static FileSrcToStreamConverter I => new FileSrcToStreamConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!File.Exists(value as string))
            {
                return value;
            }

            try
            {
                using (var bitmap = new Bitmap((string)value))
                {
                    using (var memory = new MemoryStream())
                    {
                        bitmap.Save(memory, ImageFormat.Png);
                        memory.Position = 0;
                        byte[] buffer = memory.GetBuffer();
                        var bufferPasser = new MemoryStream(buffer);
                        var bitmapimage = new BitmapImage();
                        bitmapimage.BeginInit();
                        bitmapimage.StreamSource = bufferPasser;
                        bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapimage.EndInit();

                        return bitmapimage;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Binding.DoNothing;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}