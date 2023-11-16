using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FadeCredits : MonoBehaviour
{
    [SerializeField] private List<CanvasGroup> m_objectsToFade = new List<CanvasGroup>();
    [SerializeField] private float m_FadeInDuration, m_fadeOutDuration, m_AttendanceTime, m_WaitBeforeStart;

    private void Start()
    {
        StartCoroutine(StartFadeSequence());
    }

    private IEnumerator StartFadeSequence()
    {
        yield return new WaitForSeconds(m_WaitBeforeStart); 

        StartCoroutine(FadeSequence());
    }
    private IEnumerator FadeSequence()
    {
        foreach (CanvasGroup canvasGroup in m_objectsToFade)
        {
            yield return StartCoroutine(FadeCanvasGroup(canvasGroup, 1f, m_FadeInDuration)); 

            yield return new WaitForSeconds(m_AttendanceTime); 

            if(canvasGroup != m_objectsToFade[m_objectsToFade.Count - 1])
                yield return StartCoroutine(FadeCanvasGroup(canvasGroup, 0f, m_fadeOutDuration)); 
        }
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float targetAlpha, float duration)
    {
        float startAlpha = canvasGroup.alpha;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;

        //Setactive false all objects of the list
        if (targetAlpha == 0f)
        {
            if (canvasGroup != m_objectsToFade[m_objectsToFade.Count - 1])
            {
                canvasGroup.gameObject.SetActive(false);
            }
        }
    }
}