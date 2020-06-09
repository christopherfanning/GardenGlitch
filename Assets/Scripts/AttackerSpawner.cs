using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] bool spawning = true;
    [SerializeField] Attacker[] attackerPrefab;
    float timeBetweenSpawns;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawning)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }

    }

    private void SpawnAttacker()
    {
        // random range from zero to length of Attacker array
        var index = Random.Range(0, attackerPrefab.Length);
        Spawn(index);
    }

    private void Spawn(int index)
    {
        Attacker newAttacker = Instantiate
                 (attackerPrefab[index], transform.position, transform.rotation)
                  as Attacker;

        newAttacker.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
