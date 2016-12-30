using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Square.Picasso;

namespace Eventos.Utility
{
    //<summary>
    //This class overrides the ITransformation and is used for a Picasso transform, in this case, the function Transform creates the circular shape for a given bitmap.
    //</summary>

    class RoundedCornerTransform : Java.Lang.Object, ITransformation
    {
        public string Key
        {
            get
            {
                return "Rounded Transform";
            }
        }

        public Bitmap Transform(Bitmap p0)
        {
            int minEdge = Math.Min(p0.Width, p0.Height);
            int dx = (p0.Width - minEdge) / 2;
            int dy = (p0.Height - minEdge) / 2;

            Shader shader = new BitmapShader(p0, Shader.TileMode.Clamp, Shader.TileMode.Clamp);
            Matrix matrix = new Matrix();
            matrix.SetTranslate(-dx, -dy);
            shader.SetLocalMatrix(matrix);

            Paint paint = new Paint();
            paint.AntiAlias = true;
            paint.SetShader(shader);

            Bitmap output = Bitmap.CreateBitmap(minEdge, minEdge, p0.GetConfig());
            Canvas canvas = new Canvas(output);
            canvas.DrawOval(new RectF(0, 0, minEdge, minEdge), paint);

            p0.Recycle();
            return output;
        }
    }
}