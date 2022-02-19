using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Game.Scripts.Main.Interface
{
    public class PointsUI : MonoBehaviour, IPointsUI
    {
        [SerializeField] private Text textComponentPoints;
        [SerializeField] private Text textComponentPointsChange;
        private int normalSizeFont;
        private int maxSizeFont;
        private float timeScale = 0.35f;
        private bool isScale;
        private int oldPoints;
        
        public void UpdatePoints(float value)
        {
            var points = (int)value;
            textComponentPoints.text = points.ToString();
            normalSizeFont = textComponentPoints.fontSize;
            maxSizeFont = (int)(normalSizeFont * 1.4f);
            WriteChangePoints(points - oldPoints);
            oldPoints = points;
            Scale();
        }
        
        private void Start()
        {
            
        }

        private void Scale()
        {
            DOTween.Sequence()
                .AppendCallback(() => ScaleAnimation(maxSizeFont))
                .AppendInterval(timeScale / 2.0f)
                .AppendCallback(() => ScaleAnimation(normalSizeFont));
        }
        
        private void ChangeColor()
        {
            var time = 0.4f;
            DOTween.Sequence()
                .AppendCallback(() => ColorChangePoint(1, time))
                .AppendInterval(0.4f)
                .AppendCallback(() => ColorChangePoint(0, time));
        }

        private void ScaleAnimation(int value)
        {
            DOTween.To(() => textComponentPoints.fontSize, x => textComponentPoints.fontSize = x, value,  timeScale / 2.0f);
        }

        void WriteChangePoints(int points)
        {
            var text = points > 0 ? $"+{points}" : points.ToString();
            textComponentPointsChange.text = text;
            ChangeColor();
        }
        
        private void ColorChangePoint(int value, float time)
        {
            DOTween.To(() => textComponentPointsChange.color.a, ChangeColor, value,  time);
        }

        private void ChangeColor(float value)
        {
            var color = textComponentPointsChange.color;
            color.a = value;
            textComponentPointsChange.color = color;
        }
    }
}