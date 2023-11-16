using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance; 
    
    public List<GameObject> m_hidedObject;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("This manager script exist two time");
            Destroy(this);
            return;
        }
    }
    void Start()
    {
        for(int i = 0;  i < m_hidedObject.Count; i++) 
        {
            m_hidedObject[i].SetActive(false);
        }   

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
