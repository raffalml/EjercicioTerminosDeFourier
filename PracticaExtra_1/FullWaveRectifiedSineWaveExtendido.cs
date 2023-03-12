using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExtra_1
{
    class FullWaveRectifiedSineWaveExtendido : FullWaveRectifiedSineWave
    {
        private double amp;
        private double frec;
        private double fase;
        private double off;
        private int limFourier;

        public FullWaveRectifiedSineWaveExtendido(double tIni, double tFin, double tInterval, double amp, double frec, double fase, double off, int limFourier)
            :base(tIni, tFin, tInterval)
        {
            this.amp = amp;
            this.frec = frec;
            this.fase = fase;
            this.off = off;
            this.limFourier = limFourier;
        }

        public double GetAmp()
        {
            return amp;
        }

        public double GetFrec()
        {
            return frec;
        }

        public double GetFase()
        {
            return fase;
        }

        public double GetOff()
        {
            return off;
        }

        public int GetlimFourier()
        {
            return limFourier;
        }

        public override double[] CalcFx()
        {
            double[] tt = CalcTiempo();
            double[] yy = new double[tt.Length];

            double superoperación;
            for (int t = 0; t < tt.Length; t++)
            {
                double total = 0;
                for (int n = 1; n < limFourier; n++)
                {
                    superoperación = (-(4 * amp) / Math.PI) * (Math.Cos(n * (frec * Math.PI) * (tt[t] + fase)) / ((4 * n * n) - 1));
                    total += superoperación;
                }
                yy[t] = off + total + (2 * amp / Math.PI);
            }
            return yy;
        }

        public virtual double[] CalcElTerminoN(int n)
        {
            double[] tt = CalcTiempo();
            double[] yy = new double[tt.Length];

            if (n == 0)
                for (int t = 0; t < tt.Length; t++)
                    yy[t] = off + 2 * amp / Math.PI;
            else
                for (int t = 1; t < tt.Length; t++)
                    yy[t] = off + (-(4 * amp) / Math.PI) * (Math.Cos(n * (frec * Math.PI) * (tt[t] + fase)) / ((4 * n * n) - 1));
            return yy;
        }
    }
}
