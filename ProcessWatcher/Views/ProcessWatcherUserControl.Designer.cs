
namespace ProcessWatcher.Views
{
    partial class ProcessWatcherUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._processesDataGrid = new System.Windows.Forms.DataGridView();
            this._processViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._stopButton = new System.Windows.Forms.Button();
            this._startButton = new System.Windows.Forms.Button();
            this._processListDescriptionLabel = new System.Windows.Forms.Label();
            this._processIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._processNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._commandLineColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._executablePathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._processesDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._processViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _processesDataGrid
            // 
            this._processesDataGrid.AllowUserToAddRows = false;
            this._processesDataGrid.AllowUserToDeleteRows = false;
            this._processesDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._processesDataGrid.AutoGenerateColumns = false;
            this._processesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._processesDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._processIdColumn,
            this._processNameColumn,
            this._commandLineColumn,
            this._executablePathColumn});
            this._processesDataGrid.DataSource = this._processViewModelBindingSource;
            this._processesDataGrid.Location = new System.Drawing.Point(3, 45);
            this._processesDataGrid.Name = "_processesDataGrid";
            this._processesDataGrid.ReadOnly = true;
            this._processesDataGrid.RowHeadersVisible = false;
            this._processesDataGrid.Size = new System.Drawing.Size(634, 403);
            this._processesDataGrid.TabIndex = 1;
            this._processesDataGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ProcessesDataGrid_CellMouseDoubleClick);
            // 
            // _processViewModelBindingSource
            // 
            this._processViewModelBindingSource.DataSource = typeof(ProcessWatcher.Models.ProcessViewModel);
            // 
            // _stopButton
            // 
            this._stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._stopButton.Enabled = false;
            this._stopButton.Location = new System.Drawing.Point(129, 454);
            this._stopButton.Name = "_stopButton";
            this._stopButton.Size = new System.Drawing.Size(120, 23);
            this._stopButton.TabIndex = 4;
            this._stopButton.Text = "Остановить";
            this._stopButton.UseVisualStyleBackColor = true;
            this._stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // _startButton
            // 
            this._startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._startButton.Enabled = false;
            this._startButton.Location = new System.Drawing.Point(3, 454);
            this._startButton.Name = "_startButton";
            this._startButton.Size = new System.Drawing.Size(120, 23);
            this._startButton.TabIndex = 3;
            this._startButton.Text = "Запустить";
            this._startButton.UseVisualStyleBackColor = true;
            this._startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // _processListDescriptionLabel
            // 
            this._processListDescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._processListDescriptionLabel.AutoSize = true;
            this._processListDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._processListDescriptionLabel.Location = new System.Drawing.Point(3, 6);
            this._processListDescriptionLabel.Name = "_processListDescriptionLabel";
            this._processListDescriptionLabel.Size = new System.Drawing.Size(263, 31);
            this._processListDescriptionLabel.TabIndex = 96;
            this._processListDescriptionLabel.Text = "Список процессов";
            // 
            // _processIdColumn
            // 
            this._processIdColumn.DataPropertyName = "ProcessId";
            this._processIdColumn.HeaderText = "Идентификатор процесса";
            this._processIdColumn.Name = "_processIdColumn";
            this._processIdColumn.ReadOnly = true;
            // 
            // _processNameColumn
            // 
            this._processNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._processNameColumn.DataPropertyName = "Name";
            this._processNameColumn.HeaderText = "Имя процесса";
            this._processNameColumn.Name = "_processNameColumn";
            this._processNameColumn.ReadOnly = true;
            // 
            // _commandLineColumn
            // 
            this._commandLineColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._commandLineColumn.DataPropertyName = "CommandLine";
            this._commandLineColumn.HeaderText = "Командная строка";
            this._commandLineColumn.Name = "_commandLineColumn";
            this._commandLineColumn.ReadOnly = true;
            // 
            // _executablePathColumn
            // 
            this._executablePathColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._executablePathColumn.DataPropertyName = "ExecutablePath";
            this._executablePathColumn.HeaderText = "Исполняемый путь";
            this._executablePathColumn.Name = "_executablePathColumn";
            this._executablePathColumn.ReadOnly = true;
            // 
            // ProcessWatcherUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._processListDescriptionLabel);
            this.Controls.Add(this._stopButton);
            this.Controls.Add(this._startButton);
            this.Controls.Add(this._processesDataGrid);
            this.Name = "ProcessWatcherUserControl";
            this.Size = new System.Drawing.Size(640, 480);
            this.Load += new System.EventHandler(this.ProcessWatcherUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this._processesDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._processViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _processesDataGrid;
        private System.Windows.Forms.Button _stopButton;
        private System.Windows.Forms.Button _startButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn virtualMemorySize64DataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource _processViewModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn _statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _processIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _commandLineDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _executablePathDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label _processListDescriptionLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn _processIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _processNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _commandLineColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _executablePathColumn;
    }
}
