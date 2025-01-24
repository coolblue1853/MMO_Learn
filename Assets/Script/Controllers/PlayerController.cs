using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    //bool _moveToDest = false;
    Vector3 _destPos;
    void Start()
    {
      //  Managers.Input.KeyAciton -= OnKeyboard; //이미 신청시 해제
        //Managers.Input.KeyAciton += OnKeyboard;
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;

       // Managers.Sound.Play("UnityChan/univ0001", Define.Sound.Bgm);

    }
    void OnRunEvent()
    {
        Debug.Log("뚜벅");
    }

    public enum PlayerState
    {
        Die,
        Moving,
        Idle,
        Jumping,
        Falling,
    }
    PlayerState _state = PlayerState.Idle;
    public void UpdateDie()
    {

    }
    public void UpdateMoving()
    {
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.0001f)
        {
           _state = PlayerState.Idle;
        }
        else
        {
            // 부들부들하는건 지나쳤을때가 있기 때문.
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
            transform.position += dir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
        }

        //애니메이션
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", _speed);

    }

    public void UpdateIdle()
    {
        //애니메이션
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", 0);
    }


    void Update()
    {
        switch (_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
        }
    }
    void OnMouseClicked(Define.MousEvent evt)
    {
        if (_state == PlayerState.Die) return;
       // if (evt != Define.MousEvent.Click) return; // 클릭이 아니면 스킵

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        LayerMask mask = LayerMask.GetMask("Wall");

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100.0f, mask))
        {
           _destPos =  hit.point;
            _state = PlayerState.Moving;
        }

    }
    void OnKeyboard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.1f);
            transform.position += (Vector3.forward * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.1f);
            transform.position += (Vector3.back * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.1f);
            transform.position += (Vector3.left * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.1f);
            transform.position += (Vector3.right * Time.deltaTime * _speed);
        }
        //_moveToDest = false;
    }
}
