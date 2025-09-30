using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModifierOperation { Invalid, Set, Add, Sub, Mult }
public enum ModifierStatEffect { Invalid, Health, Attack, Defense }
public class Modifier
{
    protected int modifierID;
    protected ModifierOperation operation;
}
