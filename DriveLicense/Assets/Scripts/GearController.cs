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
            Debug.Log("D ���Ե�");

        }
        if (this.name == "P")
        {
            Debug.Log("P ���Ե�");
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
            Debug.Log("N ���Ե�");
        }
        if (this.name == "R")
        {
            Debug.Log("R ���Ե�");
            Public.DriveMode = 0;
            Public.ParkingMode = 0;
            Public.NeutralMode = 0;
            Public.ReverseMode = 1;
        }
    }


}
