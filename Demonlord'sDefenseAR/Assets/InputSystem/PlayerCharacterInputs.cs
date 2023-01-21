using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterInputs : MonoBehaviour
{
    [Header("Character Input Values")]
    public Vector2 look;
    public bool magic;

    public void LookInput(Vector2 newLookDirection)
    {
        look = newLookDirection;
    }

    public void MagicInput(bool newMagicState)
    {
        magic = newMagicState;
    }
}
