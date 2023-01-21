using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    #region Data Members
    [Header("Player Character")]
    [Tooltip("How fast the character turns")]
    [Range(0.0f, 0.3f)]
    public float RotationSmoothTime;

    public GameObject projectile;

    //
    public Vector2 _lookDirection;
    private float _targetRotation = 0.0f;
    private float _rotationVelocity;
    [HideInInspector] public bool rotationLock;

    [HideInInspector] public PlayerCharacterInputs input;

    private Quaternion _startRotation;
    #endregion

    #region Unity Callbacks
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        input = GetComponent<PlayerCharacterInputs>();

        _startRotation = transform.rotation;
    }
    #endregion

    #region Methods
    public void Look()
    {
        _lookDirection = input.look;

        // normalise input direction
        Vector3 inputDirection = new Vector3(_lookDirection.x, 0.0f, _lookDirection.y).normalized;

        // if there is a move input rotate player when the player is moving
        if (_lookDirection != Vector2.zero)
        {
            _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
                RotationSmoothTime);

            // rotate to face input direction relative to camera position
            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        }
    }

    public void MagicAttackFire()
    {
        Instantiate(projectile, attackOrigin.position, transform.rotation);
    }

    public void Restart()
    {
        CancelInvoke();
        transform.rotation = _startRotation;
    }
    #endregion
}
