using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelixToolkit.Wpf.cSurveySpecialized
{

    public interface cITerrainElevation
    {
        int Width
        {
            get;
        }
        
        int Height
        {
            get;
        }

        float[] Data
        {
            get;
        }

        float Minimum
        {
            get;
        }

        float Maximum
        {
            get;
        }

        float Scale
        {
            get;
        }

        System.Drawing.Bitmap Image
        {
            get;
            set;
        }

        float Opacity
        {
            get;
        }

        int Lod
        {
            get;
        }

    }
}
