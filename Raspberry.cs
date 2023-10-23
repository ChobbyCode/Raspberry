using Raspberry.Menus;

namespace Raspberry
{
    public class Rasp
    {

        private static Menu BaseMenu;

        /// <summary>
        /// Forcefully opens a menu
        /// </summary>
        /// <param name="menu">The Menu You Want To Open</param>
        public static void OpenMenu(Menu menu)
        {
            menu.OpenMenu();
        }

        /// <summary>
        /// Sets the default/base menu to open to
        /// </summary>
        /// <param name="menu">The Base Menu</param>
        public static void SetDefaultMenu(Menu menu)
        {
            BaseMenu = menu;
        }

        /// <summary>
        /// Starts The Raspberry Menu From Default Menu
        /// </summary>
        /// <returns>Returns 1 if succeeded, returns 0 if failed.</returns>
        public static int StartRaspberry()
        {
            if(BaseMenu == null) return 0;
            else
            {
                OpenMenu(BaseMenu);
                return 1;
            }
        }
    }
}
