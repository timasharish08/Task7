using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    [SerializeField] private float _lerpDuration;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        _image.fillAmount = 1;
    }

    public void ToFill()
    {
        StartCoroutine(Filling(1, null));
    }

    public void ToEmpty()
    {
        StartCoroutine(Filling(0, Destroy));
    }

    private IEnumerator Filling(float endValue, UnityAction<GameObject> lerpingEnd)
    {
        float elapsed = 0;
        float startValue = _image.fillAmount;

        while (elapsed < _lerpDuration)
        {
            _image.fillAmount = Mathf.Lerp(startValue, endValue, elapsed / _lerpDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        _image.fillAmount = endValue;
        lerpingEnd?.Invoke(gameObject);
    }
}
