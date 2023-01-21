using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanvasInputs : MonoBehaviour
{
    [Header("Output")]
    public PlayerCharacterInputs playerCharacterInputs;

    public void VirtualLookInput(Vector2 virtualLookDirection)
    {
        playerCharacterInputs.LookInput(virtualLookDirection);
    }
}
