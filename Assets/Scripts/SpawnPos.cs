using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPos : MonoBehaviour
{
    private RaycastHit hit;
    private LayerMask layerMask;
    void Start()
    {
        layerMask = 1 << 3;     // ground 레이어 마스크(3번) 만 검사
    }
    public Vector3 GetSpawnPos()
    {
        Vector3 originPos = transform.position;

        if (Physics.Raycast(transform.position, (transform.up) * -1, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("Pos : " + hit.point);
            transform.position = originPos;
            return hit.point;
        }

        return Vector3.zero;
    }
}
