using System;
using contest.submission.contract;

namespace contest.submission
{
 
  [Serializable]
  public class Solution : IDnp1610Solution
  {
    public void Start(Steps steps)
    {
      NextStep(steps[0]);
    }

    public event Action<Step> NextStep;
  }
}
