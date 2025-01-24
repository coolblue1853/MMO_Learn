using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager 
{
    class Pool
    {
        public GameObject Original { get; private set; }
        public Transform Root { get; set; }

        Stack<Poolable> _poolStack = new Stack<Poolable>();
    }

    //풀링 오브젝트들의 부모
    Transform _root;
    public void Init()
    {
        if(_root == null)
        {
            _root = new GameObject { name = "@Pool_Root" }.transform;
            Object.DontDestroyOnLoad(_root);
        }
    }

    public void Push(Poolable poolable)
    {

    }
    public Poolable Pop(GameObject original, Transform parent = null)
    {
        return null;
    }

    public GameObject GetOriginal(string name)
    {
        return null;
    }
}
