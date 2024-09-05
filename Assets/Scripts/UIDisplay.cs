using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health") ]
    [SerializeField] Slider helthSlider;
    [SerializeField] Health playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    void Awake() {
    scoreKeeper=FindObjectOfType<ScoreKeeper>();    
    }
    
    void Start()
    {
        helthSlider.maxValue=playerHealth.getHealth();
    }

   
    void Update()
    {
        helthSlider.value=playerHealth.getHealth();
        scoreText.text=scoreKeeper.getScore().ToString("000000");
    }
}
