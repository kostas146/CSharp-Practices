﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConwayGameOfLife
{
  public partial class Form1 : Form
  {
        private ConwayGameOfLife game = new ConwayGameOfLife();

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      // create a game
      game.lifeBehaviour = new StandardLife();
      SetMsgBox("Standard Life");

      // start the timer
      timer1.Enabled = true;

      this.DoubleBuffered = true;
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
      game.Draw(e.Graphics);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      game.Evolve();
      this.Refresh();
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      this.game.Reset();
    }
     public void SetMsgBox(string type)
     { 
       lbl_currentlf.Text = "Current Life Form: " + type;
     }

        private void btnChangeLife_Click(object sender, EventArgs e)
        {
            this.game.Reset();
            if (game.lifeBehaviour is StandardLife)
            {
                SetMsgBox("High Life");
                game.lifeBehaviour = new HighLife();
            }
            else
            {
                SetMsgBox("Standard Life");
                game.lifeBehaviour = new StandardLife();
            }
        }

    }
}