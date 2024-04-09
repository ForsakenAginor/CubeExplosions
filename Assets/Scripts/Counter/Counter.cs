using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private float _step = 0.5f;
    private Coroutine _incrementCoroutine;
    private float _value = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_incrementCoroutine == null)
            {
                _incrementCoroutine = StartCoroutine(IncrementValue());
            }
            else
            {
                StopCoroutine(_incrementCoroutine);
                _incrementCoroutine = null;
            }
        }
    }

    private IEnumerator IncrementValue()
    {
        WaitForSeconds delay = new WaitForSeconds(_step);

        while (enabled)
        {
            _value++;
            _text.text = _value.ToString("0.0");
            yield return delay;
        }
    }
}
