using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Game field Scaler
[ExecuteInEditMode]
public class FieldScaler : MonoBehaviour
{
    public int fieldLengthInMeters;
    public int fieldWidth;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate((fieldLengthInMeters / 10 - this.transform.localScale.z) * Vector3.forward * 5);
        this.transform.Translate(new Vector3(((float)fieldWidth / 10 - this.transform.localScale.x) * 5, 0, (fieldLengthInMeters / 10 - this.transform.localScale.z) * 5));
        this.transform.localScale += new Vector3((float)fieldWidth / 10 - transform.localScale.x, 0, (fieldLengthInMeters / 10 - this.transform.localScale.z));
        
    }
}
