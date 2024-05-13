using System.Linq;
using AdvancedHintsSvelout;
using AlphaWarheadCode.Features;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Warhead;

namespace AlphaWarheadCode;

internal sealed class EventHandlers
{
    public void OnRoundStarted()
    {
        AlphaWarheadCodes.CurrentCode = AlphaWarheadCodes.GenerateNewCode(out int len);
        AlphaWarheadCodes.CodeLen = len;
    }

    public void OnStartingWarhead(StartingEventArgs ev)
    {
        if ((!Warhead.IsDetonated || !Warhead.IsInProgress) && Warhead.IsKeycardActivated && ev.Player != Server.Host)
        {
            ev.IsAllowed = false;
            ev.Player.ShowManagedHint(Plugin.PluginConfig.EnterCodeHint, 3f, overrideQueue: false);
        }
    }
}