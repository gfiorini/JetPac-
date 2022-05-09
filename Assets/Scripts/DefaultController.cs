using UnityEngine;
public class DefaultController : IInputController
{
    public bool MoveLeft()
    {
        return Input.GetAxisRaw("Horizontal") < 0;
    }

    public bool MoveRight()
    {
        return Input.GetAxisRaw("Horizontal") > 0;
    }

    public bool Jump()
    {
        return Input.GetAxisRaw("Vertical") > 0 || Input.GetButton("Jump");
    }
}