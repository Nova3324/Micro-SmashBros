using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] ButtonIsSelected m_buttonIsSelected;
    public void Navigate()
    {
        m_buttonIsSelected.ChangePointerPositon();
    }
}
