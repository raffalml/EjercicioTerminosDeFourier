using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExtra_1
{
    class FullWaveRectifiedSineWave
    {
        private double tIni;
        private double tFin;
        private double tInterval;

        public FullWaveRectifiedSineWave(double tIni, double tFin, double tInterval)
        {
            this.tIni = tIni;
            this.tFin = tFin;
            this.tInterval = tInterval;
        }

        public double[] CalcTiempo()
        {
            int noElementos = (int)(((tFin - tIni) / tInterval) + 1);
            double[] tt = new double[noElementos];

            double t = tIni;
            for (int i = 0; i < tt.Length; i++)
            {
                tt[i] = t;
                t += tInterval;
            }
            return tt;
        }
        
        public virtual double[] CalcFx()
        {
            double[] tt = CalcTiempo();
            double[] yy = new double[tt.Length];
            int A = 1;
            double w0 = Math.PI;

            double superoperación;
            for (int t = 0; t < tt.Length; t++)
            {
                double total = 0;
                for (int n = 1; n < 100; n++)
                {
                    superoperación = (-(4 * A) / Math.PI) * (Math.Cos(n * w0 * tt[t]) / ((4 * n * n) - 1));
                    total += superoperación;
                }
                yy[t] = total + (2 * A / Math.PI);
            }
            return yy;
        }
    }
}
