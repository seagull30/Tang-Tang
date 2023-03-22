using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string MoveAxisName = "Vertical";
    private const string RotateAxisName = "Horizontal";

    public float MoveDirection { get; private set; }
    public float RotateDirection { get; private set; }

    void Update()
    {
        MoveDirection = Input.GetAxis(MoveAxisName);

        RotateDirection = Input.GetAxis(RotateAxisName);

    }
}
