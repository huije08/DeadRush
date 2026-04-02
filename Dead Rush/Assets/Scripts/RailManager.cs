using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailManager : MonoBehaviour
{
    public GameObject[] rails;   // 레일 프리팹들
    public float railLength = 30f;

    private float spawnZ = 0;
    private List<GameObject> activeRails = new List<GameObject>();

    public void SpawnRail()
    {
        int index = Random.Range(0, rails.Length);

        GameObject newRail = Instantiate(
            rails[index],
            Vector3.forward * spawnZ,
            Quaternion.identity
        );

        // 트리거 연결
        RailTrigger trigger = newRail.GetComponentInChildren<RailTrigger>();
        trigger.manager = this;

        activeRails.Add(newRail);
        spawnZ += railLength;

        // 오래된 레일 삭제
        if (activeRails.Count > 6)
        {
            Destroy(activeRails[0]);
            activeRails.RemoveAt(0);
        }
    }

    void Start()
    {
        // 시작 레일 미리 생성
        for (int i = 0; i < 6; i++)
        {
            SpawnRail();
        }
    }
}