using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardInputs : InputsBehaviour
{
    public override Vector2 Direction()
    {
        var inputs = new Vector2() {
            x = Input.GetAxis("Horizontal"),
            y = Input.GetAxis("Vertical")
        };

        return inputs;
    }
}
