using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;
using PlayerRoles;
using UnityEngine;

namespace AlphaWarheadCode;

public class Config : IConfig
{
    public bool IsEnabled { get; set; } = true;
    public bool Debug { get; set; } = false;

    [Description("Roles that will be able to have a code immediately after the round and recognize it using the .code command (RoleTypeId)")]
    public List<RoleTypeId> CodeRoles { get; set; } = new()
    {
        RoleTypeId.NtfCaptain
    };

    #region CodeLen
    [Description("Len of code (-1 = random length)")]
    public int CodeLen { get; set; } = -1;

    [Description("Random length min inclusive (WORK ONLY WITH `code_len: -1`)")] 
    public int RandomCodeLenMin { get; set; } = 4;

    [Description("Random length max inclusive (WORK ONLY WITH `code_len: -1`)")]
    public int RandomCodeLenMax { get; set; } = 8;

    #endregion

    #region Hints

    [Description("Hint that will be shown when trying to activate a warhead without entering a code")]
    public string EnterCodeHint { get; set; } = "Access denied! Please enter the code";

    #endregion

    #region CommandResponses

    [Description("Less than one argument command response (only .start command)")]
    public string MoreArgumentCommandResponse { get; set; } = "The command must have more than one argument";

    [Description("Successfully command response")]
    public string SuccessfullyCommandResponse { get; set; } = "Successfully!";

    [Description("Warhead in progress command response (only .start command)")]
    public string WarheadInProgressCommandResponse { get; set; } = "Access denied! Warhead currently in progress";

    [Description("Incorrect code command response (only .start command)")]
    public string IncorrectCodeCommandResponse { get; set; } = "Access denied! IncorrectCode";

    [Description("Far from the warhead terminal command response (only .start command)")]
    public string FarTerminalCommandResponse { get; set; } = "To start, go to the warhead terminal";

    [Description("The player cannot recognize the warhead code due to his role (only .code command)")]
    public string PlayerRoleCantGetCodeCommandResponse { get; set; } = "Your role does not allow you to receive the warhead code";

    [Description("Successfully received warhead code command response (%CODE% - warhead code) (only .code command)")]
    public string SuccessfullyGetWarheadCodeCommandResponse { get; set; } = "Your code: %CODE%";

    [Description("Incorrect number of digits in warhead code (%CODELEN% - number of digits in warhead code) (only .start command)")]
    public string IncorrectNumberDigitsCommandResponse { get; set; } = "Access denied! The code should be about %CODELEN% digits";

    [Description("Warhead detonated command response (only .start command)")]
    public string WarheadDetonatedCommandResponse { get; set; } = "Access denied! Warhead currently detonated!";

    [Description("If the player has not activated the warhead button using the card key command response (only .start command)")]
    public string NotActivatedKeyCardCommandResponse { get; set; } = "You must activate the button using the 05 key card!";

    [Description("If warhead is disabled command response (only .start command)")]
    public string WarheadDisabledCommandResponse { get; set; } = "Warhead must be enabled!";

    #endregion
}