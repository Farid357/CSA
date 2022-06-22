using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public sealed class PointStates
{
    private PointState[] _pointStates;
}

[Serializable]
public enum PointState
{ 
Locked,
Opene
}

