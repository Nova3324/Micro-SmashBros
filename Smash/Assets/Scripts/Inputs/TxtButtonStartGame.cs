using TMPro;
using UnityEngine;

public class TxtButtonStartGame : MonoBehaviour
{
    public static TxtButtonStartGame instance;

    private TMP_Text m_text;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Two Btn start game");
            Destroy(gameObject);
            return;
        }

        m_text = GetComponent<TMP_Text>();
    }

    private void FixedUpdate()
    {
        float alpha = Mathf.PingPong(Time.time * 1.2f, 1f);
        m_text.color = new Color(m_text.color.r, m_text.color.g, m_text.color.b, alpha);
    }

    public void OnePlayerConnected()
    {
        Destroy(transform.parent.gameObject);
    }
}
