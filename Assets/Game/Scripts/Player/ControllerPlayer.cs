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
    [SerializeField] private ColliderPlayer colliderComponent;
    private bool IsMove { get; set; } = true;
    private float size;
    [SerializeField] private float coefSize = 0.02f;
    private float maxSize = 2.2f;
    public float Size
    {
        get => size;
        set
        {
            size = 0.1f + value * coefSize;
            if (size > 3) size = maxSize;
            
            moveObject.transform.localScale = new Vector3(size, 1, size);
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
        colliderComponent.eventCollisionGate += OnTriggerEnterSubGate;
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

    private void OnTriggerEnterSubGate(GateData data)
    {
        eventCollisionGate?.Invoke(data);
    }
}
