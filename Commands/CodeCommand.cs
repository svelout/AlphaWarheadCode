using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using AlphaWarheadCode.Features;
using CommandSystem;
using Exiled.API.Features;

namespace AlphaWarheadCode.Commands;

[CommandHandler(typeof(ClientCommandHandler))]
public class CodeCommand : ICommand
{
    public string Command => "code";

    public string[] Aliases { get; } = { };

    public string Description => "";
    
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, [UnscopedRef] out string response)
    {
        Player player = Player.Get(sender);

        if (Plugin.PluginConfig.CodeRoles.Contains(player.Role))
        {
            response = Plugin.PluginConfig.SuccessfullyGetWarheadCodeCommandResponse.Replace("%CODE%", AlphaWarheadCodes.CurrentCode);
            return true;
        }

        response = Plugin.PluginConfig.PlayerRoleCantGetCodeCommandResponse;
        return false;
    }
}