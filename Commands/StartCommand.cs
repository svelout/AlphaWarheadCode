using System;
using System.Linq;
using AlphaWarheadCode.Features;
using CommandSystem;
using Exiled.API.Features;
using UnityEngine;

namespace AlphaWarheadCode.Commands;

[CommandHandler(typeof(ClientCommandHandler))]
public class StartCommand : ICommand
{
    public string Command => "start";

    public string[] Aliases { get; } = { };

    public string Description => "";
    
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        if (arguments.Count == 0)
        {
            response = Plugin.PluginConfig.MoreArgumentCommandResponse;
            return false;
        }
        
        Player player = Player.Get(sender);
        string code = arguments.At(0);
        
        // ReSharper disable once Unity.PreferNonAllocApi
        RaycastHit[] rays = Physics.RaycastAll(player.CameraTransform.position, player.CameraTransform.forward,
            maxDistance: 1.5f);

        if (rays.Any(r => r.collider.gameObject.name == AlphaWarheadCodes.TerminalName))
        {
            if (code.Length < AlphaWarheadCodes.CodeLen)
            {
                response = Plugin.PluginConfig.IncorrectNumberDigitsCommandResponse.Replace("%CODELEN%", AlphaWarheadCodes.CodeLen.ToString());
                return false;
            }

            if (!Warhead.IsKeycardActivated)
            {
                response = Plugin.PluginConfig.NotActivatedKeyCardCommandResponse;
                return false;
            }

            if (Warhead.IsInProgress)
            {
                response = Plugin.PluginConfig.WarheadInProgressCommandResponse;
                return false;
            }

            if (Warhead.IsDetonated)
            {
                response = Plugin.PluginConfig.WarheadDetonatedCommandResponse;
                return false;
            }
            
            if (!Warhead.CanBeStarted)
            {
                response = Plugin.PluginConfig.WarheadDisabledCommandResponse;
                return false;
            }
            
            if (code == AlphaWarheadCodes.CurrentCode)
            {
                Warhead.Start();

                response = Plugin.PluginConfig.SuccessfullyCommandResponse;
                return true;
            }

            response = Plugin.PluginConfig.IncorrectCodeCommandResponse;
            return false;
        }

        response = Plugin.PluginConfig.FarTerminalCommandResponse;
        return false;
    }
}