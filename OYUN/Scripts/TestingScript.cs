using UnityEngine;

public class TestingScript : MonoBehaviour
{
    int score;
    void Awake()
    {
        score=0;
        Debug.Log("Awake");
    }
    void Start()
    {
        score=0;
        Debug.Log("Start");
    }

    void Update()
    {
        Debug.Log("Update");
    }

    void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }

    void LateUpdate()
    {
        
    }

    void TestFunction()
    {
        Debug.Log("TestFunction");
    }



}
