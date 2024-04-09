using System.Linq;
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    [SerializeField] float _explosionRadius = 50f;
    [SerializeField] float _explosionForce = 1000f;


    private void OnDestroy()
    {
        var cubes = Physics.OverlapSphere(transform.position, _explosionRadius).Where(o => o.TryGetComponent<CubeDivider>(out _)).Select(o => o.GetComponent<Rigidbody>());

        foreach (var cube in cubes)        
            cube.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);        
    }
}
