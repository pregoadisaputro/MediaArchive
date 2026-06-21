using MyMediaArchive.Media.Service;
using MyMediaArchive.Media.View.Service;
using MyMediaArchive.Media.View.UI;

var mediaService = new MediaService();
var handlingMenuService = new HandlingUserMenuService(mediaService);
var menuQueryService = new MenuQueryService(mediaService);

var mainMenu = new MainMenu(handlingMenuService, menuQueryService);

mainMenu.Menu();
