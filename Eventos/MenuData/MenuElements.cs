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

namespace Eventos.MenuData
{
    //<summary>
    //    This class has the data for the sidebar with the menu
    //</summary>

    public class MenuElements
    {
        public List<MenuList> menuElements { get; set; }

        public MenuElements()
        {
            menuElements = new List<MenuList>()
            {
                new MenuList() {iconPath="", menuText="" },
                new MenuList() {iconPath="map_placeholder_icon", menuText="Lugar" },
                new MenuList() {iconPath="calendar_with_clock", menuText="Calendario" },
                new MenuList() {iconPath="lady_icon", menuText="Expositores" },
                new MenuList() {iconPath="image_icon", menuText="Galería" },
                new MenuList() {iconPath="question_icon", menuText="Preguntas Frecuentes" },
                new MenuList() {iconPath="online_help_icon", menuText="Contacto" },
                new MenuList() {iconPath="ic_trending_up_white_48dp", menuText="Facebook" }
            };
        }
    }
}