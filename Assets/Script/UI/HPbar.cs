using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    public Image currentHealthGlobe;
    public float hitPoint;
    public float maxHitPoint;

    void Start()
    {
        UpdateGraphics();
    }

    void Update()
    {
        UpdateGraphics();
    }
    

    private void UpdateHealthGlobe()
    {
        float ratio = hitPoint / maxHitPoint;
        currentHealthGlobe.rectTransform.localPosition = new Vector3(0, currentHealthGlobe.rectTransform.rect.height * ratio - currentHealthGlobe.rectTransform.rect.height, 0);
    }


    private void UpdateGraphics()
    {
        UpdateHealthGlobe();
    }
}
