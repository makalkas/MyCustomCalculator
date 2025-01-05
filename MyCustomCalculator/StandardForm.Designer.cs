namespace MyCustomCalculator
{
    partial class StandardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StandardForm));
            this.button1 = new System.Windows.Forms.Button();
            this.PercentBtn = new System.Windows.Forms.Button();
            this.RecipricalButton = new System.Windows.Forms.Button();
            this.button_7 = new System.Windows.Forms.Button();
            this.button_4 = new System.Windows.Forms.Button();
            this.button_1 = new System.Windows.Forms.Button();
            this.button_2 = new System.Windows.Forms.Button();
            this.button_5 = new System.Windows.Forms.Button();
            this.button_8 = new System.Windows.Forms.Button();
            this.SquaredButton = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button_0 = new System.Windows.Forms.Button();
            this.button_3 = new System.Windows.Forms.Button();
            this.button_6 = new System.Windows.Forms.Button();
            this.button_9 = new System.Windows.Forms.Button();
            this.SqrRootButton = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.EqualsButton = new System.Windows.Forms.Button();
            this.NumberDisplay = new System.Windows.Forms.TextBox();
            this.CurrentCalculation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(13, 437);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 56);
            this.button1.TabIndex = 0;
            this.button1.Text = "±";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ChangeSignClick);
            // 
            // PercentBtn
            // 
            this.PercentBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PercentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PercentBtn.Location = new System.Drawing.Point(13, 127);
            this.PercentBtn.Name = "PercentBtn";
            this.PercentBtn.Size = new System.Drawing.Size(124, 56);
            this.PercentBtn.TabIndex = 2;
            this.PercentBtn.Text = "%";
            this.PercentBtn.UseVisualStyleBackColor = false;
            this.PercentBtn.Click += new System.EventHandler(this.PercentBtn_Click);
            // 
            // RecipricalButton
            // 
            this.RecipricalButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RecipricalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecipricalButton.Location = new System.Drawing.Point(13, 189);
            this.RecipricalButton.Name = "RecipricalButton";
            this.RecipricalButton.Size = new System.Drawing.Size(124, 56);
            this.RecipricalButton.TabIndex = 3;
            this.RecipricalButton.Text = "1∕x";
            this.RecipricalButton.UseVisualStyleBackColor = false;
            this.RecipricalButton.Click += new System.EventHandler(this.RecipricalButton_Click);
            // 
            // button_7
            // 
            this.button_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_7.Location = new System.Drawing.Point(13, 251);
            this.button_7.Name = "button_7";
            this.button_7.Size = new System.Drawing.Size(124, 56);
            this.button_7.TabIndex = 4;
            this.button_7.Text = "7";
            this.button_7.UseVisualStyleBackColor = true;
            this.button_7.Click += new System.EventHandler(this.NumberSelectedClick);
            // 
            // button_4
            // 
            this.button_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_4.Location = new System.Drawing.Point(13, 313);
            this.button_4.Name = "button_4";
            this.button_4.Size = new System.Drawing.Size(124, 56);
            this.button_4.TabIndex = 5;
            this.button_4.Text = "4";
            this.button_4.UseVisualStyleBackColor = true;
            this.button_4.Click += new System.EventHandler(this.NumberSelectedClick);
            // 
            // button_1
            // 
            this.button_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_1.Location = new System.Drawing.Point(13, 375);
            this.button_1.Name = "button_1";
            this.button_1.Size = new System.Drawing.Size(124, 56);
            this.button_1.TabIndex = 6;
            this.button_1.Text = "1";
            this.button_1.UseVisualStyleBackColor = true;
            this.button_1.Click += new System.EventHandler(this.NumberSelectedClick);
            // 
            // button_2
            // 
            this.button_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_2.Location = new System.Drawing.Point(143, 375);
            this.button_2.Name = "button_2";
            this.button_2.Size = new System.Drawing.Size(124, 56);
            this.button_2.TabIndex = 12;
            this.button_2.Text = "2";
            this.button_2.UseVisualStyleBackColor = true;
            this.button_2.Click += new System.EventHandler(this.NumberSelectedClick);
            // 
            // button_5
            // 
            this.button_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_5.Location = new System.Drawing.Point(143, 313);
            this.button_5.Name = "button_5";
            this.button_5.Size = new System.Drawing.Size(124, 56);
            this.button_5.TabIndex = 11;
            this.button_5.Text = "5";
            this.button_5.UseVisualStyleBackColor = true;
            this.button_5.Click += new System.EventHandler(this.NumberSelectedClick);
            // 
            // button_8
            // 
            this.button_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_8.Location = new System.Drawing.Point(143, 251);
            this.button_8.Name = "button_8";
            this.button_8.Size = new System.Drawing.Size(124, 56);
            this.button_8.TabIndex = 10;
            this.button_8.Text = "8";
            this.button_8.UseVisualStyleBackColor = true;
            this.button_8.Click += new System.EventHandler(this.NumberSelectedClick);
            // 
            // SquaredButton
            // 
            this.SquaredButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SquaredButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SquaredButton.Location = new System.Drawing.Point(143, 189);
            this.SquaredButton.Name = "SquaredButton";
            this.SquaredButton.Size = new System.Drawing.Size(124, 56);
            this.SquaredButton.TabIndex = 9;
            this.SquaredButton.Text = "x²";
            this.SquaredButton.UseVisualStyleBackColor = false;
            this.SquaredButton.Click += new System.EventHandler(this.SquaredButton_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(143, 127);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(124, 56);
            this.button11.TabIndex = 8;
            this.button11.Text = "CE";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.ClearEverything);
            // 
            // button_0
            // 
            this.button_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_0.Location = new System.Drawing.Point(143, 437);
            this.button_0.Name = "button_0";
            this.button_0.Size = new System.Drawing.Size(124, 56);
            this.button_0.TabIndex = 7;
            this.button_0.Text = "0";
            this.button_0.UseVisualStyleBackColor = true;
            this.button_0.Click += new System.EventHandler(this.NumberSelectedClick);
            // 
            // button_3
            // 
            this.button_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_3.Location = new System.Drawing.Point(273, 375);
            this.button_3.Name = "button_3";
            this.button_3.Size = new System.Drawing.Size(124, 56);
            this.button_3.TabIndex = 18;
            this.button_3.Text = "3";
            this.button_3.UseVisualStyleBackColor = true;
            this.button_3.Click += new System.EventHandler(this.NumberSelectedClick);
            // 
            // button_6
            // 
            this.button_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_6.Location = new System.Drawing.Point(273, 313);
            this.button_6.Name = "button_6";
            this.button_6.Size = new System.Drawing.Size(124, 56);
            this.button_6.TabIndex = 17;
            this.button_6.Text = "6";
            this.button_6.UseVisualStyleBackColor = true;
            this.button_6.Click += new System.EventHandler(this.NumberSelectedClick);
            // 
            // button_9
            // 
            this.button_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_9.Location = new System.Drawing.Point(273, 251);
            this.button_9.Name = "button_9";
            this.button_9.Size = new System.Drawing.Size(124, 56);
            this.button_9.TabIndex = 16;
            this.button_9.Text = "9";
            this.button_9.UseVisualStyleBackColor = true;
            this.button_9.Click += new System.EventHandler(this.NumberSelectedClick);
            // 
            // SqrRootButton
            // 
            this.SqrRootButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SqrRootButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SqrRootButton.Location = new System.Drawing.Point(273, 189);
            this.SqrRootButton.Name = "SqrRootButton";
            this.SqrRootButton.Size = new System.Drawing.Size(124, 56);
            this.SqrRootButton.TabIndex = 15;
            this.SqrRootButton.Text = "²√x";
            this.SqrRootButton.UseVisualStyleBackColor = false;
            this.SqrRootButton.Click += new System.EventHandler(this.SqrRootButton_Click);
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button17.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button17.Location = new System.Drawing.Point(273, 127);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(124, 56);
            this.button17.TabIndex = 14;
            this.button17.Text = "C";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.Clear);
            // 
            // button18
            // 
            this.button18.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button18.Location = new System.Drawing.Point(273, 437);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(124, 56);
            this.button18.TabIndex = 13;
            this.button18.Text = ".";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.AddDecimal);
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button19.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button19.Location = new System.Drawing.Point(403, 375);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(124, 56);
            this.button19.TabIndex = 24;
            this.button19.Text = "+";
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.OperationClick);
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button20.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.Location = new System.Drawing.Point(403, 313);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(124, 56);
            this.button20.TabIndex = 23;
            this.button20.Text = "-";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.OperationClick);
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button21.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button21.Location = new System.Drawing.Point(403, 251);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(124, 56);
            this.button21.TabIndex = 22;
            this.button21.Text = "X";
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Click += new System.EventHandler(this.OperationClick);
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button22.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button22.Location = new System.Drawing.Point(403, 189);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(124, 56);
            this.button22.TabIndex = 21;
            this.button22.Text = "÷";
            this.button22.UseVisualStyleBackColor = false;
            this.button22.Click += new System.EventHandler(this.OperationClick);
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button23.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button23.Location = new System.Drawing.Point(403, 127);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(124, 56);
            this.button23.TabIndex = 20;
            this.button23.Text = "←";
            this.button23.UseVisualStyleBackColor = false;
            this.button23.Click += new System.EventHandler(this.BackSpace);
            // 
            // EqualsButton
            // 
            this.EqualsButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.EqualsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EqualsButton.Location = new System.Drawing.Point(403, 437);
            this.EqualsButton.Name = "EqualsButton";
            this.EqualsButton.Size = new System.Drawing.Size(124, 56);
            this.EqualsButton.TabIndex = 19;
            this.EqualsButton.Text = "=";
            this.EqualsButton.UseVisualStyleBackColor = false;
            this.EqualsButton.Click += new System.EventHandler(this.EqualsButton_Click);
            // 
            // NumberDisplay
            // 
            this.NumberDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NumberDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberDisplay.Location = new System.Drawing.Point(17, 49);
            this.NumberDisplay.MinimumSize = new System.Drawing.Size(400, 50);
            this.NumberDisplay.Name = "NumberDisplay";
            this.NumberDisplay.Size = new System.Drawing.Size(510, 43);
            this.NumberDisplay.TabIndex = 25;
            this.NumberDisplay.Text = "0";
            this.NumberDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CurrentCalculation
            // 
            this.CurrentCalculation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentCalculation.Location = new System.Drawing.Point(17, 15);
            this.CurrentCalculation.MinimumSize = new System.Drawing.Size(510, 20);
            this.CurrentCalculation.Name = "CurrentCalculation";
            this.CurrentCalculation.Size = new System.Drawing.Size(510, 23);
            this.CurrentCalculation.TabIndex = 26;
            this.CurrentCalculation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StandardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 514);
            this.Controls.Add(this.CurrentCalculation);
            this.Controls.Add(this.NumberDisplay);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.EqualsButton);
            this.Controls.Add(this.button_3);
            this.Controls.Add(this.button_6);
            this.Controls.Add(this.button_9);
            this.Controls.Add(this.SqrRootButton);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button_2);
            this.Controls.Add(this.button_5);
            this.Controls.Add(this.button_8);
            this.Controls.Add(this.SquaredButton);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button_0);
            this.Controls.Add(this.button_1);
            this.Controls.Add(this.button_4);
            this.Controls.Add(this.button_7);
            this.Controls.Add(this.RecipricalButton);
            this.Controls.Add(this.PercentBtn);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StandardForm";
            this.Text = "Custom Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button PercentBtn;
        private System.Windows.Forms.Button RecipricalButton;
        private System.Windows.Forms.Button button_7;
        private System.Windows.Forms.Button button_4;
        private System.Windows.Forms.Button button_1;
        private System.Windows.Forms.Button button_2;
        private System.Windows.Forms.Button button_5;
        private System.Windows.Forms.Button button_8;
        private System.Windows.Forms.Button SquaredButton;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button_0;
        private System.Windows.Forms.Button button_3;
        private System.Windows.Forms.Button button_6;
        private System.Windows.Forms.Button button_9;
        private System.Windows.Forms.Button SqrRootButton;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button EqualsButton;
        private System.Windows.Forms.TextBox NumberDisplay;
        private System.Windows.Forms.Label CurrentCalculation;
    }
}

