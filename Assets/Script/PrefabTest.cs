using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        //클릭한 지점의 월드 좌표
       Vector3 mousPostion =   Camera.main.ScreenToWorldPoint
            (new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        // 방향 벡터
        Vector3 dir = mousPostion - Camera.main.transform.position;
        dir = dir.normalized;
        

        // 좀더 간단하게 사용하는 방법
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        LayerMask.GetMask("Monster");
        int mask = (1 << 8); // 8번 레이어만 적용하고 싶다면
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 100.0f, mask);

    }
}
