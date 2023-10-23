

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

                Console.WriteLine();
                Console.WriteLine($"Menu: {MenuName}");
                Console.WriteLine();

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

                try
                {
                    int option = Convert.ToInt32(KeyL);
                    Console.WriteLine(option);

                    Console.WriteLine(_menuItems[option - 1].Description);
                    _menuItems[option - 1].OpenMenu();
                    
                    menuOpen = false;
                }catch
                {
                    Console.WriteLine("Please Enter A Valid Option");
                    Console.ReadKey(true);
                }
            }
        }
    }
}
