using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PathPoints 
{
   public Vector3 startPosition;
   public Vector3 finalPosition;

   public PathPoints(Vector3 start, Vector3 end)
   {
      startPosition = start;
      finalPosition = end;
   }
}
