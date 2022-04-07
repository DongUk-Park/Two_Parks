using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class GearController : MonoBehaviour
{   
    public void OnClick()
    {
        if(this.name == "D")
        {
            
            Public.DriveMode = 1;
            Public.ParkingMode = 0;
            Public.NeutralMode = 0;
            Public.ReverseMode = 0;
            Debug.Log("D 들어왔따");

        }
        if (this.name == "P")
        {
            Debug.Log("P 들어왔따");
            Public.DriveMode = 0;
            Public.ParkingMode = 1;
            Public.NeutralMode = 0;
            Public.ReverseMode = 0;
        }
        if (this.name == "N")
        {
            Public.DriveMode = 0;
            Public.ParkingMode = 0;
            Public.NeutralMode = 1;
            Public.ReverseMode = 0;
            Debug.Log("N 들어왔따");
        }
        if (this.name == "R")
        {
            Debug.Log("R 들어왔따");
            Public.DriveMode = 0;
            Public.ParkingMode = 0;
            Public.NeutralMode = 0;
            Public.ReverseMode = 1;
        }
    }


}
