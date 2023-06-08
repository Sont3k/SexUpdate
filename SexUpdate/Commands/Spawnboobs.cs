using System;
using System.Linq;
using CommandSystem;
using Exiled.API.Features;
using UnityEngine;


[CommandHandler(typeof(RemoteAdminCommandHandler))]
internal class Boobsspawner : ICommand
{
    public string Command { get; } = "spawnboobs";

    public string[] Aliases { get; } = Array.Empty<string>();

    public string Description { get; } = "funny";

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        var player = Player.Get(sender);
        if (player.GameObject.TryGetComponent<BoobsComponent>(out BoobsComponent component))
        {
            component.RemoveBoobs();
        }
        player.GameObject.AddComponent<BoobsComponent>().SpawnBoobs();
        response = $"Spawned";
        return true;
    }
}