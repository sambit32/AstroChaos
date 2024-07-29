using UnityEngine;

[CreateAssetMenu]
public class IntegerVariable : ScriptableObject
{
    public int value;

    public void Reset()
    {
        value = 0;
    }
}
