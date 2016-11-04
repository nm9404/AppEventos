using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Eventos.core.DataService;
using MImages = Eventos.core.Model.Image;

namespace Eventos.Utility
{
    public class ImageLoader
    {
        private List<Bitmap> presentersThumbs;

        public static List<Bitmap> ReturnGalleryThumbs(List<MImages> imageList)
        {
            List<Bitmap> galleryThumbs = new List<Bitmap>();
            int iterator = 1;
            foreach (var image in imageList)
            {
                string url = "http://testappeventos.webcindario.com/Imagenes/ImageGallery/Thumbs/" + (iterator).ToString().TrimStart('0') + ".jpg";
                galleryThumbs.Add(ImageHelper.GetImageBitmapFromUrl(url));
                iterator++;
            }
            return galleryThumbs;
        }
    }
}