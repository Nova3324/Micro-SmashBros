using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] List<GameObject> m_audioSource;

    public static AudioManager Instance;

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
        
    }
    
    void Update()
    {
        
    }

    public void PlayLogoAudio()
    {
        m_audioSource.Where(obj => obj.name == "Logo").SingleOrDefault().GetComponent<AudioSource>().Play();
    }

    public void PressedButton()
    {
        m_audioSource.Where(obj => obj.name == "ButtonPressed").SingleOrDefault().GetComponent<AudioSource>().Play();
    }
}
