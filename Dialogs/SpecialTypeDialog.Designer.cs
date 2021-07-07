
namespace laba15
{
    partial class SpecialTypeDialog
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBanking = new System.Windows.Forms.RadioButton();
            this.buttonCommercial = new System.Windows.Forms.RadioButton();
            this.buttonConsumptive = new System.Windows.Forms.RadioButton();
            this.buttonInterstate = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(275, 182);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(141, 50);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(13, 182);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(146, 49);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите тип:";
            // 
            // buttonBanking
            // 
            this.buttonBanking.AutoSize = true;
            this.buttonBanking.Location = new System.Drawing.Point(163, 36);
            this.buttonBanking.Name = "buttonBanking";
            this.buttonBanking.Size = new System.Drawing.Size(92, 24);
            this.buttonBanking.TabIndex = 3;
            this.buttonBanking.TabStop = true;
            this.buttonBanking.Text = "Banking";
            this.buttonBanking.UseVisualStyleBackColor = true;
            // 
            // buttonCommercial
            // 
            this.buttonCommercial.AutoSize = true;
            this.buttonCommercial.Location = new System.Drawing.Point(163, 66);
            this.buttonCommercial.Name = "buttonCommercial";
            this.buttonCommercial.Size = new System.Drawing.Size(117, 24);
            this.buttonCommercial.TabIndex = 4;
            this.buttonCommercial.TabStop = true;
            this.buttonCommercial.Text = "Commercial";
            this.buttonCommercial.UseVisualStyleBackColor = true;
            // 
            // buttonConsumptive
            // 
            this.buttonConsumptive.AutoSize = true;
            this.buttonConsumptive.Location = new System.Drawing.Point(163, 96);
            this.buttonConsumptive.Name = "buttonConsumptive";
            this.buttonConsumptive.Size = new System.Drawing.Size(126, 24);
            this.buttonConsumptive.TabIndex = 5;
            this.buttonConsumptive.TabStop = true;
            this.buttonConsumptive.Text = "Consumptive";
            this.buttonConsumptive.UseVisualStyleBackColor = true;
            // 
            // buttonInterstate
            // 
            this.buttonInterstate.AutoSize = true;
            this.buttonInterstate.Location = new System.Drawing.Point(163, 126);
            this.buttonInterstate.Name = "buttonInterstate";
            this.buttonInterstate.Size = new System.Drawing.Size(103, 24);
            this.buttonInterstate.TabIndex = 6;
            this.buttonInterstate.TabStop = true;
            this.buttonInterstate.Text = "Interstate";
            this.buttonInterstate.UseVisualStyleBackColor = true;
            // 
            // SpecialTypeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 244);
            this.Controls.Add(this.buttonInterstate);
            this.Controls.Add(this.buttonConsumptive);
            this.Controls.Add(this.buttonCommercial);
            this.Controls.Add(this.buttonBanking);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpecialTypeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpecialTypeDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton buttonBanking;
        private System.Windows.Forms.RadioButton buttonCommercial;
        private System.Windows.Forms.RadioButton buttonConsumptive;
        private System.Windows.Forms.RadioButton buttonInterstate;
    }
}