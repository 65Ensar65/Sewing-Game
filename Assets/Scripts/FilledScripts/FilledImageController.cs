using UnityEngine;
using UnityEngine.UI;

public class FilledImageController : Base
{
    public Image FilledImage;
    public float FillDuration = 10.0f;

    private float TargetFillAmount = 1.0f;
    private float CurrentFillAmount = 0.0f;
    public bool IsFilling = true;

    void Start()
    {
        FilledImage.fillAmount = 0.0f;
    }

    void Update()
    {
        if (IsFilling)
        {
            CurrentFillAmount += Time.deltaTime / FillDuration;
            FilledImage.fillAmount = Mathf.Clamp01(CurrentFillAmount);

            if (FilledImage.fillAmount >= TargetFillAmount)
            {
                IsFilling = false;
                FilledImage.fillAmount = 0.0f;
            }
        }
    }

    public void StartFilling()
    {
        CurrentFillAmount = 0.0f;
        IsFilling = true;
    }
}
