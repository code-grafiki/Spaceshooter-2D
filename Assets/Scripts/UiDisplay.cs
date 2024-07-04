using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiDisplay : MonoBehaviour
{
    [Header("health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scorekeepr;

    void Awake()
    {
        scorekeepr = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        healthSlider.value = playerHealth.GetHealth();
    }

    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = scorekeepr.GetScore().ToString();
    }
}
