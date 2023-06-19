using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNewGame : MonoBehaviour
{
    [SerializeField] public int crateNum = 1000;
    void Start()
    {
        
    }
 
    void Update()
    {
        for (int i = 0; i < 1000; i++)
        {
            new GameObject();
        }
    }
}
