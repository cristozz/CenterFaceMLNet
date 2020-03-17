using Microsoft.ML.Transforms.Image;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CenterFaceMLNet.DataModels
{
    public class CenterFaceImageInput
    {
        [ImageType(CenterFaceSettings.ImageSettings.imageHeight, CenterFaceSettings.ImageSettings.imageWidth)]
        public Bitmap Image { get; set; }
        internal static IEnumerable<CenterFaceImageInput> EmptyEnumerable => Enumerable.Empty<CenterFaceImageInput>();
    }
}
