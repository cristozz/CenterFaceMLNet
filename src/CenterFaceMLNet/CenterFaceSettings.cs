namespace CenterFaceMLNet
{
    internal class CenterFaceSettings
    {
        public struct ImageSettings
        {
            public const int imageHeight = 480;
            public const int imageWidth = 640;
        }
        public struct ModelFields
        {
            public const string input_input1 = "input.1";
            public const string output_537 = "537";
            public const string output_538 = "538";
            public const string output_539 = "539";
            public const string output_540 = "540";
        }        

        public static string[] Inputs => new string[] { ModelFields.input_input1 };
        public static string[] Outputs => new string[] { ModelFields.output_537, ModelFields.output_538, ModelFields.output_539, ModelFields.output_540 };
        public static (int with, int height) Dimentions => (ImageSettings.imageWidth, ImageSettings.imageHeight);
    }
}
