﻿using System;
using System.IO;
using SixLabors.ImageSharp;

namespace CoreDrawablesGenerator
{
    public static class Extensions
    {
        /// <summary>
        /// Converts an ImageSharp Image to Avalonia Bitmap, for rendering.
        /// </summary>
        /// <param name="resource">Image resource bytes.</param>
        /// <returns>Avalonia Bitmap.</returns>
        public static Avalonia.Media.Imaging.Bitmap ToAvaloniaBitmap(this Image<Rgba32> image)
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                using (FileStream stream = File.OpenWrite(tempFile))
                {
                    image.SaveAsPng(stream);
                }

                var bmp = new Avalonia.Media.Imaging.Bitmap(tempFile);
                return bmp;
            }
            finally
            {
                File.Delete(tempFile);
            }            
        }
    }
}
