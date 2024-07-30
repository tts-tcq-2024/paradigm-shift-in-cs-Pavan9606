using System;

namespace paradigm_shift_csharp
{
  public class ParameterMonitoring
  {
    private string _name;
    private float _value;
    private float _min;
    private float _max;
    private float _tolerance;
    private bool _warning ;
    private readonly Dictionary<(float, float), string> _stateList;

    public ParameterMonitoring(string name, float value, float min, float max, float tolerance)
    {
        _name = name;
        _value = value;
        _min = min;
        _max = max;
        _tolerance = tolerance;
        _stateList = new Dictionary<(float, float), string>
        {
            {(-100, min), $"LOW_{name}_BREACH"},
            {(min + 0.01f, min + tolerance), $"LOW_{name}_WARNING"},
            {(min + tolerance + 0.01f, max - tolerance), $"NORMAL_{name}_STATE"},
            {(max - tolerance + 0.01f, max), $"HIGH_{name}_WARNING"},
            {(max + 0.01f, 100), $"HIGH_{name}_BREACH"}
        };
    }
    public bool IsOk()
    {
        return ParameterUtils.IsInRange(_value, _min + _tolerance + 0.01f, _max - _tolerance);
    }

    public string GetStateStatus()
    {
        foreach (var temp in _stateList)
        {
            if (ParameterUtils.IsInRange(_value, temp.Key.Item1, temp.Key.Item2))
            {
                return temp.Value;
            }
        }
        return "INVALID";
    }

    public void SetValue(float input)
    {
        _value = input;
    }

    //public void ConfigureWarning(bool input)
    //{
    //    _warning = input;
    //}

    //public bool IsLow()
    //{
    //    return _warning && ParameterUtils.IsInRange(_value, _min + 0.01f, _min + _tolerance);
    //}

    //public bool IsHigh()
    //{
    //    return _warning && ParameterUtils.IsInRange(_value, _max - _tolerance + 0.01f, _max);
    //}
}
}
