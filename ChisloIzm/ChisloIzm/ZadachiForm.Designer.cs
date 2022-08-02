namespace ChisloIzm
{
    partial class zadachiForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(zadachiForm));
            this.btnQuest = new System.Windows.Forms.Button();
            this.pbTimer = new System.Windows.Forms.PictureBox();
            this.pbQuest = new System.Windows.Forms.PictureBox();
            this.pn = new System.Windows.Forms.Panel();
            this.pb = new System.Windows.Forms.PictureBox();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.lbAnswer = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.timeTXT = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuest)).BeginInit();
            this.pn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuest
            // 
            this.btnQuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnQuest.Image = ((System.Drawing.Image)(resources.GetObject("btnQuest.Image")));
            this.btnQuest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuest.Location = new System.Drawing.Point(11, 11);
            this.btnQuest.Name = "btnQuest";
            this.btnQuest.Size = new System.Drawing.Size(162, 38);
            this.btnQuest.TabIndex = 55;
            this.btnQuest.Text = "     Розпочати тест";
            this.btnQuest.UseVisualStyleBackColor = true;
            this.btnQuest.Click += new System.EventHandler(this.btnQuest_Click);
            // 
            // pbTimer
            // 
            this.pbTimer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbTimer.Location = new System.Drawing.Point(635, 4);
            this.pbTimer.Name = "pbTimer";
            this.pbTimer.Size = new System.Drawing.Size(100, 22);
            this.pbTimer.TabIndex = 61;
            this.pbTimer.TabStop = false;
            // 
            // pbQuest
            // 
            this.pbQuest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbQuest.Location = new System.Drawing.Point(179, 4);
            this.pbQuest.Name = "pbQuest";
            this.pbQuest.Size = new System.Drawing.Size(556, 137);
            this.pbQuest.TabIndex = 60;
            this.pbQuest.TabStop = false;
            // 
            // pn
            // 
            this.pn.AutoScroll = true;
            this.pn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pn.Controls.Add(this.pb);
            this.pn.Location = new System.Drawing.Point(5, 148);
            this.pn.Name = "pn";
            this.pn.Size = new System.Drawing.Size(731, 442);
            this.pn.TabIndex = 59;
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(3, 3);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(100, 100);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb.TabIndex = 0;
            this.pb.TabStop = false;
            // 
            // btnAnswer
            // 
            this.btnAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAnswer.Image = ((System.Drawing.Image)(resources.GetObject("btnAnswer.Image")));
            this.btnAnswer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnswer.Location = new System.Drawing.Point(11, 98);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(162, 37);
            this.btnAnswer.TabIndex = 58;
            this.btnAnswer.Text = "Відповідь";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // txtAnswer
            // 
            this.txtAnswer.BackColor = System.Drawing.SystemColors.Info;
            this.txtAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAnswer.ForeColor = System.Drawing.Color.Blue;
            this.txtAnswer.Location = new System.Drawing.Point(11, 66);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(162, 26);
            this.txtAnswer.TabIndex = 57;
            // 
            // lbAnswer
            // 
            this.lbAnswer.AutoSize = true;
            this.lbAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAnswer.Location = new System.Drawing.Point(8, 48);
            this.lbAnswer.Name = "lbAnswer";
            this.lbAnswer.Size = new System.Drawing.Size(124, 17);
            this.lbAnswer.TabIndex = 56;
            this.lbAnswer.Text = "Введіть відповідь:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 138);
            this.panel1.TabIndex = 62;
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(620, 596);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 39);
            this.btnSave.TabIndex = 63;
            this.btnSave.Text = "Зберегти";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // timeTXT
            // 
            this.timeTXT.Interval = 1000;
            this.timeTXT.Tick += new System.EventHandler(this.timeTXT_Tick);
            // 
            // zadachiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 631);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnQuest);
            this.Controls.Add(this.pbTimer);
            this.Controls.Add(this.pbQuest);
            this.Controls.Add(this.pn);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.lbAnswer);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "zadachiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тестування";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.zadachiForm_FormClosed);
            this.Load += new System.EventHandler(this.zadachiForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuest)).EndInit();
            this.pn.ResumeLayout(false);
            this.pn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuest;
        private System.Windows.Forms.PictureBox pbTimer;
        private System.Windows.Forms.PictureBox pbQuest;
        private System.Windows.Forms.Panel pn;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Label lbAnswer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Timer timeTXT;
    }
}