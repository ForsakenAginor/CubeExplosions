using UnityEngine;

public class CubeDivider : MonoBehaviour
{
    [SerializeField] private CubeDivider _cubePrefab;

    private float _divideChance = 1f;
    private Vector3 _currentScale;
    private float _multiplier = 0.5f;
    private int _subCubeQuantity = 2;

    private void Awake()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
        _currentScale = transform.localScale;
    }

    public void Init(float divideChance, Vector3 currentScale)
    {
        _divideChance = divideChance;
        _currentScale = currentScale;
        transform.localScale = _currentScale;
    }

    public void Destroy()
    {
        if (_divideChance >= Random.value)
            Divide();

        Destroy(gameObject);
    }

    private void Divide()
    {
        for (int i = 0; i < _subCubeQuantity; i++)
            Instantiate(_cubePrefab, transform.position, Quaternion.identity).
                Init(_divideChance * _multiplier, _currentScale * _multiplier);
    }
}
