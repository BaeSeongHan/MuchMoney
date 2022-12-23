using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    public static HPbar Instance;

    public Image currentHealthGlobe;
    public float hitPoint = 100f;
    public float maxHitPoint = 100f;
    public Text healthText;


    void Awake()
    {
        Instance = this;
    }

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
