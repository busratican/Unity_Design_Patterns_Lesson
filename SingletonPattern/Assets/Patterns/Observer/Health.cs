using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] float fullHealth = 100f;
    [SerializeField] float drainPerSecond = 2f;

    float currentHealth = 0;

    public event Action onHealthChange;

    private void Awake() {
        ResetHealth();
        StartCoroutine(HealthDrain());
    }
    
    private void OnEnable() {
        GetComponent<Level>().onLevelUpAction += ResetHealth;
    }

    private void OnDisable() {
        GetComponent<Level>().onLevelUpAction -= ResetHealth;
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public float GetFullHealth()
    {
        return fullHealth;
    }

    void ResetHealth()
    {
        currentHealth = fullHealth;
        if(onHealthChange != null)
        {
            onHealthChange();
        }
    }

    private IEnumerator HealthDrain()
    {
        while (currentHealth > 0)
        {
            if(onHealthChange != null)
            {
                onHealthChange();
            }
            currentHealth -= drainPerSecond;
            yield return new WaitForSeconds(1);
        }
    }

}