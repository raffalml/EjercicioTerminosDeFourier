using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaExtra_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bttnGrafi_Click(object sender, EventArgs e)
        {
            if (cont > 0)
                Resetear(LimFourier);

            if (verificarTxTBox() == true)
            {
                if (radioButton1.Checked == true)
                {
                    cont++;
                    FullWaveRectifiedSineWave SenoPaArriba = new FullWaveRectifiedSineWave(Convert.ToDouble(txtTini.Text), Convert.ToDouble(txtTfin.Text), 0.01);
                    double[] tt = SenoPaArriba.CalcTiempo();
                    double[] yy = SenoPaArriba.CalcFx();
                    for (int i = 0; i < tt.Length; i++)
                    {
                        chart1.Series[0].Points.AddXY(tt[i], yy[i]);
                    }

                    FullWaveRectifiedSineWaveExtendido SenoPaArribaExtendido = new FullWaveRectifiedSineWaveExtendido(Convert.ToDouble(txtTini.Text), Convert.ToDouble(txtTfin.Text), Convert.ToDouble(txtInt.Text), Convert.ToDouble(txtAmp.Text), Convert.ToDouble(txtFrec.Text), Convert.ToDouble(txtFase.Text), Convert.ToDouble(txtOff.Text), Convert.ToInt32(txtnFourier.Text));
                    tt = SenoPaArribaExtendido.CalcTiempo();
                    yy = SenoPaArribaExtendido.CalcFx();
                    for (int i = 0; i < tt.Length; i++)
                    {
                        chart2.Series[0].Points.AddXY(tt[i], yy[i]);
                    }

                    LimFourier = Convert.ToInt32(txtnFourier.Text);
                    
                    for (int n = 0; n < SenoPaArribaExtendido.GetlimFourier(); n++)
                    {
                        tt = SenoPaArribaExtendido.CalcTiempo();
                        yy = SenoPaArribaExtendido.CalcElTerminoN(n);

                        chart3.Series.Add("");
                        chart3.Series[n + 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                        for (int i = 0; i < tt.Length; i++)
                        {
                            chart3.Series[n].Points.AddXY(tt[i], yy[i]);
                        }
                    }
                }
                if (radioButton2.Checked == true)
                {
                    cont++;
                    SawtoohWave Sierra = new SawtoohWave(Convert.ToDouble(txtTini.Text), Convert.ToDouble(txtTfin.Text), .01, 1, 1, 0, 0, 100);
                    double[] tt = Sierra.CalcTiempo();
                    double[] yy = Sierra.CalcFx();
                    for (int i = 0; i < tt.Length; i++)
                    {
                        chart1.Series[0].Points.AddXY(tt[i], yy[i]);
                    }

                    SawtoohWave SierraExtendida = new SawtoohWave(Convert.ToDouble(txtTini.Text), Convert.ToDouble(txtTfin.Text), Convert.ToDouble(txtInt.Text), Convert.ToDouble(txtAmp.Text), Convert.ToDouble(txtFrec.Text), Convert.ToDouble(txtFase.Text), Convert.ToDouble(txtOff.Text), Convert.ToInt32(txtnFourier.Text));
                    tt = SierraExtendida.CalcTiempo();
                    yy = SierraExtendida.CalcFx();
                    for (int i = 0; i < tt.Length; i++)
                    {
                        chart2.Series[0].Points.AddXY(tt[i], yy[i]);
                    }

                    LimFourier = Convert.ToInt32(txtnFourier.Text);

                    for (int n = 0; n < SierraExtendida.GetlimFourier(); n++)
                    {
                        tt = SierraExtendida.CalcTiempo();
                        yy = SierraExtendida.CalcElTerminoN(n);

                        chart3.Series.Add("");
                        chart3.Series[n + 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                        for (int i = 0; i < tt.Length; i++)
                        {
                            chart3.Series[n].Points.AddXY(tt[i], yy[i]);
                        }
                    }
                }
            }
            else
            {
                label13.Text = "Completa todo los cuadros!!";
            }
        }

        private void Resetear(int LimFourier)
        {
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            label13.Text = "";
            for (int i = 0; i < LimFourier; i++)
            {
                chart3.Series[i].Points.Clear();
            }
        }

        private bool verificarTxTBox()
        {
            if (txtAmp.Text == "" || txtFase.Text == "")
                return false;
            if (txtFrec.Text == "" || txtOff.Text == "")
                return false;
            if (txtTini.Text == "" || txtTfin.Text == "")
                return false;
            if (txtInt.Text == "" || txtnFourier.Text == "")
                return false;
            return true;
        }

        //Staticos
        private static int cont = 0;
        private static int LimFourier;
    }
}
