

namespace Raspberry.Menus
{
    /// <summary>
    /// Create A Basic Menu For Hosting Content
    /// </summary>
    public class Menu
    {
        public string MenuName { get; private set; }

        // Items on the menu
        private List<MenuOption> _menuItems = new List<MenuOption>();

        public Menu(string MenuName)
        {
            this.MenuName = MenuName;
        }

        public void AddOption(MenuOption Option)
        {
            _menuItems.Add(Option);
        }
    }
}
