namespace ProcessWatcher
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._controlViewerPanel = new System.Windows.Forms.Panel();
            this._processWatcherUserControl = new ProcessWatcher.Views.ProcessWatcherUserControl();
            this._controlViewerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _controlViewerPanel
            // 
            this._controlViewerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._controlViewerPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._controlViewerPanel.Controls.Add(this._processWatcherUserControl);
            this._controlViewerPanel.Location = new System.Drawing.Point(12, 12);
            this._controlViewerPanel.Name = "_controlViewerPanel";
            this._controlViewerPanel.Size = new System.Drawing.Size(760, 537);
            this._controlViewerPanel.TabIndex = 0;
            // 
            // _processWatcherUserControl
            // 
            this._processWatcherUserControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._processWatcherUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._processWatcherUserControl.Location = new System.Drawing.Point(0, 0);
            this._processWatcherUserControl.Name = "_processWatcherUserControl";
            this._processWatcherUserControl.Size = new System.Drawing.Size(760, 537);
            this._processWatcherUserControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this._controlViewerPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.Text = "Наблюдатель процессов";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this._controlViewerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _controlViewerPanel;
        private Views.ProcessWatcherUserControl _processWatcherUserControl;
    }
}

