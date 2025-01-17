using PdfSharp.Fonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumCafe.Utils
{
    public class FileFontResolver : IFontResolver // FontResolverBase
    {
        public string DefaultFontName => throw new NotImplementedException();

        public byte[] GetFont(string faceName)
        {
            using (var ms = new MemoryStream())
            {
                using (var fs = File.Open("D:\\Coursework1\\BisleriumCafe", FileMode.Open))
                {
                    fs.CopyTo(ms);
                    ms.Position = 0;
                    return ms.ToArray();
                }
            }
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            if (familyName.Equals("OpenSans-Regular", StringComparison.CurrentCultureIgnoreCase))
            {
                if (isBold && isItalic)
                {
                    return new FontResolverInfo("Fonts/OpenSans-Regular.ttf");
                }
                else if (isBold)
                {
                    return new FontResolverInfo("Fonts/OpenSans-Regular.ttf");
                }
                else if (isItalic)
                {
                    return new FontResolverInfo("Fonts/OpenSans-Regular.ttf");
                }
                else
                {
                    return new FontResolverInfo("Fonts/OpenSans-Regular.ttf");
                }
            }
            return null;
        }
    }
}
