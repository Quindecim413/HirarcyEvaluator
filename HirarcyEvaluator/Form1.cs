using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Math;

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace HirarcyEvaluator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowCount = 4;
            dataGridView2.RowCount = 4;
            for (int i = 0; i < 3; i++)
            {
                dataGridView1[0, i].Value = "Критерий " + (i + 1);
                dataGridView2[0, i].Value = "Параметр " + (i + 1);
            }
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (dataGridView1.RowCount < 4)
            {
                dataGridView1.RowCount += dataGridView1.RowCount % 3;
                MessageBox.Show("Должно быть не менее 3-х критериев!", "Предупреждение");
            }
        }
        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (dataGridView1.RowCount > 11)
            {
                dataGridView1.RowCount = 11;
                MessageBox.Show("К сожалению не допускается более 11 критериев :(", "Предупреждение");
            }
        }

        private void dataGridView2_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (dataGridView2.RowCount < 4)
            {
                dataGridView2.RowCount += dataGridView2.RowCount % 3;
                MessageBox.Show("Должно быть не менее 3-х сущностей!", "Предупреждение");
            }
        }
        private void dataGridView2_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (dataGridView2.RowCount > 11)
            {
                dataGridView2.RowCount = 11;
                MessageBox.Show("К сожалению не допускается более 11 сущностей :(", "Предупреждение");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrySubmitChangedValuesAndStartEdit();
        }

        public bool TrySubmitChangedValuesAndStartEdit()
        {
            string[] dataParams = new string[dataGridView1.RowCount];

            Func<string[], string[]> findDuplicates = (allStrs) =>
            {
                List<string> duplicatesParams = new List<string>();
                HashSet<string> paramsViewed = new HashSet<string>();
                for (int i = 0; i < allStrs.Length; i++)
                {
                    string val = allStrs[i];
                    if (paramsViewed.Contains(val))
                        duplicatesParams.Add(val);
                }
                return duplicatesParams.ToArray();
            };

            string[] valsParams = new string[dataGridView1.RowCount - 1];
            for (int i = 0; i < valsParams.Length; i++)
            {
                valsParams[i] = dataGridView1[0, i].Value.ToString();
            }
            string[] valsEntities = new string[dataGridView2.RowCount - 1];
            for (int i = 0; i < valsEntities.Length; i++)
            {
                valsEntities[i] = dataGridView2[0, i].Value.ToString();
            }

            if(valsParams.Length < 3)
            {
                MessageBox.Show("Должно быть по крайней мере 3 параметра!");
                return false;
            }
            if(valsEntities.Length < 3)
            {
                MessageBox.Show("Должно быть по крайней мере 3 сущности!");
                return false;
            }

            string[] duplParams = findDuplicates(valsParams);
            string[] duplEntities = findDuplicates(valsEntities);

            if (duplParams.Length > 0 || duplEntities.Length > 0)
            {
                string message = "";
                if (duplParams.Length > 0)
                {
                    message += "Дубликаты параметров:\r\n" + string.Join(", ", duplParams.Select(el => el.ToString())) + "\r\n";
                }
                if (duplEntities.Length > 0)
                {
                    message += "Дубликаты сущностей:\r\n" + string.Join(", ", duplEntities.Select(el => el.ToString()));
                }
                MessageBox.Show(message, "Обнаружены дубликаты!");
                return false;
            }

            //Обновление элемента заполнения данных сетки параметров
            ParamsGrid = new GridWithSelectionControl(valsParams);
            ParamsGrid.Dock = DockStyle.Fill;
            tabPageParams.Controls.Clear();
            tabPageParams.Controls.Add(ParamsGrid);

            tabControlEntities.Controls.Clear();

            EntitiesComparisons = new GridWithSelectionControl[valsParams.Length];

            for (int i = 0; i < valsParams.Length; i++)
            {
                string paramName = valsParams[i];

                GridWithSelectionControl grid = new GridWithSelectionControl(valsEntities);
                grid.Dock = DockStyle.Fill;

                TabPage page = new TabPage(paramName);

                page.Controls.Add(grid);
                tabControlEntities.TabPages.Add(page);


                EntitiesComparisons[i] = grid;
            }

            // и переходим на закладку оценки параметров
            tabControlAll.SelectedIndex = 1;
            return true;
        }

        GridWithSelectionControl ParamsGrid;
        GridWithSelectionControl[] EntitiesComparisons;

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int k = 0;
        }

        private void tabControlAll_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tabControl = (TabControl)sender;
            if (tabControl.SelectedIndex == tabControl.TabPages.Count - 1)
            {
                // fill data
                if (ParamsGrid == null)
                    return;

                var paramsWeights = ParamsGrid.PriorityVector;

                double[,] entities2ParamsWeights = new double[EntitiesComparisons[0].Labels.Length, paramsWeights.Length];
                for (int j = 0; j < EntitiesComparisons.Length; j++)
                {
                    double[] priorityVec = EntitiesComparisons[j].PriorityVector;
                    double os = EntitiesComparisons[j].OS;
                    for (int i = 0; i < priorityVec.Length; i++)
                        entities2ParamsWeights[i, j] = priorityVec[i];
                }

                double[] entitiesWeights = Matrix.Dot(entities2ParamsWeights, paramsWeights);

                dataGridViewWeightsEntitiesAndParams.ColumnCount = 0;
                dataGridViewWeightsEntitiesAndParams.ColumnCount = entities2ParamsWeights.GetLength(1);
                dataGridViewWeightsEntitiesAndParams.RowCount = entities2ParamsWeights.GetLength(0);

                var paramsNames = ParamsGrid.Labels;
                for (int i = 0; i < entities2ParamsWeights.GetLength(0); i++)
                {
                    dataGridViewWeightsEntitiesAndParams.Columns[i].HeaderText = paramsNames[i];
                    dataGridViewWeightsEntitiesAndParams.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    for (int j = 0; j < entities2ParamsWeights.GetLength(1); j++)
                    {
                        dataGridViewWeightsEntitiesAndParams[j, i].Value = Math.Round(entities2ParamsWeights[i, j], 4);
                    }
                }

                dataGridViewWeightsParams.RowCount = 0;
                dataGridViewWeightsParams.RowCount = paramsWeights.Length;
                for (int i = 0; i < paramsWeights.Length; i++)
                {
                    dataGridViewWeightsParams[0, i].Value = Math.Round(paramsWeights[i], 4);
                }

                dataGridViewWeightsEntities.RowCount = 0;
                dataGridViewWeightsEntities.RowCount = entitiesWeights.Length;

                string[] entitiesNames = EntitiesComparisons[0].Labels;

                double maxScore = entitiesWeights.Max();

                for (int i = 0; i < entitiesWeights.Length; i++)
                {
                    dataGridViewWeightsEntities[0, i].Value = Math.Round(entitiesWeights[i], 4);
                    dataGridViewWeightsEntities[1, i].Value = entitiesNames[i];
                    if (entitiesWeights[i] == maxScore)
                    {
                        var winnerStyle = new DataGridViewCellStyle();
                        winnerStyle.BackColor = Color.GreenYellow;
                        dataGridViewWeightsEntities[0, i].Style = winnerStyle;
                        dataGridViewWeightsEntities[1, i].Style = winnerStyle;
                    }
                }
            }
        }


        public class StateObj
        {
            public string[] Params { get; set; }
            public string[] Entities { get; set; }
            public GridDataObj ParamsGrid { get; set; }
            public GridDataObj[] EntitiesGrids { get; set; }
        }
        public class GridDataObj
        {
            public int[,] Data { get; set; }
        }
        private void Save(string filePath)
        {
            if(ParamsGrid == null)
            {
                MessageBox.Show("Пока еще нечего сохранять");
                return;
            }

            StateObj state = new StateObj();


            state.Params = ParamsGrid.Labels;
            state.Entities = EntitiesComparisons[0].Labels;

            Func<double[,], int[,]> dumpGrid = (vals) =>
            {
                int[,] res = new int[vals.GetLength(0), vals.GetLength(1)];
                for (int i = 0; i < res.GetLength(0); i++)
                {
                    for (int j = 0; j < res.GetLength(1); j++)
                    {
                        res[i, j] = (int)vals[i, j]; // все ниже 1 сами по себе приобразуются к 0
                    }
                }
                return res;
            };

            state.ParamsGrid = new GridDataObj() { Data = dumpGrid(ParamsGrid.InsertedValues) };

            state.EntitiesGrids = new GridDataObj[EntitiesComparisons.Length];
            for(int i = 0; i < EntitiesComparisons.Length; i++)
            {
                state.EntitiesGrids[i] = new GridDataObj() { Data = dumpGrid(EntitiesComparisons[i].InsertedValues) };
            }

            var jsonToWrite = JsonConvert.SerializeObject(state, Formatting.Indented);
            using(var writer = new StreamWriter(filePath))
            {
                writer.Write(jsonToWrite);
            }
        }

        public void Restore(string filePath)
        {
            string jsonFromFile;
            using (var reader = new StreamReader(filePath))
            {
                jsonFromFile = reader.ReadToEnd();
            }

            var stateRestored = JsonConvert.DeserializeObject<StateObj>(jsonFromFile);

            dataGridView1.RowCount = stateRestored.Params.Length + 1;
            for(int i = 0; i < stateRestored.Params.Length; i++)
            {
                dataGridView1[0, i].Value = stateRestored.Params[i];
            }

            dataGridView2.RowCount = stateRestored.Entities.Length + 1;
            for(int i = 0; i < stateRestored.Entities.Length; i++)
            {
                dataGridView2[0, i].Value = stateRestored.Entities[i];
            }

            if (TrySubmitChangedValuesAndStartEdit())
            {
                try
                {
                    ParamsGrid.SetPreferableWeights(stateRestored.ParamsGrid.Data);
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message, "Ошибка установки весов в параметрах");
                }
                for(int i = 0; i < stateRestored.EntitiesGrids.Length; i++)
                {
                    try
                    {
                        EntitiesComparisons[i].SetPreferableWeights(stateRestored.EntitiesGrids[i].Data);
                    }catch(Exception e)
                    {
                        MessageBox.Show(e.Message, "Ошибка установки весов для " + (i+1) +"-го параметра");
                    }
                }
            }
        }

        private void buttonSaveState_Click(object sender, EventArgs e)
        {
            SaveFileDialog d = new SaveFileDialog();
            d.Filter = "Json files (*.json)|*.json";
            if (d.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Save(d.FileName);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка сохранения");
                }
            }
        }

        private void buttonLoadState_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "Json files (*.json)|*.json";
            if (d.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Restore(d.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка чтения/формата");
                }
            }
        }
    }
}
