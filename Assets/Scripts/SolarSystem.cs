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
        GravitationalForce();
    }

    void GravitationalForce()
    {
        foreach (GameObject affectedCelestial in _celestials)
        {
            if (affectedCelestial.name == "Sun")
                continue;
            
            foreach (GameObject effecterCelestial in _celestials)
            {
                if (!affectedCelestial.Equals(effecterCelestial))
                {
                    float affectedCelestialMass = affectedCelestial.GetComponent<Rigidbody>().mass;
                    float effecterCelestialMass = effecterCelestial.GetComponent<Rigidbody>().mass;
                    float distanceBetweenCelestials = Vector3.Distance(affectedCelestial.transform.position, effecterCelestial.transform.position);
                    
                    affectedCelestial.GetComponent<Rigidbody>().AddForce((effecterCelestial.transform.position - affectedCelestial.transform.position).normalized * (G * (affectedCelestialMass * effecterCelestialMass) / (distanceBetweenCelestials * distanceBetweenCelestials)));
                }
            }
        }
    }

    void InitialVelocity()
    {
        foreach (GameObject affectedCelestial in _celestials)
        {
            if (affectedCelestial.name == "Sun")
                continue;
            
            foreach (GameObject effecterCelestial in _celestials)
            {
                if (!affectedCelestial.Equals(effecterCelestial))
                {
                    float effecterCelestialMass = effecterCelestial.GetComponent<Rigidbody>().mass;
                    float distanceBetweenCelestials = Vector3.Distance(affectedCelestial.transform.position, effecterCelestial.transform.position);
                    affectedCelestial.transform.LookAt(effecterCelestial.transform);

                    affectedCelestial.GetComponent<Rigidbody>().velocity += affectedCelestial.transform.right * Mathf.Sqrt((G * effecterCelestialMass) / distanceBetweenCelestials);
                }
            }
        }
    }
}
