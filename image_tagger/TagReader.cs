using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;

namespace image_tagger
{
    static class TagReader
    {
        public static void ReadImageTags(string imagePath)
        {
            // 40094 = XPKeywords
            try
            {
                Image image = Image.FromFile(imagePath);
                var exifData = ImageMetadataReader.ReadMetadata(imagePath).FirstOrDefault(x => x.ContainsTag(40094));
                var tags = exifData.Tags.FirstOrDefault(x => x.Type == 0x9c9e).Description?.Split(';')
                                ?.Select(x => x.Trim())
                                ?.Where(x => !string.IsNullOrEmpty(x))
                                ?.ToArray();
                foreach (var tag in tags)
                {
                    System.Console.WriteLine(tag);
                }
            }
            catch (System.Exception ex)
            {
                
                System.Console.WriteLine(ex.Message);
            }
           
        }
    }
}
