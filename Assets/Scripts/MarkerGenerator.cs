using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerGenerator : MonoBehaviour
{
    public GameObject MarkerPrefab = null;
    [Min(1)] public int Divisions = 12;

    private List<Vector3> positions = null;

    private void Start()
    {
        StartCoroutine(Generate());
    }

    private GameObject Spawn(Quaternion rot)
    {
        return Instantiate(MarkerPrefab, this.transform.position, rot, this.transform);
    }

    private IEnumerator Generate()
    {
        float angleDiv = 360 / Divisions;
        for (int i = 0; i <= Divisions - 1; ++i)
        {
            Spawn(Quaternion.Euler(new Vector3(0f, 0f, angleDiv * i)));
            yield return new WaitForSeconds(0.2f);
        }
        yield return null;
    }
}
