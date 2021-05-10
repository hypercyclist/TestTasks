using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent
{
    public Vector3 worldPosition;

    public MouseEvent(Vector3 _worldPosition)
    {
        worldPosition = _worldPosition;
        worldPosition.z = -2;
    }
}
