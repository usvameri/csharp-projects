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
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter image path");
            var imagePath = Console.ReadLine();
            if (!String.IsNullOrEmpty(imagePath))
            TagReader.ReadImageTags(imagePath);
            else
            System.Console.WriteLine("Filepath Error!");
        }
    }
}
