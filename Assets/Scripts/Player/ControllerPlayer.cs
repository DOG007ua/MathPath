using System.Collections;
using System.Collections.Generic;
using Main.Interface;
using Player;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    public float Size { get; private set; }
    public bool IsMove { get; set; }
    private IControllerInput input;
    private IMovePlayer movePlayer;

    public ControllerPlayer(IControllerInput input, IMovePlayer movePlayer)
    {
        this.input = input;
        this.movePlayer = movePlayer;
    }

    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (IsMove)
        {
            movePlayer.Move(input.PositionMouse);
        }
    }
}
