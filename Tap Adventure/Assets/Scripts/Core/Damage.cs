using UnityEngine;

public class SkillValue
{

    private int _value;
    private bool _isCritical;

    public SkillValue()
    {
        _value = 0;
        _isCritical = false;
    }

    public SkillValue(int value)
    {
        _value = value;
        _isCritical = false;
    }

    public SkillValue(int value, bool isCritical)
    {
        _value = value;
        _isCritical = isCritical;
        Debug.Log("IsCritical = " + isCritical);
    }

    public int Value()
    {
        return _value;
    }

    public bool IsCritical()
    {
        return _isCritical;
    }
}
