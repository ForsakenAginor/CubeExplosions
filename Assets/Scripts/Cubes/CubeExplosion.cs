using System.Linq;
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    [SerializeField] float _explosionRadius = 50f;
    [SerializeField] float _explosionForce = 1000f


    private void OnDestroy()
    {
        var cubes = Physics.OverlapSphere(transform.position, _explosionRadius).Where(o => o.TryGetComponent<CubeDivider>(out _));

        foreach (var cube in cubes)        
            cube.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);        
    }
}
