using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    private readonly float G = 5f;
    private GameObject[] _celestials;

    private void Start()
    {
        _celestials = GameObject.FindGameObjectsWithTag("Celestial");
        InitialVelocity();
    }

    private void FixedUpdate()
    {
        Gravity();
    }

    void Gravity()
    {
        foreach (GameObject a in _celestials)
        {
            foreach (GameObject b in _celestials)
            {
                if (!a.Equals(b))
                {
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);
                    
                    a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized * (G * (m1 * m2) / (r * r)));
                }
            }
        }
    }

    void InitialVelocity()
    {
        foreach (GameObject a in _celestials)
        {
            if (a.name == "Sun")
                continue;
            
            foreach (GameObject b in _celestials)
            {
                if (!a.Equals(b))
                {
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);
                    a.transform.LookAt(b.transform);

                    a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt((G * m2) / r);
                }
            }
        }
    }
}
