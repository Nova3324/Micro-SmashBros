using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class ButtonIsSelected : MonoBehaviour
{
    [SerializeField] InputsControllerInMenus m_inputsController;
    [SerializeField] private GameObject m_playButton, m_settingsButton, m_creditsButton, m_quitButton;

    [SerializeField] private GameObject m_pointer;
    public bool m_isNavigate = false;

    private void Update()
    {
        if(m_isNavigate)
            ChangePointerPositon();
    }
    public void ChangePointerPositon()
    {
        RectTransform buttonSelected = EventSystem.current.currentSelectedGameObject.GetComponent<RectTransform>();
        m_pointer.GetComponent<RectTransform>().anchoredPosition = new Vector2(buttonSelected.anchoredPosition.x - 80, buttonSelected.anchoredPosition.y - buttonSelected.sizeDelta.y / 2);
    }
}
