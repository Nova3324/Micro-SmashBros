using UnityEngine;

public class AirArea : MonoBehaviour
{
    private Camera m_cam;
    private float m_sizeMultiplicator = 1.5f;

    /*----------------------------------------------------------*/

    private void Start()
    {
        m_cam = GetComponent<Camera>();
    }

    /*----------------------------------------------------------*/

    public bool IsInAirZone(Vector3 position)
    {
        if (GetAirZone().Contains(position))
        {
            return true;
        }

        return false;
    }

    /*----------------------------------------------------------*/

    private Rect GetAirZone()
    {
        //if sizeMultiplicator == 1 -> Air zone = camOrthoSize
        //world rect cam size : x = y * (16/9), y = m_cam.orthographicSize * 2

        Rect airRectZone = new();
        float height = m_cam.orthographicSize * 2f * m_sizeMultiplicator;
        float width = height * (16f / 9f);
        float x = m_cam.transform.position.x - width / 2f;
        float y = m_cam.transform.position.y - height / 2f;
        airRectZone.Set(x, y, width, height);

        return airRectZone;
    }
}
