using System.Collections.Generic;
using UnityEngine;

public class DrawHearts : MonoBehaviour
{
    [SerializeField] private int m_nbHearts = 3;
    private List<GameObject> m_fullHeartImg = new List<GameObject>();
    private List<GameObject> m_heartBrokenImg = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            if (i < m_nbHearts)
            {
                m_fullHeartImg.Add(child);
            }
            else
            {
                m_heartBrokenImg.Add(child);
            }
        }
    }

    public void ChangeHeartsState(int life)
    {
        //for full hearts
        for(int i = 0; i < m_fullHeartImg.Count ;i++)
        {
            if (i < life)
            {
                m_fullHeartImg[i].SetActive(true);
            }
            else
            {
                m_fullHeartImg[i].SetActive(false);
            }
        }

        //for broken hearts
        for (int i = 0; i < m_heartBrokenImg.Count; i++)
        {
            if (i >= life)
            {
                m_heartBrokenImg[i].SetActive(true);
            }
            else
            {
                m_heartBrokenImg[i].SetActive(false);
            }
        }
    }
}
