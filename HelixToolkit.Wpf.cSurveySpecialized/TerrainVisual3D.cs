// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TerrainVisual3D.cs" company="Helix 3D Toolkit">
//   http://helixtoolkit.codeplex.com, license: MIT
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace HelixToolkit.Wpf.cSurveySpecialized
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Media3D;

    /// <summary>
    /// A visual element that shows a terrain model.
    /// </summary>

    public class TerrainVisual3D : ModelVisual3D
    {
        /// <summary>
        /// The source property.
        /// </summary>
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
            "Source", typeof(cITerrainElevation), typeof(TerrainVisual3D), new UIPropertyMetadata(null, SourceChanged));

                /// <summary>
        /// The visual child.
        /// </summary>
        private readonly ModelVisual3D visualChild;

        /// <summary>
        /// Initializes a new instance of the <see cref = "TerrainVisual3D" /> class.
        /// </summary>
        public TerrainVisual3D()
        {
            this.visualChild = new ModelVisual3D();
            this.Children.Add(this.visualChild);
        }

        /// <summary>
        /// Gets or sets the source terrain file.
        /// </summary>
        /// <value>The source.</value>
        public cITerrainElevation Source
        {
            get
            {
                return (cITerrainElevation)this.GetValue(SourceProperty);
            }

            set
            {
                this.SetValue(SourceProperty, value);
            }
        }

        /// <summary>
        /// The source changed.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        protected static void SourceChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            ((TerrainVisual3D)obj).UpdateModel();
        }

        public void UpdateTexture()
        {
            GeometryModel3D oModel = (GeometryModel3D)this.visualChild.Content;

            TerrainTexture oTexture;
            if (this.Source.Image == null)
            {
                SlopeTexture oSlopeTexture = new SlopeTexture(10);
                oSlopeTexture.Brush = new SolidColorBrush(Colors.Gray);
                oSlopeTexture.Brush.Opacity = this.Source.Opacity;
                oSlopeTexture.Brush.Freeze();
                oTexture = oSlopeTexture;
            }
            else
            {
                MapTexture oMapTexture = new MapTexture(this.Source.Image, this.Source.Opacity) { Left = oTerrainModel.Left, Right = oTerrainModel.Right, Top = oTerrainModel.Top, Bottom = oTerrainModel.Bottom };
                oTexture = oMapTexture;
            }
            oModel.Material = oTexture.Material;
            oModel.BackMaterial = oTexture.Material;
        }

        TerrainModel oTerrainModel;

        /// <summary>
        /// Updates the model.
        /// </summary>
        private void UpdateModel()
        {
            //var r = new TerrainModel();
            oTerrainModel = new TerrainModel();
            oTerrainModel.Load(this.Source);

            //r.Texture = new SlopeDirectionTexture(0);
            //r.Texture = new SlopeTexture(8);
            if (this.Source.Image == null)
            {
                SlopeTexture oTexture = new SlopeTexture(10);
                oTexture.Brush = new SolidColorBrush(Colors.Gray);
                oTexture.Brush.Opacity = this.Source.Opacity;
                oTexture.Brush.Freeze();
                oTerrainModel.Texture = oTexture;
            }
            else
            {
                oTerrainModel.Texture = new MapTexture(this.Source.Image, this.Source.Opacity) { Left = oTerrainModel.Left, Right = oTerrainModel.Right, Top = oTerrainModel.Top, Bottom = oTerrainModel.Bottom };
            }
            this.visualChild.Content = oTerrainModel.CreateModel(this.Source.Lod);
        }

    }
}