using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class properties
{
    public string ID;
    public float PREC_PLANI;
    public float PREC_ALTI;
    public string ORIGIN_BAT;
    public float HAUTEUR;
    public float Z_MIN;
    public float Z_MAX;
    public geometry geometry;

    public override string ToString()
    {
        return "ID " + ID.ToString() + " PREC_PLANI " + PREC_PLANI.ToString() + " PREC_ALTI " + PREC_ALTI.ToString() + geometry.ToString();
    }
}
