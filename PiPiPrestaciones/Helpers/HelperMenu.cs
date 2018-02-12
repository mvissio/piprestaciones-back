using PiPiPrestaciones.Models;
using PiPiPrestaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Helpers
{
    public class HelperMenu
    {
        private static HelperMenu instance;

        public static HelperMenu getInstance()
        {
            return instance ?? (instance = new HelperMenu());
        }

        public MenuMob convertMapToMapMob(Menu menu)
        {
            MenuMob menuMob = new MenuMob();
            menuMob.MenuId = menu.MenuId;
            menuMob.TitleMenu = menu.TitleMenu;
            menuMob.Type = menu.Type;
            menuMob.Order = menu.Order;
            menuMob.Status = menu.Status;
            menuMob.Icon = menu.Icon;
            menuMob.CssModelItemMenu = menu.CssModelItemMenu;
            menuMob.CssModelMenu = menu.CssModelMenu;
            return menuMob;
        }
    }
}