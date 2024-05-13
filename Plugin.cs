using System;
using Exiled.API.Features;
using Warhead = Exiled.Events.Handlers.Warhead;
using Server = Exiled.Events.Handlers.Server;

namespace AlphaWarheadCode;

public class Plugin : Plugin<Config>
{
    public override string Author => "SveloutDevelops";

    public override string Name => "AlphaWarheadCode";

    public override string Prefix => "alpha_warhead_code";

    public override Version Version => new(1, 0, 0);

    public override Version RequiredExiledVersion => new(8, 8, 1);

    public static Plugin Instance;
    public static Config PluginConfig;
    private EventHandlers eh;

    public override void OnEnabled()
    {
        Instance = this;
        PluginConfig = Config;
        
        eh = new();
        Warhead.Starting += eh.OnStartingWarhead;
        Server.RoundStarted += eh.OnRoundStarted;
            
        base.OnEnabled();
    }

    public override void OnDisabled()
    {
        Instance = null;
        
        Warhead.Starting -= eh.OnStartingWarhead;
        Server.RoundStarted -= eh.OnRoundStarted;
        eh = null;
            
        base.OnDisabled();
    }
}