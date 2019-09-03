using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Foreign_Alphabet
{
    public partial class FrmAverages : Form
    {

        private Dictionary<Character, List<long>> characterTimes;
        private readonly long threashold = 6000;
        private int series;

        public FrmAverages()
        {
            InitializeComponent();
            characterTimes = new Dictionary<Character, List<long>>();
            series = 0;

        }

        private void FrmAverages_Load(object sender, EventArgs e)
        {
            Reset();
        }

        public void AddChart(Character key, long value)
        {
            //if(value < threashold)

            {
                if(!characterTimes.ContainsKey(key))
                {
                    characterTimes.Add(key, new List<long>());
                }
                characterTimes[key].Add(value);
            }
            UpdateChart();
        }

        private void UpdateChart()
        {
            chart1.Series[series].Points.Clear();
            foreach (KeyValuePair<Character, List<long>> character in characterTimes)
            {
                //FIXME
                //chart1.Series[series].Points.AddXY(character.Key.str, character.Value.Average());
            }

        }

        

        private void Button1_Click(object sender, EventArgs e)
        {
            series++;
            chart1.Series[series] = new Series();
        }

        private void Reset()
        {
            characterTimes = new Dictionary<Character, List<long>>();
            series = 0;
            UpdateChart();
        }
    }
}
