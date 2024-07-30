using System;

namespace paradigm_shift_csharp
{
  public static class ParameterUtils
  {
    public static bool IsInRange(float actual, float min, float max)
    {
        return actual >= min && actual <= max;
    }
}

 
}
