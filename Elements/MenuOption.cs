

namespace Raspberry.Menus
{
    /// <summary>
    /// Add this to a menu, to have options on the menu.
    /// </summary>
    public class MenuOption
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        
        public Menu openMenu { get; private set; }

        public MenuOption(string Name, string Description, Menu OpenMenu)
        {
            this.Name = Name;
            this.Description = Description;
            this.openMenu = OpenMenu;
        }

        internal void OpenMenu()
        {
            Rasp.OpenMenu(this.openMenu);
        }
    }
}
