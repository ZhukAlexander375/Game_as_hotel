using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtentions
{
    public static Vector3 Flat(this Vector2 vect)
    {
        return new Vector3(vect.x, 0, vect.y);
    }
}
