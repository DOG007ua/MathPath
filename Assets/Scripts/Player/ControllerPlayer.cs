using System;
using System.Collections;
using System.Collections.Generic;
using Main.Interface;
using Player;
using ServiceLocatorFolder;
using UnityEngine;
using GateFolder;

public class ControllerPlayer : MonoBehaviour
{
    public GameObject moveObject;
    public bool IsMove { get; set; } = true;
    private float size;
    private float coefSize = 0.1f;
    public float Size 
    {
        get
        {
            return size;
        }
        set
        {
            size = value;
            var sizeTransform = 0.1f + size * coefSize;
            if (sizeTransform > 5) sizeTransform = 5;
            moveObject.transform.localScale = new Vector3(sizeTransform, 1, sizeTransform);
            Debug.Log($"Size: {Size}");
        }
    }
    
    
    public event Action<GateData> eventCollisionGate;
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

    private void OnTriggerEnter(Collider other)
    {
        var gate = other.GetComponent<Gate>();
        if(gate == null)    return;
        
        eventCollisionGate?.Invoke(gate.data);
    }
}
