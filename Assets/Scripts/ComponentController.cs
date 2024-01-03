using UnityEngine;

public class ComponentController : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    void Start()
    {
        cube.GetComponent<Light>().intensity = cube.GetComponent<Variable>().intensityValue;
        cube.GetComponent<Variable>().ShowTheIntensityValue();
    }
}
