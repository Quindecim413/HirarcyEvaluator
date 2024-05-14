namespace HirarcyEvaluator
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlAll = new System.Windows.Forms.TabControl();
            this.tabPageEntitiesList = new System.Windows.Forms.TabPage();
            this.buttonLoadState = new System.Windows.Forms.Button();
            this.buttonSaveState = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageParams = new System.Windows.Forms.TabPage();
            this.tabPageEntities = new System.Windows.Forms.TabPage();
            this.tabControlEntities = new System.Windows.Forms.TabControl();
            this.tabPageResults = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewWeightsEntitiesAndParams = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewWeightsParams = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewWeightsEntities = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControlAll.SuspendLayout();
            this.tabPageEntitiesList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPageEntities.SuspendLayout();
            this.tabPageResults.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeightsEntitiesAndParams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeightsParams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeightsEntities)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlAll
            // 
            this.tabControlAll.Controls.Add(this.tabPageEntitiesList);
            this.tabControlAll.Controls.Add(this.tabPageParams);
            this.tabControlAll.Controls.Add(this.tabPageEntities);
            this.tabControlAll.Controls.Add(this.tabPageResults);
            this.tabControlAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAll.Location = new System.Drawing.Point(0, 0);
            this.tabControlAll.Name = "tabControlAll";
            this.tabControlAll.SelectedIndex = 0;
            this.tabControlAll.Size = new System.Drawing.Size(1025, 509);
            this.tabControlAll.TabIndex = 0;
            this.tabControlAll.SelectedIndexChanged += new System.EventHandler(this.tabControlAll_SelectedIndexChanged);
            // 
            // tabPageEntitiesList
            // 
            this.tabPageEntitiesList.Controls.Add(this.buttonLoadState);
            this.tabPageEntitiesList.Controls.Add(this.buttonSaveState);
            this.tabPageEntitiesList.Controls.Add(this.button1);
            this.tabPageEntitiesList.Controls.Add(this.dataGridView2);
            this.tabPageEntitiesList.Controls.Add(this.dataGridView1);
            this.tabPageEntitiesList.Location = new System.Drawing.Point(4, 22);
            this.tabPageEntitiesList.Name = "tabPageEntitiesList";
            this.tabPageEntitiesList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEntitiesList.Size = new System.Drawing.Size(1017, 483);
            this.tabPageEntitiesList.TabIndex = 0;
            this.tabPageEntitiesList.Text = "Настройка параметров";
            this.tabPageEntitiesList.UseVisualStyleBackColor = true;
            // 
            // buttonLoadState
            // 
            this.buttonLoadState.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLoadState.Location = new System.Drawing.Point(9, 426);
            this.buttonLoadState.Name = "buttonLoadState";
            this.buttonLoadState.Size = new System.Drawing.Size(473, 49);
            this.buttonLoadState.TabIndex = 4;
            this.buttonLoadState.Text = "Загрузить";
            this.buttonLoadState.UseVisualStyleBackColor = true;
            this.buttonLoadState.Click += new System.EventHandler(this.buttonLoadState_Click);
            // 
            // buttonSaveState
            // 
            this.buttonSaveState.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSaveState.Location = new System.Drawing.Point(9, 371);
            this.buttonSaveState.Name = "buttonSaveState";
            this.buttonSaveState.Size = new System.Drawing.Size(473, 49);
            this.buttonSaveState.TabIndex = 3;
            this.buttonSaveState.Text = "Сохранить";
            this.buttonSaveState.UseVisualStyleBackColor = true;
            this.buttonSaveState.Click += new System.EventHandler(this.buttonSaveState_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(517, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(492, 57);
            this.button1.TabIndex = 2;
            this.button1.Text = "Применить изменения\r\n!!!все в данные в таблицах весов будут стерты!!!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2});
            this.dataGridView2.Location = new System.Drawing.Point(517, 6);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(492, 358);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView2_UserAddedRow);
            this.dataGridView2.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView2_UserDeletedRow);
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Название сущности";
            this.Column2.Name = "Column2";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(8, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(474, 358);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserAddedRow);
            this.dataGridView1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserDeletedRow);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Название критерия";
            this.Column1.Name = "Column1";
            // 
            // tabPageParams
            // 
            this.tabPageParams.Location = new System.Drawing.Point(4, 22);
            this.tabPageParams.Name = "tabPageParams";
            this.tabPageParams.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParams.Size = new System.Drawing.Size(1017, 483);
            this.tabPageParams.TabIndex = 1;
            this.tabPageParams.Text = "Подстройка критериев";
            this.tabPageParams.UseVisualStyleBackColor = true;
            // 
            // tabPageEntities
            // 
            this.tabPageEntities.Controls.Add(this.tabControlEntities);
            this.tabPageEntities.Location = new System.Drawing.Point(4, 22);
            this.tabPageEntities.Name = "tabPageEntities";
            this.tabPageEntities.Size = new System.Drawing.Size(1017, 483);
            this.tabPageEntities.TabIndex = 2;
            this.tabPageEntities.Text = "Подстройка сущностей";
            this.tabPageEntities.UseVisualStyleBackColor = true;
            // 
            // tabControlEntities
            // 
            this.tabControlEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEntities.Location = new System.Drawing.Point(0, 0);
            this.tabControlEntities.Name = "tabControlEntities";
            this.tabControlEntities.SelectedIndex = 0;
            this.tabControlEntities.Size = new System.Drawing.Size(1017, 483);
            this.tabControlEntities.TabIndex = 0;
            // 
            // tabPageResults
            // 
            this.tabPageResults.Controls.Add(this.tableLayoutPanel1);
            this.tabPageResults.Location = new System.Drawing.Point(4, 22);
            this.tabPageResults.Name = "tabPageResults";
            this.tabPageResults.Size = new System.Drawing.Size(1017, 483);
            this.tabPageResults.TabIndex = 3;
            this.tabPageResults.Text = "Результаты";
            this.tabPageResults.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.96296F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 391F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewWeightsEntitiesAndParams, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewWeightsParams, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewWeightsEntities, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 483F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1017, 483);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridViewWeightsEntitiesAndParams
            // 
            this.dataGridViewWeightsEntitiesAndParams.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewWeightsEntitiesAndParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWeightsEntitiesAndParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWeightsEntitiesAndParams.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewWeightsEntitiesAndParams.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewWeightsEntitiesAndParams.Name = "dataGridViewWeightsEntitiesAndParams";
            this.dataGridViewWeightsEntitiesAndParams.ReadOnly = true;
            this.dataGridViewWeightsEntitiesAndParams.RowHeadersVisible = false;
            this.dataGridViewWeightsEntitiesAndParams.Size = new System.Drawing.Size(459, 483);
            this.dataGridViewWeightsEntitiesAndParams.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(462, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 483);
            this.label1.TabIndex = 1;
            this.label1.Text = "x";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewWeightsParams
            // 
            this.dataGridViewWeightsParams.AllowUserToAddRows = false;
            this.dataGridViewWeightsParams.AllowUserToDeleteRows = false;
            this.dataGridViewWeightsParams.AllowUserToOrderColumns = true;
            this.dataGridViewWeightsParams.AllowUserToResizeColumns = false;
            this.dataGridViewWeightsParams.AllowUserToResizeRows = false;
            this.dataGridViewWeightsParams.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewWeightsParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWeightsParams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5});
            this.dataGridViewWeightsParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWeightsParams.Location = new System.Drawing.Point(489, 0);
            this.dataGridViewWeightsParams.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewWeightsParams.Name = "dataGridViewWeightsParams";
            this.dataGridViewWeightsParams.ReadOnly = true;
            this.dataGridViewWeightsParams.RowHeadersVisible = false;
            this.dataGridViewWeightsParams.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewWeightsParams.Size = new System.Drawing.Size(102, 483);
            this.dataGridViewWeightsParams.TabIndex = 2;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Вес критерия";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewWeightsEntities
            // 
            this.dataGridViewWeightsEntities.AllowUserToAddRows = false;
            this.dataGridViewWeightsEntities.AllowUserToDeleteRows = false;
            this.dataGridViewWeightsEntities.AllowUserToOrderColumns = true;
            this.dataGridViewWeightsEntities.AllowUserToResizeColumns = false;
            this.dataGridViewWeightsEntities.AllowUserToResizeRows = false;
            this.dataGridViewWeightsEntities.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewWeightsEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWeightsEntities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4});
            this.dataGridViewWeightsEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWeightsEntities.Location = new System.Drawing.Point(626, 0);
            this.dataGridViewWeightsEntities.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewWeightsEntities.Name = "dataGridViewWeightsEntities";
            this.dataGridViewWeightsEntities.ReadOnly = true;
            this.dataGridViewWeightsEntities.RowHeadersVisible = false;
            this.dataGridViewWeightsEntities.Size = new System.Drawing.Size(391, 483);
            this.dataGridViewWeightsEntities.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(594, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 483);
            this.label2.TabIndex = 4;
            this.label2.Text = "=";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Вес";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Сущность";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 509);
            this.Controls.Add(this.tabControlAll);
            this.Name = "Form1";
            this.Text = "Считатель по метода анализа иерархий";
            this.tabControlAll.ResumeLayout(false);
            this.tabPageEntitiesList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPageEntities.ResumeLayout(false);
            this.tabPageResults.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeightsEntitiesAndParams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeightsParams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeightsEntities)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlAll;
        private System.Windows.Forms.TabPage tabPageEntitiesList;
        private System.Windows.Forms.TabPage tabPageParams;
        private System.Windows.Forms.TabPage tabPageEntities;
        private System.Windows.Forms.TabPage tabPageResults;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridViewWeightsEntitiesAndParams;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewWeightsParams;
        private System.Windows.Forms.DataGridView dataGridViewWeightsEntities;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControlEntities;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button buttonLoadState;
        private System.Windows.Forms.Button buttonSaveState;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}

