using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
    [Header("general")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLife = 5f;
    [SerializeField] float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool enemyAI;
    [SerializeField] float firingRateVariance = 0;
    [SerializeField] float minimumFiringRate = 0.1f;
    
    [HideInInspector] public bool isFiring;
    Coroutine FiringCoroutine;

    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if(enemyAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && FiringCoroutine == null)
        {
        FiringCoroutine = StartCoroutine(FireContinously());
        }
        else if(!isFiring && FiringCoroutine != null)
        {
            StopCoroutine(FiringCoroutine);
            FiringCoroutine = null;
        }
    }

    IEnumerator FireContinously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab,
                                            transform.position,
                                            quaternion.identity);
            
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            
            if (rb != null)
            { 
                rb.velocity = transform.up * projectileSpeed; 
            }
            Destroy(instance, projectileLife);
            
            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);

            audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(baseFiringRate);
        }
    }
}
