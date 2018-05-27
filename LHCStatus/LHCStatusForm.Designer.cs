namespace LHCStatus
{
    partial class LHCStatusForm
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
            this.components = new System.ComponentModel.Container();
            this.SystemCERNTimeLabel = new System.Windows.Forms.Label();
            this.SystemCERNDateLabel = new System.Windows.Forms.Label();
            this.LHCButtonTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // SystemCERNTimeLabel
            // 
            this.SystemCERNTimeLabel.AutoSize = true;
            this.SystemCERNTimeLabel.Location = new System.Drawing.Point(12, 9);
            this.SystemCERNTimeLabel.Name = "SystemCERNTimeLabel";
            this.SystemCERNTimeLabel.Size = new System.Drawing.Size(120, 13);
            this.SystemCERNTimeLabel.TabIndex = 0;
            this.SystemCERNTimeLabel.Text = "SystemCERNTimeLabel";
            // 
            // SystemCERNDateLabel
            // 
            this.SystemCERNDateLabel.AutoSize = true;
            this.SystemCERNDateLabel.Location = new System.Drawing.Point(12, 43);
            this.SystemCERNDateLabel.Name = "SystemCERNDateLabel";
            this.SystemCERNDateLabel.Size = new System.Drawing.Size(120, 13);
            this.SystemCERNDateLabel.TabIndex = 1;
            this.SystemCERNDateLabel.Text = "SystemCERNDateLabel";
            // 
            // LHCButtonTableLayoutPanel
            // 
            this.LHCButtonTableLayoutPanel.AutoSize = true;
            this.LHCButtonTableLayoutPanel.ColumnCount = 2;
            this.LHCButtonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LHCButtonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LHCButtonTableLayoutPanel.Location = new System.Drawing.Point(15, 91);
            this.LHCButtonTableLayoutPanel.Name = "LHCButtonTableLayoutPanel";
            this.LHCButtonTableLayoutPanel.RowCount = 2;
            this.LHCButtonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LHCButtonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LHCButtonTableLayoutPanel.Size = new System.Drawing.Size(200, 100);
            this.LHCButtonTableLayoutPanel.TabIndex = 2;
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // LHCStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LHCButtonTableLayoutPanel);
            this.Controls.Add(this.SystemCERNDateLabel);
            this.Controls.Add(this.SystemCERNTimeLabel);
            this.Name = "LHCStatusForm";
            this.Text = "LHCStatusForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LHCStatusForm_FormClosing);
            this.Load += new System.EventHandler(this.LHCStatusForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SystemCERNTimeLabel;
        private System.Windows.Forms.Label SystemCERNDateLabel;
        private System.Windows.Forms.TableLayoutPanel LHCButtonTableLayoutPanel;
        private System.Windows.Forms.Timer Timer;
    }
}