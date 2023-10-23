

namespace Raspberry.Menus
{
    /// <summary>
    /// Create A Basic Menu For Hosting Content
    /// </summary>
    public class Menu
    {
        public string MenuName { get; private set; }

        // Event Handlers
        public EventHandler onOpen;
        public EventHandler onClose;

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

        internal void OpenMenu()
        {
            bool menuOpen = true;
            while (menuOpen)
            {
                // Print The Menu
                Console.Clear();

                int l = 1; // Number We Are On
                foreach(var item in _menuItems)
                {
                    Console.WriteLine($"({l}) - {item.Description}");
                    l++;
                }

                // Do Menu Logic
                ConsoleKeyInfo key = Console.ReadKey(true);
                char KeyChar = key.KeyChar;
                string KeyL = KeyChar.ToString();

                // By doing this we know it is not a letter, and either must be
                // a special character or number
                if(KeyL.ToUpper() == KeyL)
                {
                    Console.WriteLine("Not A Letter");
                }

                Console.ReadLine();
            }
        }
    }
}
