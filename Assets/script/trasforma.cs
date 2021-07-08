using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class trasforma 
{
public static void vai (this Transform _trasforma){
    _trasforma.Rotate(60 * Time.deltaTime,0,0);

    }
    
}
