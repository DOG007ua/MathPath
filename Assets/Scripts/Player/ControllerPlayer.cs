using System.Collections;
using System.Collections.Generic;
using Main.Interface;
using Player;
using ServiceLocatorFolder;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    public float Size { get; private set; }
    public bool IsMove { get; set; } = true;
    private IControllerInput input;
    private IMovePlayer movePlayer;

    public void Initialize(ServiceLocator locator)
    {
        Size = 1;
        this.input = locator.GetService<IControllerInput>();
        this.movePlayer = locator.GetService<IMovePlayer>();
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
