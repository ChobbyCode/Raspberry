

namespace Raspberry.Menus
{
    /// <summary>
    /// Acts as a menu, but allows for your code to be ran instead of opening a menu
    /// </summary>
    public class MenuAction
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Menu ParentMenu { get; private set; }

        public EventHandler onOpen;

        /// <summary>
        /// MenuAction is a way for your code to be ran instead of opening a menu
        /// </summary>
        /// <param name="Name">The Name Of The Option</param>
        /// <param name="Description">Description</param>
        /// <param name="ParentMenu">The Menu This Is In.</param>
        public MenuAction(string Name, string Description, Menu ParentMenu)
        {
            this.Name = Name;
            this.Description = Description;
            this.ParentMenu = ParentMenu;
        }

        internal void OpenMenu()
        {
            Console.Clear();

            try
            {
                onOpen.Invoke(this, EventArgs.Empty);
            } catch{ }

            // Reopens the parent menu
            Rasp.OpenMenu(this.ParentMenu);
        }
    }
}
