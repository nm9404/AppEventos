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
    public class MenuElements
    {
        public List<MenuList> menuElements { get; set; }

        public MenuElements()
        {
            menuElements = new List<MenuList>()
            {
                new MenuList() {iconPath="", menuText="" },
                new MenuList() {iconPath="ic_view_module_white_48dp", menuText="Lugar" },
                new MenuList() {iconPath="ic_trending_up_white_48dp", menuText="Calendario" },
                new MenuList() {iconPath="ic_access_time_white_48dp", menuText="Expositores" },
                new MenuList() {iconPath="ic_settings_white_48dp", menuText="Galería" },
                new MenuList() {iconPath="ic_keyboard_tab_white_48dp", menuText="Preguntas Frecuentes" },
                new MenuList() {iconPath="ic_keyboard_tab_white_48dp", menuText="Contacto" },
                new MenuList() {iconPath="ic_trending_up_white_48dp", menuText="Facebook" }
            };
        }
    }
}