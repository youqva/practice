using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileGeneration : MonoBehaviour
{

    public GameObject[] tileprafabs;
    private float spawnPos = -25;
    private float tileLenght = 100;
    private int startTiles = 6;
    public Transform player;
    private List <GameObject> activeTiles = new List<GameObject>();


    void Start()
    {
        SpawnTile(0);

        for (int i = 0; i <= startTiles; i++)
        {
            SpawnTile(Random.Range(1, tileprafabs.Length));
        }

    }

    void Update()
    {
        if (player.position.z - 55 > spawnPos - (startTiles * tileLenght))
        {
            SpawnTile(Random.Range(1, tileprafabs.Length));
            DeleteTile();
        }
    }

    private void SpawnTile(int tileIndex) {

        GameObject nextTile = Instantiate(tileprafabs[tileIndex], transform.forward * (spawnPos + tileLenght / 2), transform.rotation);
        activeTiles.Add(nextTile);
        spawnPos += tileLenght;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
