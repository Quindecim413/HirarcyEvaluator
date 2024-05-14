using System.Windows.Forms;
using System;
using System.Collections.Generic;
using Accord.Math.Decompositions;
using System.Linq;
using System.Drawing;
using Newtonsoft.Json;

namespace HirarcyEvaluator
{
    public partial class GridWithSelectionControl : UserControl
    {
        private GridWithSelectionControl() { }
        public readonly string[] Labels;
        Dictionary<string, Tuple<int, bool>> Mapping;
        public GridWithSelectionControl(string[] labels)
        {
            InitializeComponent();
            Labels = labels;
            Mapping = new Dictionary<string, Tuple<int, bool>>();
            Mapping["1/9"] = Tuple.Create(9, true);
            Mapping["1/8"] = Tuple.Create(8, true);
            Mapping["1/7"] = Tuple.Create(7, true);
            Mapping["1/6"] = Tuple.Create(6, true);
            Mapping["1/5"] = Tuple.Create(5, true);
            Mapping["1/4"] = Tuple.Create(4, true);
            Mapping["1/3"] = Tuple.Create(3, true);
            Mapping["1/2"] = Tuple.Create(2, true);
            Mapping["1"] = Tuple.Create(1, false);
            Mapping["2"] = Tuple.Create(2, false);
            Mapping["3"] = Tuple.Create(3, false);
            Mapping["4"] = Tuple.Create(4, false);
            Mapping["5"] = Tuple.Create(5, false);
            Mapping["6"] = Tuple.Create(6, false);
            Mapping["7"] = Tuple.Create(7, false);
            Mapping["8"] = Tuple.Create(8, false);
            Mapping["9"] = Tuple.Create(9, false);


            // Настройка заголовков таблицы
            dataGridView1.ColumnCount = Labels.Length;
            dataGridView1.RowCount = Labels.Length;


            for (int i = 0; i < Labels.Length; i++)
            {
                var col = dataGridView1.Columns[i];
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.ToolTipText = Labels[i];
                col.HeaderText = Labels[i];
                var row = dataGridView1.Rows[i];
                row.HeaderCell.Value = Labels[i];
                row.HeaderCell.ToolTipText = Labels[i];
            }

            // Настройка контента таблицы
            for (int i = 0; i < Labels.Length; i++)
            {
                for (int j = 0; j < Labels.Length; j++)
                {
                    dataGridView1[j, i].ToolTipText = "Важность \"" + Labels[i] + "\" к \"" + Labels[j] + "\"";
                    dataGridView1[j, i].Value = 1;
                }

                dataGridView1[i, i].Style.BackColor = Color.Red;
                dataGridView1[i, i].Style.ForeColor = Color.White;
            }

            // Слушатели изменения выбора
            var buttons = new RadioButton[]
            {
                radioButton1,
                radioButton2,
                radioButton3,
                radioButton4,
                radioButton5,
                radioButton6,
                radioButton7,
                radioButton8,
                radioButton9,
                radioButton10,
                radioButton11,
                radioButton12,
                radioButton13,
                radioButton14,
                radioButton15,
                radioButton16,
                radioButton17,
            };



            foreach (var button in buttons)
            {
                button.CheckedChanged += (o, ev) =>
                {
                    var b = (RadioButton)o;

                    if (!b.Checked)
                        return;

                    if (selectedCol != selectedRow)
                    {
                        foreach (var btn in buttons)
                        {
                            if (!b.Equals(btn))
                                btn.Checked = false;
                        }

                        var mapped = Mapping[b.Text];
                        if (mapped.Item1 == 1)
                        {
                            dataGridView1[selectedCol, selectedRow].Value = mapped.Item1;
                            dataGridView1[selectedRow, selectedCol].Value = mapped.Item1;
                        }
                        else if (mapped.Item2)
                        {
                            dataGridView1[selectedCol, selectedRow].Value = "1/" + mapped.Item1;
                            dataGridView1[selectedRow, selectedCol].Value = mapped.Item1;
                        }
                        else
                        {
                            dataGridView1[selectedCol, selectedRow].Value = mapped.Item1;
                            dataGridView1[selectedRow, selectedCol].Value = "1/" + mapped.Item1;
                        }
                    }
                    else
                    {
                        b.Checked = false;
                    }
                    UpdateResults();
                };
            }
            UpdateLeftPanel();
            UpdateResults();
        }

        int selectedRow = 0;
        int selectedCol = 0;


        private void dataGridView1_CellClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            selectedRow = e.RowIndex;
            selectedCol = e.ColumnIndex;

            UpdateLeftPanel();
            UpdateSelectedCellHeaders();
        }
        void UpdateSelectedCellHeaders()
        {
            for (int i = 0; i < Labels.Length; i++)
            {
                var col = dataGridView1.Columns[i];
                col.HeaderCell.Style = new DataGridViewCellStyle();
                var row = dataGridView1.Rows[i];
                row.HeaderCell.Style = new DataGridViewCellStyle();
            }

            var selectedStyle = new DataGridViewCellStyle();
            selectedStyle.BackColor = Color.YellowGreen;

            dataGridView1.Columns[selectedCol].HeaderCell.Style = selectedStyle;
            dataGridView1.Rows[selectedRow].HeaderCell.Style = selectedStyle;
        }
        void UpdateLeftPanel()
        {
            var buttons = new RadioButton[]
            {
                radioButton1,
                radioButton2,
                radioButton3,
                radioButton4,
                radioButton5,
                radioButton6,
                radioButton7,
                radioButton8,
                radioButton9,
                radioButton10,
                radioButton11,
                radioButton12,
                radioButton13,
                radioButton14,
                radioButton15,
                radioButton16,
                radioButton17,
            };
            string text = dataGridView1[selectedCol, selectedRow].Value.ToString();
            foreach (var btn in buttons)
            {
                btn.Checked = btn.Text == text;
            }

            entity1NameLabel.Text = Labels[selectedRow];
            entity2NameLabel.Text = Labels[selectedCol];
        }

