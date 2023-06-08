using Exiled.API.Features;
using System;
using MapEvent = Exiled.Events.Handlers.Map;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

public class SexUpdate : Plugin<Config>
{
    public override string Author => "Tiliboyy";
    public override string Name => "SexUpdate";
    public override string Prefix => "Sex";
    public override Version Version => new(1, 0, 0);
    public override Version RequiredExiledVersion => new(6, 0, 0, 0);
    public EventHandlers EventHandler;
    public static SexUpdate Instance;

    public override void OnEnabled()
    {
        SexUpdate.Instance = this;
        EventHandler = new EventHandlers();
        Server.ReloadedConfigs += EventHandler.OnRelaod;
        EventHandler = new EventHandlers();
    }


    public override void OnDisabled()
    {
        SexUpdate.Instance = null;
        EventHandler = null;
    }
}