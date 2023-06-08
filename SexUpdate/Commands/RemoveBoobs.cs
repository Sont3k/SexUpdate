using System;
using System.Linq;
using CommandSystem;
using Exiled.API.Features;


[CommandHandler(typeof(RemoteAdminCommandHandler))]
internal class remove : ICommand
{
    public string Command { get; } = "removeboobs";

    public string[] Aliases { get; } = Array.Empty<string>();

    public string Description { get; } = "removeboobs";

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        Player.Get(sender).GameObject.GetComponent<BoobsComponent>().RemoveBoobs();
        response = $"removed";
        return true;
    }
}