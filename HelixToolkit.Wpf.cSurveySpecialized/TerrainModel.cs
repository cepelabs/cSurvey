// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TerrainModel.cs" company="Helix 3D Toolkit">
//   http://helixtoolkit.codeplex.com, license: MIT
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace HelixToolkit.Wpf.cSurveySpecialized
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Text;
    using System.Windows.Media.Media3D;
    using System.Xml;

    /// <summary>
    /// Represents a terrain model.
    /// </summary>
    /// <remarks>
    /// Supports the following terrain file types
    /// .bt
    /// .btz
    ///  <para>
    /// Read .bt files from disk, keeps the model data and creates the Model3D.
    /// The .btz format is a gzip compressed version of the .bt format.
    ///  </para>
    /// </remarks>
    public class TerrainModel 
    {
        /// <summary>
        /// Gets or sets the bottom.
        /// </summary>
        /// <value>The bottom.</value>
        public double Bottom { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public float[] Data { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the left.
        /// </summary>
        /// <value>The left.</value>
        public double Left { get; set; }

        /// <summary>
        /// Gets or sets the maximum Z.
        /// </summary>
        /// <value>The maximum Z.</value>
        public double MaximumZ { get; set; }

        /// <summary>
        /// Gets or sets the minimum Z.
        /// </summary>
        /// <value>The minimum Z.</value>
        public double MinimumZ { get; set; }

        /// <summary>
        /// Gets or sets the offset.
        /// </summary>
        /// <value>The offset.</value>
        public Point3D Offset { get; set; }

        /// <summary>
        /// Gets or sets the right.
        /// </summary>
        /// <value>The right.</value>
        public double Right { get; set; }

        /// <summary>
        /// Gets or sets the texture.
        /// </summary>
        /// <value>The texture.</value>
        public TerrainTexture Texture { get; set; }

        /// <summary>
        /// Gets or sets the top.
        /// </summary>
        /// <value>The top.</value>
        public double Top { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width { get; set; }

        public double Scale { get; set; }

        /// <summary>
        /// Creates the 3D model of the terrain.
        /// </summary>
        /// <param name="lod">
        /// The level of detail.
        /// </param>
        /// <returns>
        /// The Model3D.
        /// </returns>
        public GeometryModel3D CreateModel(int lod)
        {
            int ni = this.Height / lod;
            int nj = this.Width / lod;
            var pts = new List<Point3D>(ni * nj);

            //double mx = (this.Left + this.Right) / 2;
            //double my = (this.Top + this.Bottom) / 2;
            //double mz = (this.MinimumZ + this.MaximumZ) / 2;

            //this.Offset = new Point3D(mx, my, mz);
            //this.Offset = new Point3D(100, 100, 100);

            for (int i = 0; i < ni; i++)
            {
                for (int j = 0; j < nj; j++)
                {
                    double x = this.Left + (this.Right - this.Left) * j / (nj - 1);
                    double y = this.Top + (this.Bottom - this.Top) * i / (ni - 1);
                    double z = this.Data[i * lod * this.Width + j * lod];

                    x = x * Scale;
                    y = y * Scale;

                    //x -= this.Offset.X;
                    //y -= this.Offset.Y;
                    //z -= this.Offset.Z;
                    
                    pts.Add(new Point3D(x, y, z));
                    //pts.Add(new Point3D(x, z, y));
                }
            }

            var mb = new MeshBuilder(false, false);
            mb.AddRectangularMesh(pts,nj);
            var mesh = mb.ToMesh();

            var material = Materials.Green;

            if (this.Texture != null)
            {
                this.Texture.Calculate( this, mesh);
                material = this.Texture.Material;
                mesh.TextureCoordinates = this.Texture.TextureCoordinates;
            }

            return new GeometryModel3D { Geometry = mesh, Material = material, BackMaterial = material };
        }

        /// <summary>
        /// Loads the specified file.
        /// </summary>
        /// <param name="source">
        /// The file name.
        /// </param>
        public void Load(cITerrainElevation Data)
        {
            if (Data == null)
            {
                throw new ArgumentNullException("source");
            }

            this.ReadTerrainFile(Data);
        }

        /// <summary>
        /// Reads a .bt (Binary terrain) file.
        /// http://www.vterrain.org/Implementation/Formats/BT.html
        /// </summary>
        /// <param name="stream">
        /// The stream.
        /// </param>
        public void ReadTerrainFile(cITerrainElevation Data)
        {
                //var buffer = reader.ReadBytes(10);
                //var enc = new ASCIIEncoding();
                //var marker = enc.GetString(buffer);
                //if (!marker.StartsWith("binterr"))
                //{
                //    throw new FileFormatException("Invalid marker.");
                //}

                //var version = marker.Substring(7);


            this.Width = Data.Width ;
                this.Height = Data.Height ;
                //short dataSize = reader.ReadInt16();
                //bool isFloatingPoint = reader.ReadInt16() == 1;
                //short horizontalUnits = reader.ReadInt16();
                //short utmZone = reader.ReadInt16();
                //short datum = reader.ReadInt16();
                this.Left = 0;
                this.Right = Data.Width;
                this.Bottom = Data.Height;
                this.Top = 0;
                //short proj = reader.ReadInt16();
                //float scale = reader.ReadSingle();
                //var padding = reader.ReadBytes(190);

                //int index = 0;
                this.Data = Data.Data; //new double[this.Width * this.Height];
                this.MinimumZ = Data.Minimum;
                this.MaximumZ = Data.Maximum;
                this.Scale = Data.Scale;
        }

        ///// <summary>
        ///// Reads the specified .bt terrain file.
        ///// </summary>
        ///// <param name="path">
        ///// The file name.
        ///// </param>
        //private void ReadTerrainFile(string path)
        //{
        //    using (var infile = File.OpenRead(path))
        //    {
        //        this.ReadTerrainFile(infile);
        //    }
        //}

        ///// <summary>
        ///// Read a gzipped .bt file.
        ///// </summary>
        ///// <param name="source">
        ///// The source.
        ///// </param>
        //private void ReadZippedFile(string source)
        //{
        //    using (var infile = File.OpenRead(source))
        //    {
        //        var deflateStream = new GZipStream(infile, CompressionMode.Decompress, true);
        //        this.ReadTerrainFile(deflateStream);
        //    }
        //}

    }
}