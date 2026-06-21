using MyMediaArchive.Media.View.Service;
using Spectre.Console;

namespace MyMediaArchive.Media.View.UI;

public sealed class MainMenu
{
    private readonly HandlingUserMenuService _userMenuService;
    private readonly MenuQueryService _menuQueryService;

    public MainMenu(HandlingUserMenuService userMenuService, MenuQueryService menuQueryService)
    {
        _userMenuService = userMenuService;
        _menuQueryService = menuQueryService;
    }

    public void Menu()
    {
        var isRunning = true;

        while (isRunning)
        {
            AnsiConsole.Clear();

            var header = new FigletText("My Media Archive");
            AnsiConsole.Write(header);

            var userChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose:")
                    .AddChoices("Add Media", "See All Media", "Find Media", "Exit")
            );

            switch (userChoice)
            {
                case "Add Media":
                    _userMenuService.HandleCreateMedia();
                    break;

                case "See All Media":
                    _menuQueryService.SeeAllMedia();
                    break;

                case "Find Media":
                    _menuQueryService.FindMedia();
                    break;

                case "Exit":
                    AnsiConsole.MarkupLine("Exited.");
                    isRunning = false;
                    break;
            }

            if (isRunning)
            {
                AnsiConsole.WriteLine();
                AnsiConsole.MarkupLine("Press enter to continue..");
                Console.ReadLine();
            }
        }
    }
}
