# Raspberry

Raspberry is an easy way to quickly make menus for your next Console Application in c#.

## Getting Started

### Installation

To download Raspberry, navigate to the NuGet package manager in Visual Studios and search for RaspberryMenus. Click on the one by ChobbyCode, and hit install.

### Creating 

To create a menu in Raspberry, simply create an instance of the Menu class:

```c#
// You must give it the name of the menu

Menu menu = new Menu("PutTheNameOfTheMenuHere");
```

To create an option to add to your menu, you can create a menu option:

> Options should be provided with a name, description and a menu that they will open.

```c#
// Options require a name, description and an already existing menu to open.

MenuOption newOption = new MenuOption("OptionName", "OptionDescription", MenuTheOptionWillOpen);
```

To add an option to a menu:

```c#
// To add it to a menu, type the name of the menu and say addOption and pass in your option.

menu.AddOption(newOption);
```

Raspberry also needs to be provided a default menu, and told when to start:

```c#
// Just pass in an already existing menu
Rasp.SetDefaultMenu(defaultMenu);
Rasp.StartRaspberry();
```

Below is a quick demo, that allows you to move between two different menus.

```c#
using Raspberry;
using Raspberry.Menus;

namespace Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Menu menu = new Menu("main"); // main menu
            Menu sec = new Menu("second"); // second menu

            // Create buttons for main menu
            MenuOption openSec = new MenuOption("second", "Open the second menu", sec);
            menu.AddOption(openSec);

            // Create buttons for second menu
            MenuOption closeSec = new MenuOption("closeSec", "Close the second menu", menu);
            sec.AddOption(closeSec);

            // Start the menu
            Rasp.SetDefaultMenu(menu);
            Rasp.StartRaspberry();
        }
    }
}

```

### Custom Actions

Now, just having menus on your app is no good. You need functionality. Luckily Raspberry has an easy way to add functionality to an option.

Instead of creating a MenuOption, create a MenuAction. Menu actions have event handlers which are called when the window is opened.

Below is a modified version of the first program to have a MenuAction instead of an MenuOption.

> MenuActions work the same as MenuOptions but require event handlers instead.

```c#
Menu menu = new Menu("main"); // main menu
Menu actionMenu = new Menu("Action Menu"); // main menu

// Create buttons for main menu
MenuOption openSec = new MenuOption("second", "Open the second menu", actionMenu);
menu.AddOption(openSec);

// Create buttons for second menu
MenuAction action = new MenuAction("Action", "Run An Action", actionMenu);
actionMenu.AddOption(action);

// When the event handler is called we run the function
action.onOpen += ActionRunned;

// Start the menu
Rasp.SetDefaultMenu(menu);
Rasp.StartRaspberry();
```

action.onOpen calls a function called ActionRunned. We can create this function as below.

```c#
public static void ActionRunned (object sender, EventArgs e)
{
    Console.WriteLine("Action Run");
    Console.ReadLine();
}
```

In summary, we swapped the MenuOption out for a MenuAction and created a function for it to call when ran.
