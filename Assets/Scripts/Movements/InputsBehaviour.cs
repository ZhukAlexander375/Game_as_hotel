using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputsBehaviour : MonoBehaviour, IPlayerInputs
{
    public abstract Vector2 Direction();
    
}
