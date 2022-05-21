using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float fullHealth = 100f;
    [SerializeField] float drainPerSocend = 2f;
    float currentHealth;


    void Awake()
    {
        ResetHealth();
        StartCoroutine(HealthDrain());
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public void ResetHealth()
    {
        currentHealth = fullHealth;
    }

    private IEnumerator HealthDrain()
    {
        while(currentHealth > 0)
        {
            currentHealth -= drainPerSocend;
            yield return new WaitForSeconds(1f);
        }
    }
}
