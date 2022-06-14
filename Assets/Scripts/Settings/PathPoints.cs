using UnityEngine;

namespace com.GhostHunter.Settings
{
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
}
