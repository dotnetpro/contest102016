using contest.submission.contract;
using System.Text;

namespace contest.host
{
  public static class StepConverter
  {
    public static Step FromString(this Step step, string s)
    {
      foreach (var c in s)
      {
        if (c == '1') step.Add(true); else step.Add(false);
      }
      return step;
    }

    public static string ToString(this Step step, string s = null)
    {
      // Parameter string s ist dummy, damit sich step.ToString() als Erweiterungsmethode bauen lässt.
      StringBuilder sb = new StringBuilder();

      foreach (var item in step)
      {
        sb.Append(item == true ? "1" : "0");
      }
      return sb.ToString();
    }
  }
}
