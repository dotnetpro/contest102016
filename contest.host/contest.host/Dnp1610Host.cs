using contest.submission.contract;
using contestrunner.contract.host;
using System;
using System.IO;
using System.Text;

namespace contest.host
{

  public class Dnp1610Host : IHost
  {
    
    public void Prüfen(object beitrag, string wettbewerbspfad, string beitragsverzeichnis)
    {
      var sut = (IDnp1610Solution)beitrag;

      DateTime starttime = DateTime.Now;

      sut.NextStep += step => Status(new Prüfungsstatus() { Statusmeldung = "Nächster Schritt: " + step.ToString(null) });

      var anfang = new Prüfungsanfang { Wettbewerb = Path.GetFileName(wettbewerbspfad), Beitrag = Path.GetFileName(beitragsverzeichnis) };
      Anfang(anfang);
      Steps steps = new Steps();

      steps.Add(new Step().FromString("10101010"));
      steps.Add(new Step().FromString("01010101"));
      sut.Start(steps);
      
      Ende(new Prüfungsende(){ Dauer = DateTime.Now.Subtract(starttime) });

    }

    public event Action<Prüfungsanfang> Anfang;
    public event Action<Prüfungsstatus> Status;
    public event Action<Prüfungsende> Ende;
    public event Action<Prüfungsfehler> Fehler;
  }
}
