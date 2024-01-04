using UnityEngine;

public class ComponentController : MonoBehaviour
{
    [SerializeField] private Light light;
    private Vector2 _firstVector, _secondVector, _finalVector;
    
    void Start()
    {
        // Debug.Log(GetComponent<BoxCollider>().bounds.max);
        // Debug.Log(GetComponent<BoxCollider>().bounds.min);
        
        light.intensity = 3.0f;
        _firstVector = new Vector2(5.0f, 6.0f);
        _secondVector = new Vector2(3.0f, 6.0f);
        _finalVector = 2 * (_firstVector + _secondVector);
        Debug.Log(_finalVector);
    }
}
