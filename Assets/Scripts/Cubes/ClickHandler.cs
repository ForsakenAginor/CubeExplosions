using System.Linq;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hits = Physics.RaycastAll(ray).Where(o => o.collider.TryGetComponent(typeof(CubeDivider), out _)).ToList();

            if(hits.Count > 0)            
                hits.First().collider.GetComponent<CubeDivider>().Divide();            
        }
    }
}
