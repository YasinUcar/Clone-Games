using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassCodes : MonoBehaviour
{
    public GameObject model; //ana model
    public GameObject destructables; //kırılabili
    public float breakForce;
    private Vector3[] firstLocalPoses;
    private bool destructed = false;
    void Start()
    {

        firstLocalPoses = new Vector3[destructables.transform.childCount];
        for (int i = 0; i < firstLocalPoses.Length; i++)
        {
            firstLocalPoses[i] = destructables.transform.GetChild(i).localPosition;
        }
      
    }

    // Update is called once per frame
    void Update()
    {

        if (destructed)
        {
            return;
        }
        destructed = true;
        model.SetActive(false);
        destructables.SetActive(true);
        foreach (Rigidbody rb in destructables.GetComponentsInChildren<Rigidbody>())
        {
            Vector3 force = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f) * breakForce);
        }
        StartCoroutine(ResetDestructables(1f));


    }
    IEnumerator ResetDestructables(float delay)
    {
        yield return new WaitForSeconds(delay);
        model.SetActive(true);
        destructables.SetActive(false);
        for (int i = 0; i < firstLocalPoses.Length; i++)
        {
            destructables.transform.GetChild(i).localPosition = firstLocalPoses[i];
            destructables.transform.GetChild(i).GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        destructed = false;
    }
}
