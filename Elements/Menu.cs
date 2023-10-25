

namespace Raspberry.Menus
{
    /// <summary>
    /// Create A Basic Menu For Hosting Content
    /// </summary>
    public class Menu
    {
        public string MenuName { get; private set; }
        internal List<string>? Logo { get; set; } = null;
        internal ConsoleColor LogoColour { get; set; } = ConsoleColor.Red;

        // Event Handlers
        public EventHandler onOpen;
        public EventHandler onClose;

        // Items on the menu
        private List<dynamic> _menuItems = new List<dynamic>();

        public Menu(string MenuName)
        {
            this.MenuName = MenuName;
        }

        public void AddOption(MenuOption Option)
        {
            _menuItems.Add(Option);
        }

        public void AddOption(MenuAction Action)
        {
            _menuItems.Add(Action);
        }

        internal void OpenMenu()
        {
            bool menuOpen = true;
            while (menuOpen)
            {
                // Print The Menu
                Console.Clear();

                if (Logo != null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Menu: {MenuName}");
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = LogoColour;
                    foreach (string logoLine in Logo)
                    {
                        Console.WriteLine(logoLine);
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }

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
