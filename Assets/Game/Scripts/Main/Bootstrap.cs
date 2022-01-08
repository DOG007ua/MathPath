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
    private IFactory factory;
    
    void Start()
    {
        InitComponents();
        InitializeLocator();
        factory = locator.GetService<IFactory>();
        controllerPlayer.Initialize(locator);


        CreateGate();
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

    private void CreateGate()
    {
        var gate = factory.CreateGate(new GateData(TypeGate.Summ, 10), new GateData(TypeGate.Mult, 2));
        gate.transform.position = new Vector3(0, 1.2f, 0);
    }

    private void InitializeLocator()
    {
        locator = new ServiceLocator();
        locator.Register<IMovePlayer>(new MovePlayer(controllerPlayer.moveObject.transform, controllerPlayer));
        locator.Register<ICreatorGate>(new CreatorGate(gateParams));
        locator.Register<IFactory>(new Factory(locator));
        locator.Register<IControllerInput>(controllerInput);
    }
}
