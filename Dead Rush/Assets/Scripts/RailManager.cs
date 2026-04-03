using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tiles;   // 맵 프리팹 4개
    public Transform player;

    public float tileLength = 30f;
    public int tilesOnScreen = 6;

    private float spawnZ = 0f;
    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        // 시작 타일 깔기
        for (int i = 0; i < tilesOnScreen; i++)
        {
            SpawnTile(i == 0 ? 0 : Random.Range(0, tiles.Length));
        }
    }

    void Update()
    {
        // 플레이어가 앞으로 일정 거리 오면 새 타일 생성
        if (player.position.z - 60 > spawnZ - (tilesOnScreen * tileLength))
        {
            SpawnTile(Random.Range(0, tiles.Length));
            DeleteTile();
        }
    }

    void SpawnTile(int index)
    {
        GameObject go = Instantiate(
            tiles[index],
            Vector3.forward * spawnZ,
            Quaternion.identity
        );

        activeTiles.Add(go);
        spawnZ += tileLength;
    }

    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}