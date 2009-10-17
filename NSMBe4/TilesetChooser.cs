﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NSMBe4
{
    public partial class TilesetChooser : Form
    {
        NitroClass ROM;
        public TilesetChooser(NitroClass ROM)
        {
            InitializeComponent();
            LanguageManager.ApplyToContainer(this, "TilesetChooser");

            this.ROM = ROM;

            // Add tilesets to list
            int index = 0;
            string[] parsedlist = new string[76];
            foreach (string name in LanguageManager.GetList("Tilesets")) {
                string trimmedname = name.Trim();
                if (trimmedname == "") continue;
                parsedlist[index] = trimmedname;
                index += 1;
            }

            tilesetComboBox.Items.AddRange(parsedlist);
        }

        private void editJyotyuButton_Click(object sender, EventArgs e) {
            new TilesetEditor(ROM, 65535, "Jyotyu").Show();
            Close();
        }

        private void openTilesetButton_Click(object sender, EventArgs e) {
            new TilesetEditor(ROM, (ushort)tilesetComboBox.SelectedIndex, (string)tilesetComboBox.SelectedItem).Show();
            Close();
        }
    }
}