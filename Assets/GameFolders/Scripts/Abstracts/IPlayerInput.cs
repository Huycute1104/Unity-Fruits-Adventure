using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abstracts.Input
{
    public interface IPlayerInput
    {
        float HorizontalAxis { get; }
        bool IsJumpButtonDown { get; }
        bool IsJumpButton { get; }
        bool IsDownButton { get; }
        bool IsInteractButton { get; }
        bool IsExitButton { get; }
    }
}
