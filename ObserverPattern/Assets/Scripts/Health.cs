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

    private void OnEnable()
    {
        GetComponent<Level>().onLevelUpAction += ResetHealth;
    }

    private void OnDisable() 
    {
        GetComponent<Level>().onLevelUpAction -= ResetHealth;
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    void ResetHealth()
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
