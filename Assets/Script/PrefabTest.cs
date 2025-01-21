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
        //Ŭ���� ������ ���� ��ǥ
       Vector3 mousPostion =   Camera.main.ScreenToWorldPoint
            (new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        // ���� ����
        Vector3 dir = mousPostion - Camera.main.transform.position;
        dir = dir.normalized;
        

        // ���� �����ϰ� ����ϴ� ���
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        LayerMask.GetMask("Monster");
        int mask = (1 << 8); // 8�� ���̾ �����ϰ� �ʹٸ�
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 100.0f, mask);

    }
}
