using UnityEngine;

public class SkillValue
{

    private double _value;
    private ATTACK_TYPE _type;
    private ATTACK_ELEMENT _element;

    public SkillValue()
    {
        _value = 0;
        _type = ATTACK_TYPE.NONE;
        _element = ATTACK_ELEMENT.NONE;
        
    }

    public SkillValue(int value, ATTACK_ELEMENT element)
    {
        _value = value;
        _type = ATTACK_TYPE.BASIC;
        _element = element;
    }

    public SkillValue(int value, ATTACK_ELEMENT element , ATTACK_TYPE type)
    {
        _value = value;
        _type = type;
        _element = element;
    }

    public double Value()
    {
        return _value;
    }

    public ATTACK_TYPE GetAttType()
    {
        return _type;
    }

    public ATTACK_ELEMENT GetElement()
    {
        return _element;
    }
}
