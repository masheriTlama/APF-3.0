using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Net;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Text;

namespace APF_3._0
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> config;
        Dictionary<string, Film> filmy;
        LibVLC LibVLC;
        MediaPlayer mediaPlayer;
        List<string> foldery = new List<string>();
        List<string[]> CistaAPuvodniJmenaList = new List<string[]>();
        bool probehlaEditace = false;
        IEnumerator<string> playlist;
        Ovladani ovladani;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Inicializace();
            ZapisDoDataGridu(false);
        }

        /* INICIALIZACE */

        /// <summary>
        /// Inicializuje veřejné proměnné, vytvoří LibVLC objekt
        /// </summary>
        public void Inicializace()
        {
            config = NactiConfig();

            filmy = NactiFilmy();

            LibVLC = new LibVLC();
            mediaPlayer = new MediaPlayer(LibVLC)
            {
                Media = new Media(LibVLC, config["pauzaSouborCesta"], FromType.FromPath),
                Fullscreen = true,       
            };

            mediaPlayer.EndReached += (sender, args) => ThreadPool.QueueUserWorkItem(_ => DalsiFilm());

            VycistiKomunikacniLabel();

            NajdiFolderyFilmu(config["parentFolder"]);

            CistaAPuvodniJmenaList = CistaAPuvodniJmena();

            ovladani = new Ovladani(mediaPlayer, this.Width, this.Height);
        }

        /// <summary>
        /// Načte config data ze souboru
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
        /// Načte filmy ze souboru
        /// </summary>
        /// <returns>Všechny filmy</returns>
        private Dictionary<string, Film> NactiFilmy()
        {
            StreamReader sr = new StreamReader("zaznam.json");
            Dictionary<string, Film> toReturn = JsonSerializer.Deserialize<Dictionary<string, Film>>(sr.ReadToEnd());
            sr.Close();

            return toReturn;
        }

        /// <summary>
        /// Vyčistí komunikační label a doplní default hodnotu
        /// </summary>
        private void VycistiKomunikacniLabel()
        {
            komunikacniLabel.Text = "Info:\n";
        }

        /// <summary>
        /// Najde všechny foldery
        /// </summary>
        /// <param name="parentCesta"></param>
        private void NajdiFolderyFilmu(string parentCesta)
        {
            if (!Directory.Exists(config["parentFolder"])) { return; }
            if (parentCesta.Length < 4)
            {
                komunikacniLabel.Text += "Není doporučováno používat celý disk jako parent folder - může dojít k neošetřeným výjimkám\n";
            }

            foldery.Clear();

            foldery.Add(parentCesta);
            NajdiSubFoldery(config["parentFolder"]);
        }

        /// <summary>
        /// Najde všechny subfoldery parent folderu
        /// </summary>
        /// <param name="parentCesta"></param>
        private void NajdiSubFoldery(string parentCesta)
        {
            if (foldery.Count > 3006)
            {
                if (!komunikacniLabel.Text.Contains("očekávaný timeout"))
                {
                    komunikacniLabel.Text += "Nelze najít všechny lokální subfoldery - očekávaný timeout\nVyberte konkrétnější parent folder\n";
                }

                return;
            }

            List<string> directories = GetDirectories(parentCesta);

            for (int i = 0; i < directories.Count; i++)
            {
                string dir = directories[i].ToLower();
                if (dir.Contains("recycle")
                    || dir.Contains("system volume")
                    || dir.Contains("documents and settings")
                    || dir.Contains("intel")
                    || dir.Contains("windows")
                    ) { continue; }

                foldery.Add(directories[i]);
                NajdiSubFoldery(directories[i]);
            }
        }

        /// <summary>
        /// Najde subfoldery, handluje UnauthorizedAccessException
        /// </summary>
        /// <param name="cesta"></param>
        /// <returns></returns>
        private static List<string> GetDirectories(string cesta)
        {
            try
            {
                return Directory.GetDirectories(cesta).ToList();
            }
            catch (UnauthorizedAccessException)
            {
                return new List<string>();
            }
        }

        /// <summary>
        /// Vytvoři list sanitizovaných a puvodních jmen všech filmů na lokálním zařízení
        /// </summary>
        /// <returns>List<string, string> [0] - sanitizované, [1] - původní jméno</returns>
        private List<string[]> CistaAPuvodniJmena()
        {
            FileInfo[] filesInDir;
            List<string[]> nalezeneSoubory = new List<string[]>();

            foreach (string f in foldery)
            {
                filesInDir = new DirectoryInfo(f).GetFiles("*");
                foreach (var s in filesInDir)
                {
                    nalezeneSoubory.Add(new string[] { Cistka(s.ToString()), s.ToString() });
                }
            }

            return nalezeneSoubory;
        }

        /// <summary>
        /// Vyčistí string
        /// </summary>
        /// <param name="puvodni"></param>
        /// <returns></returns>
        private string Cistka(string puvodni)
        {
            return Encoding.UTF8.GetString(Encoding.GetEncoding("ISO-8859-8").GetBytes(puvodni)).Replace(" ", "").ToLower();
        }

        /* PŘEHRÁVÁNÍ */

        /// <summary>
        /// Přehraje další film v programu
        /// </summary>
        private async void DalsiFilm()
        {            
            // najde dalsi film v playlistu
            playlist.MoveNext();

            // pauza
            mediaPlayer.Media = new Media(LibVLC, config["pauzaSouborCesta"], FromType.FromPath);
            mediaPlayer.Play();
            await Task.Run(() => Cekej(Convert.ToDouble(config["cekaniNaPrepnuti"])));
            mediaPlayer.Pause();

            if (playlist.Current == "posledniPauza") { return; } //TODO posledni pauza

            // cekani na zacatek filmu
            await Task.Run(() => Cekej(filmy[playlist.Current].zacatek - AktualniCas()));

            // film
            mediaPlayer.Media = new Media(LibVLC, filmy[playlist.Current].cesta, FromType.FromPath);
            mediaPlayer.Play();

            await Task.Run(() => Cekej(Convert.ToDouble(config["cekaniNaPrepnuti"])));

            // skoceni do prehravaneho filmu
            mediaPlayer.Position = ((float)AktualniCas() - filmy[playlist.Current].zacatek) * 1000 / mediaPlayer.Media.Duration;
        }

        /// <summary>
        /// Najde nejdřívější film pro přehrání
        /// </summary>
        /// <returns>Klíč souboru</returns>
        private IEnumerator<string> NejdrivejsiFilm()
        {
            for (int i = 0; i < spotyDataGrid.RowCount - 1; i++)
            {
                yield return $"spot{i}";
            }

            for (int i = 0; i < filmyDataGrid.RowCount - 1; i++)
            {
                yield return $"film{i}";
            }

            yield return "posledniPauza";
        }

        /// <summary>
        /// Počká
        /// </summary>
        /// <param name="cas"></param>
        private void Cekej(int cas)
        {
            Cekej((double)cas);
        }

        /// <summary>
        /// Počka, ale v intu
        /// </summary>
        /// <param name="cas"></param>
        private void Cekej(double cas)
        {
            if (cas < 0) { return; }

            Thread.Sleep((int)(cas * 1000));
        }

        /// <summary>
        /// Vrátí momentální čas v sekundách od půlnoci
        /// </summary>
        /// <returns></returns>
        private int AktualniCas()
        {
            DateTime dt = DateTime.Now;
            return dt.Hour * 3600 + dt.Minute * 60 + dt.Second;
        }

        /// <summary>
        /// Start přehrávání event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startButton_Click(object sender, EventArgs e)
        {
            UlozZaznam();

            if (!TestFilmu()) { return; }

            playlist = NejdrivejsiFilm();
            DalsiFilm();

            this.Opacity = 0;
        }

        /// <summary>
        /// Otestuje všechny filmy v programu
        /// </summary>
        /// <returns>Zda jsou cesty všech filmů platné</returns>
        private bool TestFilmu()
        {
            VycistiKomunikacniLabel();
            bool vseOk = true;

            foreach (string key in filmy.Keys)
            {
                if (!File.Exists(filmy[key].cesta))
                {
                    komunikacniLabel.Text += $"Film „{filmy[key].cesta}“ nebyl nalezen\n";
                    vseOk = false;
                }
            }

            if (!File.Exists(config["pauzaSouborCesta"]))
            {
                komunikacniLabel.Text += $"Pauza „{config["pauzaSouborCesta"]}“ nebyla nalezena\n";
                vseOk = false;
            }

            if (vseOk)
            {
                VycistiKomunikacniLabel();
                komunikacniLabel.Text = "Vše v pořádku\n";
            }

            return vseOk;
        }

        /* UI */

        /// <summary>
        /// Přepíše datagridy
        /// </summary>
        /// <param name="editace"></param>
        private void ZapisDoDataGridu(bool manualniEditace)
        {
            if (manualniEditace) { probehlaEditace = true; }

            spotyDataGrid.Rows.Clear();
            filmyDataGrid.Rows.Clear();

            foreach (string key in filmy.Keys)
            {
                if (key.Contains("spot"))
                {
                    spotyDataGrid.Rows.Add("-", Path.GetFileName(filmy[key].cesta), PrevedNaHHMMSS(filmy[key].zacatek), PrevedNaHHMMSS(filmy[key].konec));
                    spotyDataGrid.Rows[spotyDataGrid.RowCount - 2].HeaderCell.Value = key;
                }
                if (key.Contains("film"))
                {
                    filmyDataGrid.Rows.Add("-", Path.GetFileName(filmy[key].cesta), PrevedNaHHMMSS(filmy[key].zacatek), PrevedNaHHMMSS(filmy[key].konec));
                    filmyDataGrid.Rows[filmyDataGrid.RowCount - 2].HeaderCell.Value = key;
                }
            }
        }

        /// <summary>
        /// Kliknutí na buňku datagridu event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spotyDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(((DataGridView)sender).Columns[e.ColumnIndex] is DataGridViewButtonColumn)) { return; }
            if (e.RowIndex < 0 || (e.RowIndex >= (((DataGridView)sender).RowCount - 1) && e.ColumnIndex != 1)) { return; }

            if (e.ColumnIndex == 0) // odeber film
            {
                SmazFilm(((DataGridView)sender).Rows[e.RowIndex].HeaderCell.Value.ToString());
            }
            else if (e.ColumnIndex == 1) // vyber film
            {
                VyberFilm(((DataGridView)sender).Name, e.RowIndex);
            }
        }

        /// <summary>
        /// Kliknutí na buňku datagridu event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filmyDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            spotyDataGrid_CellContentClick(sender, e);
        }

        /// <summary>
        /// Otevře dialog pro výběr filmu
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <param name="row"></param>
        private void VyberFilm(string dataGrid, int row)
        {
            //TODO double fire protect

            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "Media files (*.avi *.mov *.mp4 *.mkv *.jpg *.jpeg *.png)|" +
                "*.avi;*.mov;*.mp4;*.mkv;*.jpg;*.jpeg;*.png|" +
                "Any files|*.*"
            };

            if (dlg.ShowDialog() != DialogResult.OK) { return; }

            string key = dataGrid == "spotyDataGrid" ? $"spot{row}" : $"film{row}";

            if (!filmy.ContainsKey(key))
            {
                filmy.Add(key, new Film());
            }

            filmy[key].cesta = dlg.FileName;
            filmy[key].konec = filmy[key].zacatek + ZiskejDelkuSouboruS(filmy[key].cesta);

            ZapisDoDataGridu(true);

            if (key.Contains("spot"))
            {
                DopocitejPrechodSpotuAFilmu();
            }

            ZapisDoDataGridu(true);

            //TODO chekni, jestli klic v DopocitejPrechodSpotuAFilmu je nekdy film
        }

        /// <summary>
        /// Smaže film z programu
        /// </summary>
        /// <param name="klic"></param>
        private void SmazFilm(string klic)
        {
            filmy.Remove(klic);

            ZapisDoDataGridu(true);

            PrepocitejKliceFilmu();

            DopocitejPrechodSpotuAFilmu();

            ZapisDoDataGridu(true);
        }

        /// <summary>
        /// Přepočítá kódy filmů a spotů, aby tam nebyla mezera při mazání
        /// </summary>
        private void PrepocitejKliceFilmu()
        {
            for (int i = 0; i < filmy.Count; i++)
            {
                if (!filmy.ContainsKey($"spot{i}") && filmy.ContainsKey($"spot{i + 1}"))
                {
                    filmy.Add($"spot{i}", filmy[$"spot{i + 1}"]);
                    filmy.Remove($"spot{i + 1}");
                }

                if (!filmy.ContainsKey($"film{i}") && filmy.ContainsKey($"film{i + 1}"))
                {
                    filmy.Add($"film{i}", filmy[$"film{i + 1}"]);
                    filmy.Remove($"film{i + 1}");
                }
            }
        }

        /// <summary>
        /// Dopočítá přechod spotů a filmů
        /// </summary>
        /// <param name="podlePrvnihoFilmu"></param>
        private void DopocitejPrechodSpotuAFilmu()
        {
            if (!filmy.ContainsKey("spot0")) { return; }

            // TODO asi by to slo lip
            for (int i = 0; i < spotyDataGrid.RowCount - 1; i++)
            {
                filmy[$"spot{i}"].zacatek = (int)(i - 1 < 0 ? filmy[$"spot{i}"].zacatek : (filmy[$"spot{i - 1}"].konec + Convert.ToDouble(config["casMeziSpoty"])));
                filmy[$"spot{i}"].konec = filmy[$"spot{i}"].zacatek + ZiskejDelkuSouboruS(filmy[$"spot{i}"].cesta);
            }

            filmy["film0"].zacatek = (int)(filmy[NejpozdejsiSpot()].konec + Convert.ToDouble(config["casMeziSpoty"]));
            filmy["film0"].konec = filmy["film0"].zacatek + ZiskejDelkuSouboruS(filmy["film0"].cesta);
        }

        /// <summary>
        /// Najde nejpozdější spot v programu
        /// </summary>
        /// <returns></returns>
        private string NejpozdejsiSpot()
        {
            for (int i = filmy.Count - 1; i >= 0; i--)
            {
                if (filmy.ContainsKey($"spot{i}"))
                {
                    return $"spot{i}";
                }
            }
            return "NenalezenZadnySpot";
        }

        /// <summary>
        /// Editace buňky datagridu event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spotyDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            EditBunky($"spot{e.RowIndex}", (DataGridView)sender, e.RowIndex, e.ColumnIndex);
        }

        /// <summary>
        /// Editace buňky datagridu event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filmyDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            EditBunky($"film{e.RowIndex}", (DataGridView)sender, e.RowIndex, e.ColumnIndex);
        }

        private void EditBunky(string key, DataGridView dataGrid, int radek, int sloupec)
        {
            if (sloupec != 2) { return; }

            int zacatek = PrevedNaS(dataGrid.Rows[radek].Cells[sloupec].Value.ToString());
            filmy[key].zacatek = zacatek != 0 ? zacatek : filmy[key].zacatek;

            DopocitejPrechodSpotuAFilmu();

            filmy[key].konec = filmy[key].zacatek + ZiskejDelkuSouboruS(filmy[key].cesta); // TODO je tohle potreba ?

            ZapisDoDataGridu(true);
        }

        /// <summary>
        /// Získá délku souboru v sekundách
        /// </summary>
        /// <param name="cesta"></param>
        /// <returns>Délka souboru v sekundách</returns>
        private int ZiskejDelkuSouboruS(string cesta)
        {
            if (!File.Exists(cesta)) { return 0; }

            Media media = new Media(LibVLC, cesta);
            media.Parse();
            while (media.ParsedStatus != MediaParsedStatus.Done) Thread.Sleep(10);

            return (int)Math.Floor(media.Duration / 1000f);
        }

        /// <summary>
        /// Převede hh:mm:ss na čas v sekundách od půlnoci
        /// </summary>
        /// <param name="cas"></param>
        /// <returns></returns>
        private int PrevedNaS(string cas)
        {
            if (cas == "") { return 0; }
            if (!Regex.IsMatch(cas, @"^(-?\d{0,2})?(:|\/)?(-?\d{0,2})?(:|\/)?(-?\d{0,2})?(:|\/)?$")) { return 0; }

            int[] casy = { 0, 0, 0 };
            string[] casyS = cas.Split(':', '/');

            for (int i = 0; i < casyS.Length; i++)
            {
                casy[i] += casyS[i] == "" ? 0 : Convert.ToInt32(casyS[i]);
            }

            return casy[0] * 3600 + casy[1] * 60 + casy[2];
        }

        /// <summary>
        /// Převede z času od půlnoci na hh:mm:ss
        /// </summary>
        /// <param name="cas"></param>
        /// <returns></returns>
        private string PrevedNaHHMMSS(int cas)
        {
            int[] casy = new int[3];

            casy[0] = (int)Math.Floor(cas / 3600f);
            casy[1] = (int)Math.Floor((cas - casy[0] * 3600f) / 60);
            casy[2] = cas - casy[1] * 60 - casy[0] * 3600;

            return $"{casy[0].ToString("00")}:{casy[1].ToString("00")}:{casy[2].ToString("00")}";
        }

        /// <summary>
        /// Posun času event handler, posune všechny začátky filmů
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void posunCasuTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) { return; }
            e.SuppressKeyPress = true; // tlumeni default zvuku enteru

            int pricteneSekundy = PrevedNaS(posunCasuTextBox.Text);
            foreach (string key in filmy.Keys)
            {
                filmy[key].zacatek += pricteneSekundy;
                filmy[key].konec += pricteneSekundy;
            }

            ZapisDoDataGridu(true);
            posunCasuTextBox.Text = "";
        }

        /// <summary>
        /// Konfigurační forma dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void configButton_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm();
            configForm.ShowDialog();

            config = NactiConfig();
            NajdiFolderyFilmu(config["parentFolder"]);
            CistaAPuvodniJmenaList = CistaAPuvodniJmena();
        }

        /// <summary>
        /// Test filmů event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testFilmuButton_Click(object sender, EventArgs e)
        {
            TestFilmu();
        }

        /// <summary>
        /// Konec přehrávání event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void konecButton_Click(object sender, EventArgs e)
        {
            mediaPlayer.Stop();

            filmy = NactiFilmy();
        }

        /// <summary>
        /// Vyčistí komunikační label event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cisteniKomunikacnihoLabeluButton_Click(object sender, EventArgs e)
        {
            VycistiKomunikacniLabel();
        }

        /* PRÁCE S DATY */

        /// <summary>
        /// Ukládaní event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ulozitButton_Click(object sender, EventArgs e)
        {
            UlozZaznam();
        }

        /// <summary>
        /// Uloží filmy do souboru
        /// </summary>
        private void UlozZaznam()
        {
            // TODO kdy je ulozeno
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            StreamWriter sw = new StreamWriter("zaznam.json");
            sw.WriteLine(JsonSerializer.Serialize(filmy, options));
            sw.Close();
        }

        /// <summary>
        /// Zavíraní formy event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Ukončit aplikaci?", "Zkrontrolujte si uložení dat", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            e.Cancel = result == DialogResult.No;
        }

        /// <summary>
        /// Databáze fetch event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void databazeButton_Click(object sender, EventArgs e)
        {
            if (probehlaEditace)
            {
                DialogResult result = MessageBox.Show("Přejete si přepsat manuální změny?", "Proběhla editace záznamů", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.No) { return; }
            }

            if (!TestDBInputu()) { return; }

            filmy = ZiskejFilmyZDatabaze();

            DopocitejDataFilmu();

            ZapisDoDataGridu(false);

            probehlaEditace = false;

            //TODO spravne konce pri nacteni z db
        }

        /// <summary>
        /// Otestuje, zda třída a den databázového inputu jsou ve správném formátu
        /// </summary>
        /// <returns>true, pokud splňují podmínky, jinak false</returns>
        private bool TestDBInputu()
        {
            Regex regexTrida = new Regex(@"^(?:[IVX]{1,3}|VIII)\.$|^([1-4]\.(?:A|B))$");
            Regex regexDen = new Regex(@"^[123]");
            tridaDBTextBox.Text = tridaDBTextBox.Text.ToUpper();

            if (!regexDen.IsMatch(denDBTextBox.Text)) { return false; }

            if (!regexTrida.IsMatch(tridaDBTextBox.Text))
            {
                if (regexTrida.IsMatch($"{tridaDBTextBox.Text}."))
                {
                    tridaDBTextBox.Text += ".";
                    return true;
                }
                return false;
            }
            return true;
        }

        /// <summary>
        /// Získá filmy z databáze
        /// </summary>
        /// <returns>Filmy ve fomrátu Dictionary<string, Film></returns>
        private Dictionary<string, Film> ZiskejFilmyZDatabaze()
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest
                .Create($"{config["databazeUrlHTML"]}?den={denDBTextBox.Text}&trida={tridaDBTextBox.Text}");
            WebResponse data1 = myRequest.GetResponse();

            HttpWebRequest data = (HttpWebRequest)WebRequest.Create($"{config["databazeUrlJSON"]}");
            WebResponse data2 = data.GetResponse();

            StreamReader sr = new StreamReader(data2.GetResponseStream(), Encoding.UTF8);
            Dictionary<string, Film> toReturn = JsonSerializer.Deserialize<Dictionary<string, Film>>(sr.ReadToEnd());

            sr.Close();
            data1.Close();
            data2.Close();

            Dictionary<string, Film> toReturnSpoty = new Dictionary<string, Film>();
            foreach (string key in filmy.Keys)
            {
                if (key.Contains("spot"))
                {
                    toReturnSpoty.Add(key, filmy[key]);
                }
            }

            toReturn.ToList().ForEach(x => toReturnSpoty.Add(x.Key, x.Value));
            return toReturnSpoty;
        }

        /// <summary>
        /// Najde lokální cesty filmů a dopočítá přechod spotů a filmů
        /// </summary>
        public void DopocitejDataFilmu()
        {
            if (foldery.Count == 0)
            {
                komunikacniLabel.Text += "Folder s filmy nebyl nalezen\n";
            }

            foreach (string key in filmy.Keys)
            {
                if (key.Contains("film"))
                {
                    filmy[key].cesta = NajdiFilmLocal(Path.GetFileName(filmy[key].cesta), Convert.ToInt16(config["maxLevenshtein"]));
                }
            }

            DopocitejPrechodSpotuAFilmu();
        }

        /// <summary>
        /// Najde souboru na lokálním zařízení
        /// </summary>
        /// <param name="jmeno"></param>
        /// <param name="maxLevenshtein"></param>
        /// <returns>Cestu souboru</returns>
        private string NajdiFilmLocal(string jmeno, int maxLevenshtein)
        {
            FileInfo[] filesInDir;
            Dictionary<int, string> podobneNazvy = new Dictionary<int, string>();
            int nejmensiLevenshtein;

            string jmenoCiste = Cistka(jmeno);

            foreach (string[] arr in CistaAPuvodniJmenaList)
            {
                nejmensiLevenshtein = GetLevenshteinDistance(Path.GetFileNameWithoutExtension(arr[0]), jmenoCiste);
                if (nejmensiLevenshtein <= maxLevenshtein && !podobneNazvy.ContainsKey(nejmensiLevenshtein))
                {
                    podobneNazvy.Add(nejmensiLevenshtein, arr[1]);
                }
            }

            if (podobneNazvy.Count == 0)
            {
                if (maxLevenshtein == int.MaxValue)
                {
                    return SouborNenalezenUI(jmeno);
                }

                DialogResult result = MessageBox.Show($"Přejete si hledat s vyšším Levenshteinem?\nSoubor: „{jmeno}“\nLevenshtein: {config["maxLevenshtein"]}",
                    $"Soubor nenalezen - „{jmeno}“",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                // vybrat rucne
                if (result == DialogResult.Ignore)
                {
                    return DodatecnyVyberFilmu(jmeno);
                }

                // ano - hleda znova s vyssim levenshteinem
                if (result == DialogResult.Abort)
                {
                    return NajdiFilmLocal(jmeno, int.MaxValue);
                }

                // ne - ui update
                return SouborNenalezenUI(jmeno);
            }

            foreach (string f in foldery)
            {
                filesInDir = new DirectoryInfo(f).GetFiles("*" + podobneNazvy[podobneNazvy.Keys.Min()] + "*.*");
                if (filesInDir.Length > 0)
                {
                    komunikacniLabel.Text += $"Soubor: „{jmeno}“, Levenshtein: {podobneNazvy.Keys.Min()}\n";
                    return filesInDir[0].FullName;
                }
            }

            return SouborNenalezenUI(jmeno);
        }

        /// <summary>
        /// Manuální dodatečný výběr filmu
        /// </summary>
        /// <param name="jmeno"></param>
        /// <returns></returns>
        private string DodatecnyVyberFilmu(string jmeno)
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "Media files (*.avi *.mov *.mp4 *.mkv *.jpg *.jpeg *.png)|" +
                "*.avi;*.mov;*.mp4;*.mkv;*.jpg;*.jpeg;*.png|" +
                "Any files|*.*"
            };

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return SouborNenalezenUI(jmeno);
            }

            return dlg.FileName;
        }

        /// <summary>
        /// Varování o nenalezeném souboru
        /// </summary>
        /// <param name="jmeno"></param>
        /// <returns></returns>
        private string SouborNenalezenUI(string jmeno)
        {
            komunikacniLabel.Text += $"Pro „{jmeno}“ nebyl nalezen soubor. Vyberte ho manuálně.\n";
            return $"nenalezeno ({jmeno})";
        }

        /// <summary>
        /// GPT, zjistí počet změn jednoho stringu, aby byl změněn na druhý 
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns>Rozdílnost dvou stringů</returns>
        public static int GetLevenshteinDistance(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
            {
                return Math.Max(str1?.Length ?? 0, str2?.Length ?? 0);
            }

            int[,] d = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 0; i <= str1.Length; i++)
            {
                d[i, 0] = i;
            }

            for (int j = 0; j <= str2.Length; j++)
            {
                d[0, j] = j;
            }

            for (int j = 1; j <= str2.Length; j++)
            {
                for (int i = 1; i <= str1.Length; i++)
                {
                    int cost = (str1[i - 1] == str2[j - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(d[i - 1, j] + 1, // Deletion
                                      Math.Min(d[i, j - 1] + 1, // Insertion
                                               d[i - 1, j - 1] + cost)); // Substitution
                }
            }

            return d[str1.Length, str2.Length];
        }













        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            ovladani.Drzim(e.KeyCode.ToString());
            ovladani.RozklicujPrikaz(e.KeyCode.ToString());

            if (e.KeyCode.ToString() == "X")
            {
                PrepniViditelnost();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            ovladani.Poustim(e.KeyCode.ToString());
        }

        public void PrepniViditelnost()
        {
            this.Opacity = this.Opacity == 1 ? 0 : 1;
        }
    }
}