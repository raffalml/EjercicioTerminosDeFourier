using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExtra_1
{
    class SawtoohWave : FullWaveRectifiedSineWaveExtendido
    {
        public SawtoohWave(double tIni, double tFin, double tInterval, double amp, double frec, double fase, double off, int limFourier)
            :base(tIni, tFin, tInterval, amp, frec, fase, off, limFourier)
        {

        }

        public override double[] CalcFx()
        {
            double[] tt = CalcTiempo();
            double[] yy = new double[tt.Length];

            double superoperación;
            for (int t = 0; t < tt.Length; t++)
            {
                double total = 0;
                for (int n = 1; n < GetlimFourier(); n++)
                {
                    superoperación = (GetAmp()/Math.PI) * (-(Math.Sin(n * GetFrec() * Math.PI * (tt[t] + GetFase()))) / (n));
                    total += superoperación;
                }
                yy[t] = GetOff() + (total + (GetAmp() / 2));
            }
            return yy;
        }

        public override double[] CalcElTerminoN(int n)
        {
            double[] tt = CalcTiempo();
            double[] yy = new double[tt.Length];

            if (n == 0)
                for (int t = 0; t < tt.Length; t++)
                    yy[t] = GetOff() + (GetAmp() / 2);
            else
                for (int t = 1; t < tt.Length; t++)
                    yy[t] = GetOff() + (GetAmp() / Math.PI) * (-(Math.Sin(n * GetFrec() * Math.PI * (tt[t] + GetFase()))) / (n));
            return yy;
        }
    }
}
