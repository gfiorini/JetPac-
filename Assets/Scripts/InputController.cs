using UnityEngine;

public class KeyboardController : IInputController
{

    public bool MoveRight()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }

    public bool MoveLeft()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }
}