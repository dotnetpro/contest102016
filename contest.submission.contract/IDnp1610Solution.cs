using System;
using System.Collections.ObjectModel;

namespace contest.submission.contract
{
  public class Step : Collection<bool>	{ }

  public class Steps : Collection<Step> { };

  public interface IDnp1610Solution
  {
    void Start(Steps steps);

    event Action<Step> NextStep;
  }
}
