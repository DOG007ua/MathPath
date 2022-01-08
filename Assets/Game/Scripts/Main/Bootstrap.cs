using System.Collections;
using System.Collections.Generic;
using GateFolder;
using Main;
using Main.Interface;
using Player;
using ServiceLocatorFolder;
using Spawner;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private ServiceLocator locator;
    [SerializeField] private ControllerPlayer controllerPlayer;
    [SerializeField] private GateParams gateParams;
    private IControllerInput controllerInput;
    private IControllerPoint controllerPoint;
    void Start()
    {
        InitComponents();
        InitializeLocator();
        controllerPlayer.Initialize(locator);
    }

    private void InitComponents()
    {
        controllerInput = GetComponent<IControllerInput>();
        controllerPoint = new ControllerPoints(controllerPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeLocator()
    {
        locator = new ServiceLocator();
        locator.Register<IMovePlayer>(new MovePlayer(controllerPlayer.moveObject.transform, controllerPlayer));
        locator.Register<IFactory>(new Factory(locator));
        locator.Register<ICreatorGate>(new CreatorGate(gateParams));
    }
}
