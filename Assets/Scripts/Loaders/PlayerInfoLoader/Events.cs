using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static partial class Events
{
    public static event Action<Hashtable> OnPlayerInfoLoadedAction;
    public static void DoOnPlayerInfoLoadedAction(Hashtable playerData) => OnPlayerInfoLoadedAction?.Invoke(playerData);

}
