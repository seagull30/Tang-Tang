using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string VAxisName = "Vertical";
    private const string HAxisName = "Horizontal";



    public float VERTICAL_MOVEMENT { get; private set; }
    public float HORIZONTAL_MOVEMENT { get; private set; }

    void Update()
    {
        VERTICAL_MOVEMENT = Input.GetAxisRaw(VAxisName);
        HORIZONTAL_MOVEMENT = Input.GetAxisRaw(HAxisName);

    }
}
