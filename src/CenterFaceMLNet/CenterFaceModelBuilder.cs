using CenterFaceMLNet.DataModels;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Image;
using Microsoft.ML.Transforms.Onnx;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace CenterFaceMLNet
{
    public class CenterFaceModelBuilder
    {
        public readonly string _onnxModelSrc;
        public readonly string _mlModelDestn;
        private readonly MLContext mlContext;

        public CenterFaceModelBuilder(string onnxModelSrc, string mlModelDestn)
        {
            _onnxModelSrc = onnxModelSrc;
            _mlModelDestn = mlModelDestn;
            mlContext = new MLContext();
        }
        public EstimatorChain<OnnxTransformer> CreatePipeline()
        {
            EstimatorChain<OnnxTransformer> estimatorChain =
                mlContext.Transforms.ResizeImages(
                    "imageResized",
                    CenterFaceSettings.Dimentions.with,
                    CenterFaceSettings.Dimentions.height,
                    nameof(CenterFaceImageInput.Image),
                    ImageResizingEstimator.ResizingKind.Fill)
                .Append(mlContext.Transforms.ExtractPixels(
                    CenterFaceSettings.ModelFields.input_input1,
                    "imageResized"))
                .Append(mlContext.Transforms.ApplyOnnxModel(                    
                    CenterFaceSettings.Outputs,
                    CenterFaceSettings.Inputs,
                    _onnxModelSrc
                    ));
            return estimatorChain;
        }
        public void SaveMLNetModel()
        {
            EstimatorChain<OnnxTransformer> pipeline = CreatePipeline();
            IDataView emptyFitData = mlContext.Data.LoadFromEnumerable(CenterFaceImageInput.EmptyEnumerable);
            TransformerChain<OnnxTransformer> transformer = pipeline.Fit(emptyFitData);
            mlContext.Model.Save(transformer, null, _mlModelDestn);
        }
        public PredictionEngine<CenterFaceImageInput, CenterFaceImageOutput> GetMlNetPredictionEngine()
        {
            EstimatorChain<OnnxTransformer> pipeline = CreatePipeline();
            IDataView emptyFitData = mlContext.Data.LoadFromEnumerable(CenterFaceImageInput.EmptyEnumerable);
            TransformerChain<OnnxTransformer> transformer = pipeline.Fit(emptyFitData);
            return mlContext.Model.CreatePredictionEngine<CenterFaceImageInput, CenterFaceImageOutput>(transformer);
        }
        public void Predict(string imagepath)
        {
            EstimatorChain<OnnxTransformer> pipeline = CreatePipeline();
            IDataView emptyFitData = mlContext.Data.LoadFromEnumerable(CenterFaceImageInput.EmptyEnumerable);
            TransformerChain<OnnxTransformer> transformer = pipeline.Fit(emptyFitData);
            IDataView emptyTestData = mlContext.Data.LoadFromEnumerable(new List<CenterFaceImageInput>() { new CenterFaceImageInput() { Image=(Bitmap)Bitmap.FromFile(imagepath) } });
            var res=transformer.Transform(emptyTestData);
        }
    }
}
