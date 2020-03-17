using Microsoft.ML.Data;

namespace CenterFaceMLNet.DataModels
{
    public class CenterFaceImageOutput
    {
        [ColumnName(CenterFaceSettings.ModelFields.output_537)]
        public float[] heatMap { get; set; }
        [ColumnName(CenterFaceSettings.ModelFields.output_538)]
        public float[] scale { get; set; }
        [ColumnName(CenterFaceSettings.ModelFields.output_539)]
        public float[] offset { get; set; }
        [ColumnName(CenterFaceSettings.ModelFields.output_540)]
        public float[] landmarks { get; set; }
    }
}
