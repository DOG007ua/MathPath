using System.Collections;
using System.Collections.Generic;using Main.Interface;
using UnityEngine;

public class ControllerInput :  MonoBehaviour, IControllerInput
{
    public Vector3 PositionMouse { get; private set; }
    private float minX = -7;
    private float maxX = -2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetterPositionMouse();
    }

    private void SetterPositionMouse()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        var mask = 1 << 9;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            PositionMouse = hit.point;
            if (PositionMouse.z > maxX) PositionMouse = new Vector3(PositionMouse.x, PositionMouse.y, maxX);
            if (PositionMouse.z < minX) PositionMouse = new Vector3(PositionMouse.x, PositionMouse.y, minX);
        }
    }
}
