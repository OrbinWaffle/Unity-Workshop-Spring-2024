using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Utils
{
   public static void ResetTriggers(Animator anim)
   {
      foreach (AnimatorControllerParameter parameter in anim.parameters)
      {
         if(parameter.type == AnimatorControllerParameterType.Trigger)
         {
            anim.ResetTrigger(parameter.name);
         }
      }
   }
}