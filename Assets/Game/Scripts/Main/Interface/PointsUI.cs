using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Game.Scripts.Main.Interface
{
    public class PointsUI : MonoBehaviour, IPointsUI
    {
        [SerializeField] private Text textComponent;
        private float normalSizeFont;
        private float coefSizeFont = 1.2f;
        private float timeScale = 0.5f;
        private bool isScale;
        
        public void UpdatePoints(float value)
        {
            textComponent.text = ((int)value).ToString();
        }

        private void Update()
        {
            if (isScale)
            {
                   
            }
        }

        private void Start()
        {
            DOTween
        }
    }
}