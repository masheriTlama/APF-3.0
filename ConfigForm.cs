using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace APF_3._0
{
    public partial class ConfigForm : Form
    {
        Dictionary<string, string> config = new Dictionary<string, string>();

        public ConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            config = NactiConfig();

            NactiDataGrid();
        }

        /// <summary>
        /// Načte data configu
        /// </summary>
        /// <returns>Config</returns>
        private Dictionary<string, string> NactiConfig()
        {
            StreamReader sr = new StreamReader("config.json");
            Dictionary<string, string> toReturn = JsonSerializer.Deserialize<Dictionary<string, string>>(sr.ReadToEnd());
            sr.Close();

            return toReturn;
        }

        /// <summary>
        /// Načte dataGrid - pokud jsem tohle nepředělal a někdo to vidí, tak se omlouvám
        /// </summary>
        private void NactiDataGrid()
        {
            string[,] headeryATipy = new string[7, 2]
            {
                { "Pauza", "Soubor, který se přehraje mezi filmy, ideálně obrázek" },
                { "Parent složka", "Složka na lokálním zařízení, kde jsou uloženy všechny filmy" },
                { "Databáze HTML", "Odkaz na HTML soubor komunikace s databází" },
                { "Databáze JSON", "Odkaz na JSON soubor komunikace s databází" },
                { "Max Levenshtein", "Slouží k porovnání názvu filmu v databázi a na lokálním zařízení (celé číslo)" },
                { "Čas mezi spoty", "Délka pauzy mezi jednotlivými spoty (číslo)" },
                { "Čekání na přepnutí", "Zvyšte tuto hodnotu, pokud nefunguje skákání do rozjetého programu (číslo)" }
            };

            IEnumerator<string> klic = KlicConfigu();

            for (int i = 0; i < headeryATipy.GetLength(0); i++)
            {
                klic.MoveNext();
                configDataGrid.Rows.Add(headeryATipy[i, 0], config[klic.Current]);
                configDataGrid.Rows[i].Cells[0].ToolTipText = headeryATipy[i, 1];
                configDataGrid.Rows[i].HeaderCell.Value = klic.Current;
            }
        }

        /// <summary>
        /// Postupně dávkuje klíče configu
        /// </summary>
        /// <returns>Klíče configu</returns>
        private IEnumerator<string> KlicConfigu()
        {
            foreach (string key in config.Keys)
            {
                yield return key;
            }
        }

        /// <summary>
        /// Uložení configu event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ulozitConfigButton_Click(object sender, EventArgs e)
        {
            if (!JsouDataValidni()) { return; }

            UlozData();

            ZavriConfigForm();
        }

        /// <summary>
        /// Uloží config do souboru
        /// </summary>
        private void UlozData()
        {
            config.Clear();

            for (int i = 0; i < configDataGrid.Rows.Count; i++)
            {
                config.Add(configDataGrid.Rows[i].HeaderCell.Value.ToString(), configDataGrid.Rows[i].Cells[1].Value.ToString());
            }

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            StreamWriter sw = new StreamWriter("config.json");
            sw.WriteLine(JsonSerializer.Serialize(config, options));
            sw.Close();
        }

        /// <summary>
        /// Zavírání formy event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Přejete si zavřít konfiguraci bez uložení dat?", "Neuložená data", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            e.Cancel = result == DialogResult.No;
        }

        /// <summary>
        /// DataGrid double Click (editace nějakého záznamu) event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void configDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (configDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("Pauza"))
            {
                VyberPauzu();
            }
            
            if (configDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("Parent složka"))
            {
                VyberParentFolder();
            }
        }

        /// <summary>
        /// File dialog na vybrání pauzy
        /// </summary>
        private void VyberPauzu()
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "Media files (*.avi *.mov *.mp4 *.mkv *.jpg *.jpeg *.png)|" +
                "*.avi;*.mov;*.mp4;*.mkv;*.jpg;*.jpeg;*.png|" +
                "Any files|*.*"
            };

            if (dlg.ShowDialog() != DialogResult.OK) { return; }

            //config["pauzaSouborCesta"] = dlg.FileName;
            configDataGrid.Rows[0].Cells["Hodnota"].Value = dlg.FileName;
        }

        /// <summary>
        /// Folder dialog na vybrání parent složky
        /// </summary>
        private void VyberParentFolder()
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            if (dlg.ShowDialog() != DialogResult.OK) { return; }

            //config["parentCesta"] = dlg.SelectedPath;
            configDataGrid.Rows[1].Cells["Hodnota"].Value = dlg.SelectedPath;            
        }

        /// <summary>
        /// Zavře formu
        /// </summary>
        private void ZavriConfigForm()
        {
            this.FormClosing -= ConfigForm_FormClosing;
            this.Close();
        }

        /// <summary>
        /// Kontroluje validitu všech dat dataGridu
        /// </summary>
        /// <returns>Zda jsou data validní</returns>
        private bool JsouDataValidni()
        {
            configDataGrid.Rows[6].Cells[1].Value = configDataGrid.Rows[6].Cells[1].Value.ToString().Replace(".", ",");

            if (!File.Exists(configDataGrid.Rows[0].Cells[1].Value.ToString())) { VyhodMessageBox("Soubor pauzy nenalezen"); }
            else if (!Directory.Exists(configDataGrid.Rows[1].Cells[1].Value.ToString())) { VyhodMessageBox("Parent folder nenalezen"); }
            else if (!Regex.IsMatch(configDataGrid.Rows[2].Cells[1].Value.ToString(), @"^(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?\.php$")) { VyhodMessageBox("Neplatná URL databáze (HTML)"); }
            else if (!Regex.IsMatch(configDataGrid.Rows[3].Cells[1].Value.ToString(), @"^(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?\.json$")) { VyhodMessageBox("Neplatná URL databáze (JSON)"); }
            else if (!Regex.IsMatch(configDataGrid.Rows[4].Cells[1].Value.ToString(), @"^\d+$")) { VyhodMessageBox("Neplatný Levenshtein"); }
            else if (!Regex.IsMatch(configDataGrid.Rows[5].Cells[1].Value.ToString(), @"^\d+(\.\d+)?$")) { VyhodMessageBox("Neplatný čas mezi spoty"); }
            else if (!Regex.IsMatch(configDataGrid.Rows[6].Cells[1].Value.ToString(), @"^\d+(,\d+)?$")) { VyhodMessageBox("Neplatné čekání na přepnutí"); }
            else { return true; }

            return false;
        }

        /// <summary>
        /// Ukáže message box s chybou
        /// </summary>
        /// <param name="text"></param>
        private void VyhodMessageBox(string text)
        {
            MessageBox.Show(text, "Neplatná data", MessageBoxButtons.OK);
        }
    }
}