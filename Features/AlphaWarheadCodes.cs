using System.Collections.Generic;
using Exiled.API.Features;
using PlayerRoles;
using UnityEngine;

namespace AlphaWarheadCode.Features;

internal static class AlphaWarheadCodes
{
    internal static string CurrentCode { get; set; }
    
    internal static int CodeLen { get; set; }

    internal const string TerminalName = "Panel3";

    internal static string GenerateNewCode(out int codeLen)
    {
        string code = "";
        for (int i = 0; 
             i <= (Plugin.PluginConfig.CodeLen < 0 
                 ? Random.Range(Plugin.PluginConfig.RandomCodeLenMin, Plugin.PluginConfig.RandomCodeLenMax) : Plugin.PluginConfig.CodeLen); i++)
        {
            code += Random.Range(0, 9).ToString();
        }

        codeLen = code.Length;
        return code;
    }
}