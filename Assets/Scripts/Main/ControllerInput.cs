using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    public Vector2 PositionMouse { get; private set; }

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
        RaycastHit Po;
        if (Physics.Raycast(ray, out Po))
            PositionMouse = new Vector2(Po.point.x,Po.point.y);
    }
}
