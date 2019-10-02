using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int Creds;
    public int startCreds = 400;

    private

    void Start()
    {
        Creds = startCreds;
    }
}
