using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public List<PlayerController> m_playerControllers { get; set; } = new();

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
        //get all player controllers
        for (int i = 0; i < transform.childCount; i++)
        {
            PlayerController controller = transform.GetChild(i).GetComponentInChildren<PlayerController>();
            if (controller != null)
            {
                m_playerControllers.Add(controller);
            }
        }
    }
}
