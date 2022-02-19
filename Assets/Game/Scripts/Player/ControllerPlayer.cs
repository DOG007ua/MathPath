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
    private ICalculationSize calculationSize;
    private bool IsMove { get; set; } = true;
    private float size;
    private float maxSize = 1.5f;
    private float minSize = 0.2f;
    public float Size
    {
        get => size;
        private set
        {
            size = value;
            if (size > maxSize) size = maxSize;
            if (size < minSize) size = minSize;
            moveObject.transform.localScale = new Vector3(size, 1, size);
        }
    }
    
    
    public event Action<GateData> eventCollisionGate;
    private IControllerInput input;
    private IMovePlayer movePlayer;

    public void Initialize(ServiceLocator locator)
    {
        Size = minSize;
        this.input = locator.GetService<IControllerInput>();
        this.movePlayer = locator.GetService<IMovePlayer>();
        colliderComponent.eventCollisionGate += OnTriggerEnterSubGate;
        calculationSize = new CalculationSizePlayer();
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

    public void UpdatePoints(float points)
    {
        Size = calculationSize.GetSize(points);
    }
    

    private void OnTriggerEnterSubGate(GateData data)
    {
        eventCollisionGate?.Invoke(data);
    }
}
