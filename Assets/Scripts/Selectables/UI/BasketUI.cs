using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Selectables.UI
{
    public class BasketUI : MonoBehaviour
    {
        [SerializeField]
        private BasketEntity basketEntity;
        
        [SerializeField] 
        private Canvas canvas;
        [SerializeField] 
        private TMP_Text counterText;
        [SerializeField] 
        private Button playButton;
        
        private void OnEnable()
        {
            basketEntity.OnScoreChanged += UpdateScore;
            basketEntity.OnSelectionChanged += ShowCanvas;
            
            playButton.onClick.AddListener(basketEntity.LaunchBall);
        }

        private void OnDisable()
        {
            basketEntity.OnScoreChanged -= UpdateScore;
            basketEntity.OnSelectionChanged -= ShowCanvas;
            
            playButton.onClick.RemoveListener(basketEntity.LaunchBall);
        }

        private void UpdateScore(int score)
        {
            counterText.text = score.ToString();
        }

        private void ShowCanvas(bool canShow)
        {
            canvas.enabled = canShow;
        }
    }
}