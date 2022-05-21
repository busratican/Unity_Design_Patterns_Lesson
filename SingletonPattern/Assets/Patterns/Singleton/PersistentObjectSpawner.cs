using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObjectSpawner : MonoBehaviour
{
    [Tooltip("This prefab will only be spawned once and persisted between " + "scenes.")]
    [SerializeField] GameObject persistendObjectPrefab = null;

    //PRIVATE_STATE
    static bool hasSpawned = false;

    private void Awake() 
    {
        if(hasSpawned) return;

        SpawnPersistentObjects();

        hasSpawned = true;
    }

    private void SpawnPersistentObjects()
    {
        GameObject persistentObject = Instantiate(persistendObjectPrefab);
        DontDestroyOnLoad(persistentObject);
    }
}
