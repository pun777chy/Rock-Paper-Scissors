using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static partial class Events 
{
    public static event Action<Hashtable> OnUpdateLoadedAction;
	public static void DoOnUpdateLoadedAction(Hashtable gameUpdateData) => OnUpdateLoadedAction?.Invoke(gameUpdateData);
}
