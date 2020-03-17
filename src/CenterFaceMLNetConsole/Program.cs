using CenterFaceMLNet;
using System;
using System.Drawing;

namespace CenterFaceMLNetConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            var aa=MathF.Ceiling(1920f / 32f) * 32;
            var bb = MathF.Ceiling(1080f / 32f) * 32;
            var modelBuilder = new CenterFaceModelBuilder(
                @"C:\Users\Christofer\Source\Repos\CenterFaceMLNet\assets\models\centerface.onnx",
                "mlnetonnx.zip"
                );
            //modelBuilder.SaveMLNetModel();
         

             modelBuilder.Predict(@"C:\Users\Christofer\Desktop\CenterFaceDotNet-master\examples\Demo\images\images.jpg");

            Console.WriteLine("Hello World!");
        }
    }
}
