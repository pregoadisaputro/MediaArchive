using MyMediaArchive.Media.View.Service;
using Spectre.Console;

namespace MyMediaArchive.Media.View.UI;

public sealed class MainMenu
{
    private readonly HandlingUserMenuService _userMenuService;

    public MainMenu(HandlingUserMenuService userMenuService) => _userMenuService = userMenuService;

    public void Menu()
    {
        var isRunning = true;

        while (isRunning)
        {
            AnsiConsole.Clear();

            var header = new FigletText("My Media Archive");
            AnsiConsole.Write(header);

            var userChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>().Title("Choose:").AddChoices("Create Media", "")
            );
        }
    }
}
