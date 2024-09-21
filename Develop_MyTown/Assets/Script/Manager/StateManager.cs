using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    //InputType
    public enum InputKeyType
    {
        Up,
        Down,
        Press
    }
    public enum KeyValue
    {
        None,
        Left,
        Right,
        Up,
        Down
    }

    //PlayerStateType
    public enum MoveState
    {
        Idle,
        Front,
        Back,
        Left,
        Right
    }
    public enum PlayerState
    {
        None,
        Move,
        interaction,
        Action
    }
}