        private void GridWithSelectionControl_Load(object sender, System.EventArgs e)
        {
            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            UpdateSelectedCellHeaders();
        }

        void UpdateResults()
        {
            textBoxOS.Text = Math.Round(OS, 4).ToString();

            string[] valsToShow = new string[Labels.Length];
            for(int i = 0; i < valsToShow.Length; i++)
            {
                valsToShow[i] = Math.Round(PriorityVector[i], 4) + "\t" + Labels[i];
            }

            textBoxPriorityVec.Text = "\r\n" + String.Join("\r\n", valsToShow);
        }

        public double[,] InsertedValues
        {
            get
            {
                double[,] vals = new double[dataGridView1.ColumnCount , dataGridView1.ColumnCount];

                for(int i = 0; i < vals.GetLength(0); i++)
                {
                    for(int j = 0; j < vals.GetLength(1); j++)
                    {
                        var mapped = Mapping[dataGridView1[j, i].Value.ToString()];
                        if (mapped.Item2)
                            vals[i, j] = 1.0 / mapped.Item1;
                        else
                            vals[i, j] = mapped.Item1;
                    }
                }

                return vals;
            }
        }

        /// <summary>
        /// Значения веса, которые меньше единицы, не учитываются и должны быть установлены в ноль. На их позицию ставится числор, равно 1 деленное на значение в соответствующей ячейке
        /// </summary>
        /// <param name="weight"></param>
        public void SetPreferableWeights(int[,] weights)
        {
            if (weights.GetLength(0) != Labels.Length || weights.GetLength(1) != Labels.Length)
            {
                throw new ArgumentException("Values should have same height and width as provided labels lenght");
            }


            string[,] gridTexts = new string[dataGridView1.ColumnCount, dataGridView1.ColumnCount];

            for (int i = 0; i < weights.GetLength(0); i++)
            {
                for (int j = 0; j < weights.GetLength(1); j++)
                {
                    if (weights[i, j] < 0 || weights[i, j] > 9)
                    {
                        throw new ArgumentOutOfRangeException("Число вне доспутимого диапазона [0,9]: " + weights[i, j]);
                    }
                    if(weights[i, j]!=0)
                    {
                        if (gridTexts[j, i] != null && weights[i, j] != 1 && i!=j)
                        {
                            throw
                                new FormatException("Таблица содержит взаимоисключающие веса:"
                                        + weights[i, j] + "(" + i + "," + j + ") и" + gridTexts[j, i] + "(" + j + "," + i + ")");
                        }

                        gridTexts[i, j] = weights[i, j].ToString();
                        if (weights[i, j] == 1)
                        {
                            gridTexts[j, i] = weights[i, j].ToString();
                        }
                        else
                        {
                            gridTexts[j, i] = "1/" + weights[i, j].ToString();
                        }
                    }
                }
            }

            for(int i = 0; i < gridTexts.GetLength(0); i++)
            {
                for(int j = 0; j < gridTexts.GetLength(1); j++)
                {
                    dataGridView1[j, i].Value = gridTexts[i, j];
                }
            }


            UpdateLeftPanel();
            UpdateResults();
        }

        public double[] PriorityVector
        {
            get
            {
                double[] averageGeom = new double[Labels.Length];
                var vals = InsertedValues;
                for(int i = 0; i < averageGeom.Length; i++)
                {
                    double res = 1;
                    for(int j = 0; j < averageGeom.Length; j++)
                    {
                        res *= vals[i, j];
                    }
                    var res2 = Math.Pow(res, 1.0 / Labels.Length);
                    averageGeom[i] = res2;
                }
                double avg = averageGeom.Sum();
                double[] priorityVec = averageGeom.Select(el => el / avg).ToArray();
                return priorityVec;
            }
        }

        double[] EigenValuesAbs
        {
            get
            {
                EigenvalueDecomposition d = new EigenvalueDecomposition(InsertedValues);
                double[] realPart = d.RealEigenvalues;
                double[] imagenaryPart = d.ImaginaryEigenvalues;

                double[] vals = new double[realPart.Length];
                for(int i = 0; i < realPart.Length; i++)
                {
                    vals[i] = Math.Sqrt(realPart[i] * realPart[i] + imagenaryPart[i] * imagenaryPart[i]);
                }

                return vals;
            }
        }

        public double OS
        {
            get
            {
                double[] Mio = new double[] { 0, 0, 0.58, 0.9, 1.12, 1.24, 1.32, 1.41, 1.45, 1.49, 1.51 };

                double eigAbsMax = EigenValuesAbs.Max();
                double os = (eigAbsMax - Labels.Length) / (Labels.Length - 1.0) / Mio[Labels.Length - 1];
                return os;
            }
        }

    }
}
