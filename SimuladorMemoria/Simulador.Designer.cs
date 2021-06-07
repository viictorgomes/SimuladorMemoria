namespace SimuladorMemoria
{
    partial class Simulador
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Simulador));
            this.lbl_RAM = new MetroFramework.Controls.MetroLabel();
            this.cb_RAM = new MetroFramework.Controls.MetroComboBox();
            this.cb_Bloco = new MetroFramework.Controls.MetroComboBox();
            this.lbl_Bloco = new MetroFramework.Controls.MetroLabel();
            this.lbl_Cache = new MetroFramework.Controls.MetroLabel();
            this.lbl_Tecnica = new MetroFramework.Controls.MetroLabel();
            this.lbl_Algoritmo = new MetroFramework.Controls.MetroLabel();
            this.btn_Simular = new MetroFramework.Controls.MetroButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.lbl_nPos = new MetroFramework.Controls.MetroLabel();
            this.txtbox_nPos = new MetroFramework.Controls.MetroTextBox();
            this.lbl_Linhas = new MetroFramework.Controls.MetroLabel();
            this.txtbox_Bloco = new MetroFramework.Controls.MetroTextBox();
            this.txtbox_RAM = new MetroFramework.Controls.MetroTextBox();
            this.cb_Tecnica = new MetroFramework.Controls.MetroComboBox();
            this.txtbox_Cache = new MetroFramework.Controls.MetroTextBox();
            this.cb_Algoritmo = new MetroFramework.Controls.MetroComboBox();
            this.painel_Carregar = new MetroFramework.Controls.MetroPanel();
            this.btn_CarregarTodos = new MetroFramework.Controls.MetroButton();
            this.label_Historico = new MetroFramework.Controls.MetroLabel();
            this.label_Check = new MetroFramework.Controls.MetroLabel();
            this.btn_Carregar = new MetroFramework.Controls.MetroButton();
            this.txtbox_Acessar = new MetroFramework.Controls.MetroTextBox();
            this.labelAcessar = new MetroFramework.Controls.MetroLabel();
            this.dgv_Cache = new System.Windows.Forms.DataGridView();
            this.dgv_RAM = new System.Windows.Forms.DataGridView();
            this.lbl_dvgCache = new MetroFramework.Controls.MetroLabel();
            this.lbl_dvgRAM = new MetroFramework.Controls.MetroLabel();
            this.btn_Limpar = new MetroFramework.Controls.MetroButton();
            this.dgv_Blocos = new System.Windows.Forms.DataGridView();
            this.lbl_dgvBlocos = new MetroFramework.Controls.MetroLabel();
            this.btn_Acessar = new MetroFramework.Controls.MetroButton();
            this.t_slide = new System.Windows.Forms.Timer(this.components);
            this.t_check = new System.Windows.Forms.Timer(this.components);
            this.btn_LimparBlocos = new MetroFramework.Controls.MetroButton();
            this.metroPanel1.SuspendLayout();
            this.painel_Carregar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Cache)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RAM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Blocos)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_RAM
            // 
            this.lbl_RAM.AutoSize = true;
            this.lbl_RAM.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbl_RAM.Location = new System.Drawing.Point(23, 8);
            this.lbl_RAM.Name = "lbl_RAM";
            this.lbl_RAM.Size = new System.Drawing.Size(125, 25);
            this.lbl_RAM.TabIndex = 0;
            this.lbl_RAM.Text = "Memória RAM:";
            this.lbl_RAM.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // cb_RAM
            // 
            this.cb_RAM.BackColor = System.Drawing.Color.White;
            this.cb_RAM.Enabled = false;
            this.cb_RAM.FormattingEnabled = true;
            this.cb_RAM.ItemHeight = 23;
            this.cb_RAM.Items.AddRange(new object[] {
            "Bytes",
            "KBytes",
            "Mbytes",
            "GBytes"});
            this.cb_RAM.Location = new System.Drawing.Point(286, 8);
            this.cb_RAM.Name = "cb_RAM";
            this.cb_RAM.Size = new System.Drawing.Size(87, 29);
            this.cb_RAM.Style = MetroFramework.MetroColorStyle.Red;
            this.cb_RAM.TabIndex = 1;
            this.cb_RAM.UseSelectable = true;
            // 
            // cb_Bloco
            // 
            this.cb_Bloco.Enabled = false;
            this.cb_Bloco.FormattingEnabled = true;
            this.cb_Bloco.ItemHeight = 23;
            this.cb_Bloco.Items.AddRange(new object[] {
            "Bytes",
            "KBytes",
            "Mbytes",
            "GBytes"});
            this.cb_Bloco.Location = new System.Drawing.Point(286, 46);
            this.cb_Bloco.Name = "cb_Bloco";
            this.cb_Bloco.Size = new System.Drawing.Size(87, 29);
            this.cb_Bloco.Style = MetroFramework.MetroColorStyle.Red;
            this.cb_Bloco.TabIndex = 3;
            this.cb_Bloco.UseSelectable = true;
            // 
            // lbl_Bloco
            // 
            this.lbl_Bloco.AutoSize = true;
            this.lbl_Bloco.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbl_Bloco.Location = new System.Drawing.Point(23, 46);
            this.lbl_Bloco.Name = "lbl_Bloco";
            this.lbl_Bloco.Size = new System.Drawing.Size(157, 25);
            this.lbl_Bloco.TabIndex = 2;
            this.lbl_Bloco.Text = "Tamanho do bloco:";
            this.lbl_Bloco.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lbl_Cache
            // 
            this.lbl_Cache.AutoSize = true;
            this.lbl_Cache.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbl_Cache.Location = new System.Drawing.Point(870, 26);
            this.lbl_Cache.Name = "lbl_Cache";
            this.lbl_Cache.Size = new System.Drawing.Size(63, 25);
            this.lbl_Cache.TabIndex = 4;
            this.lbl_Cache.Text = "Cache:";
            this.lbl_Cache.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lbl_Tecnica
            // 
            this.lbl_Tecnica.AutoSize = true;
            this.lbl_Tecnica.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbl_Tecnica.Location = new System.Drawing.Point(448, 8);
            this.lbl_Tecnica.Name = "lbl_Tecnica";
            this.lbl_Tecnica.Size = new System.Drawing.Size(70, 25);
            this.lbl_Tecnica.TabIndex = 6;
            this.lbl_Tecnica.Text = "Técnica:";
            this.lbl_Tecnica.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lbl_Algoritmo
            // 
            this.lbl_Algoritmo.AutoSize = true;
            this.lbl_Algoritmo.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbl_Algoritmo.Location = new System.Drawing.Point(448, 46);
            this.lbl_Algoritmo.Name = "lbl_Algoritmo";
            this.lbl_Algoritmo.Size = new System.Drawing.Size(91, 25);
            this.lbl_Algoritmo.TabIndex = 8;
            this.lbl_Algoritmo.Text = "Algorítmo:";
            this.lbl_Algoritmo.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // btn_Simular
            // 
            this.btn_Simular.Location = new System.Drawing.Point(1094, 25);
            this.btn_Simular.Name = "btn_Simular";
            this.btn_Simular.Size = new System.Drawing.Size(85, 29);
            this.btn_Simular.TabIndex = 7;
            this.btn_Simular.Text = "Simular";
            this.btn_Simular.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_Simular.UseSelectable = true;
            this.btn_Simular.Click += new System.EventHandler(this.Simular_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.Silver;
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.lbl_nPos);
            this.metroPanel1.Controls.Add(this.txtbox_nPos);
            this.metroPanel1.Controls.Add(this.lbl_Linhas);
            this.metroPanel1.Controls.Add(this.txtbox_Bloco);
            this.metroPanel1.Controls.Add(this.txtbox_RAM);
            this.metroPanel1.Controls.Add(this.cb_Tecnica);
            this.metroPanel1.Controls.Add(this.btn_Simular);
            this.metroPanel1.Controls.Add(this.txtbox_Cache);
            this.metroPanel1.Controls.Add(this.cb_Algoritmo);
            this.metroPanel1.Controls.Add(this.cb_RAM);
            this.metroPanel1.Controls.Add(this.lbl_Algoritmo);
            this.metroPanel1.Controls.Add(this.lbl_RAM);
            this.metroPanel1.Controls.Add(this.lbl_Cache);
            this.metroPanel1.Controls.Add(this.lbl_Bloco);
            this.metroPanel1.Controls.Add(this.lbl_Tecnica);
            this.metroPanel1.Controls.Add(this.cb_Bloco);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(-3, 59);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1206, 84);
            this.metroPanel1.TabIndex = 11;
            this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // lbl_nPos
            // 
            this.lbl_nPos.AutoSize = true;
            this.lbl_nPos.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbl_nPos.Location = new System.Drawing.Point(767, 9);
            this.lbl_nPos.Name = "lbl_nPos";
            this.lbl_nPos.Size = new System.Drawing.Size(38, 25);
            this.lbl_nPos.TabIndex = 16;
            this.lbl_nPos.Text = "Pos";
            this.lbl_nPos.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // txtbox_nPos
            // 
            // 
            // 
            // 
            this.txtbox_nPos.CustomButton.Image = null;
            this.txtbox_nPos.CustomButton.Location = new System.Drawing.Point(37, 1);
            this.txtbox_nPos.CustomButton.Name = "";
            this.txtbox_nPos.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbox_nPos.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbox_nPos.CustomButton.TabIndex = 1;
            this.txtbox_nPos.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbox_nPos.CustomButton.UseSelectable = true;
            this.txtbox_nPos.CustomButton.Visible = false;
            this.txtbox_nPos.Lines = new string[] {
        "N"};
            this.txtbox_nPos.Location = new System.Drawing.Point(709, 11);
            this.txtbox_nPos.MaxLength = 32767;
            this.txtbox_nPos.Name = "txtbox_nPos";
            this.txtbox_nPos.PasswordChar = '\0';
            this.txtbox_nPos.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbox_nPos.SelectedText = "";
            this.txtbox_nPos.SelectionLength = 0;
            this.txtbox_nPos.SelectionStart = 0;
            this.txtbox_nPos.ShortcutsEnabled = true;
            this.txtbox_nPos.Size = new System.Drawing.Size(59, 23);
            this.txtbox_nPos.Style = MetroFramework.MetroColorStyle.Red;
            this.txtbox_nPos.TabIndex = 15;
            this.txtbox_nPos.Text = "N";
            this.txtbox_nPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtbox_nPos.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtbox_nPos.UseSelectable = true;
            this.txtbox_nPos.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbox_nPos.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtbox_nPos.Click += new System.EventHandler(this.txtbox_nPos_Click);
            this.txtbox_nPos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbox_nPos_KeyPress);
            this.txtbox_nPos.Leave += new System.EventHandler(this.txtbox_nPos_Leave);
            // 
            // lbl_Linhas
            // 
            this.lbl_Linhas.AutoSize = true;
            this.lbl_Linhas.Location = new System.Drawing.Point(1008, 31);
            this.lbl_Linhas.Name = "lbl_Linhas";
            this.lbl_Linhas.Size = new System.Drawing.Size(49, 19);
            this.lbl_Linhas.TabIndex = 14;
            this.lbl_Linhas.Text = "linha(s)";
            this.lbl_Linhas.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // txtbox_Bloco
            // 
            // 
            // 
            // 
            this.txtbox_Bloco.CustomButton.Image = null;
            this.txtbox_Bloco.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.txtbox_Bloco.CustomButton.Name = "";
            this.txtbox_Bloco.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbox_Bloco.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbox_Bloco.CustomButton.TabIndex = 1;
            this.txtbox_Bloco.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbox_Bloco.CustomButton.UseSelectable = true;
            this.txtbox_Bloco.CustomButton.Visible = false;
            this.txtbox_Bloco.Lines = new string[0];
            this.txtbox_Bloco.Location = new System.Drawing.Point(189, 49);
            this.txtbox_Bloco.MaxLength = 32767;
            this.txtbox_Bloco.Name = "txtbox_Bloco";
            this.txtbox_Bloco.PasswordChar = '\0';
            this.txtbox_Bloco.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbox_Bloco.SelectedText = "";
            this.txtbox_Bloco.SelectionLength = 0;
            this.txtbox_Bloco.SelectionStart = 0;
            this.txtbox_Bloco.ShortcutsEnabled = true;
            this.txtbox_Bloco.Size = new System.Drawing.Size(75, 23);
            this.txtbox_Bloco.Style = MetroFramework.MetroColorStyle.Red;
            this.txtbox_Bloco.TabIndex = 2;
            this.txtbox_Bloco.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtbox_Bloco.UseSelectable = true;
            this.txtbox_Bloco.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbox_Bloco.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtbox_Bloco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbox_Bloco_KeyPress);
            // 
            // txtbox_RAM
            // 
            // 
            // 
            // 
            this.txtbox_RAM.CustomButton.Image = null;
            this.txtbox_RAM.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.txtbox_RAM.CustomButton.Name = "";
            this.txtbox_RAM.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbox_RAM.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbox_RAM.CustomButton.TabIndex = 1;
            this.txtbox_RAM.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbox_RAM.CustomButton.UseSelectable = true;
            this.txtbox_RAM.CustomButton.Visible = false;
            this.txtbox_RAM.Lines = new string[0];
            this.txtbox_RAM.Location = new System.Drawing.Point(189, 10);
            this.txtbox_RAM.MaxLength = 32767;
            this.txtbox_RAM.Name = "txtbox_RAM";
            this.txtbox_RAM.PasswordChar = '\0';
            this.txtbox_RAM.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbox_RAM.SelectedText = "";
            this.txtbox_RAM.SelectionLength = 0;
            this.txtbox_RAM.SelectionStart = 0;
            this.txtbox_RAM.ShortcutsEnabled = true;
            this.txtbox_RAM.Size = new System.Drawing.Size(75, 23);
            this.txtbox_RAM.Style = MetroFramework.MetroColorStyle.Red;
            this.txtbox_RAM.TabIndex = 0;
            this.txtbox_RAM.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtbox_RAM.UseSelectable = true;
            this.txtbox_RAM.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbox_RAM.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtbox_RAM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbox_RAM_KeyPress);
            // 
            // cb_Tecnica
            // 
            this.cb_Tecnica.Enabled = false;
            this.cb_Tecnica.FormattingEnabled = true;
            this.cb_Tecnica.ItemHeight = 23;
            this.cb_Tecnica.Items.AddRange(new object[] {
            "Associativa Conjunto"});
            this.cb_Tecnica.Location = new System.Drawing.Point(545, 8);
            this.cb_Tecnica.Name = "cb_Tecnica";
            this.cb_Tecnica.Size = new System.Drawing.Size(158, 29);
            this.cb_Tecnica.Style = MetroFramework.MetroColorStyle.Red;
            this.cb_Tecnica.TabIndex = 4;
            this.cb_Tecnica.UseSelectable = true;
            // 
            // txtbox_Cache
            // 
            // 
            // 
            // 
            this.txtbox_Cache.CustomButton.Image = null;
            this.txtbox_Cache.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.txtbox_Cache.CustomButton.Name = "";
            this.txtbox_Cache.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbox_Cache.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbox_Cache.CustomButton.TabIndex = 1;
            this.txtbox_Cache.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbox_Cache.CustomButton.UseSelectable = true;
            this.txtbox_Cache.CustomButton.Visible = false;
            this.txtbox_Cache.Lines = new string[0];
            this.txtbox_Cache.Location = new System.Drawing.Point(933, 29);
            this.txtbox_Cache.MaxLength = 32767;
            this.txtbox_Cache.Name = "txtbox_Cache";
            this.txtbox_Cache.PasswordChar = '\0';
            this.txtbox_Cache.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbox_Cache.SelectedText = "";
            this.txtbox_Cache.SelectionLength = 0;
            this.txtbox_Cache.SelectionStart = 0;
            this.txtbox_Cache.ShortcutsEnabled = true;
            this.txtbox_Cache.Size = new System.Drawing.Size(75, 23);
            this.txtbox_Cache.Style = MetroFramework.MetroColorStyle.Red;
            this.txtbox_Cache.TabIndex = 6;
            this.txtbox_Cache.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtbox_Cache.UseSelectable = true;
            this.txtbox_Cache.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbox_Cache.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtbox_Cache.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbox_Cache_KeyPress);
            // 
            // cb_Algoritmo
            // 
            this.cb_Algoritmo.FormattingEnabled = true;
            this.cb_Algoritmo.ItemHeight = 23;
            this.cb_Algoritmo.Items.AddRange(new object[] {
            "LRU",
            "LFU",
            "FIFO"});
            this.cb_Algoritmo.Location = new System.Drawing.Point(545, 46);
            this.cb_Algoritmo.Name = "cb_Algoritmo";
            this.cb_Algoritmo.Size = new System.Drawing.Size(78, 29);
            this.cb_Algoritmo.Style = MetroFramework.MetroColorStyle.Red;
            this.cb_Algoritmo.TabIndex = 5;
            this.cb_Algoritmo.UseSelectable = true;
            // 
            // painel_Carregar
            // 
            this.painel_Carregar.BackColor = System.Drawing.Color.Silver;
            this.painel_Carregar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.painel_Carregar.Controls.Add(this.btn_CarregarTodos);
            this.painel_Carregar.Controls.Add(this.label_Historico);
            this.painel_Carregar.Controls.Add(this.label_Check);
            this.painel_Carregar.Controls.Add(this.btn_Carregar);
            this.painel_Carregar.Controls.Add(this.txtbox_Acessar);
            this.painel_Carregar.Controls.Add(this.labelAcessar);
            this.painel_Carregar.HorizontalScrollbarBarColor = true;
            this.painel_Carregar.HorizontalScrollbarHighlightOnWheel = false;
            this.painel_Carregar.HorizontalScrollbarSize = 10;
            this.painel_Carregar.Location = new System.Drawing.Point(-3, 70);
            this.painel_Carregar.Name = "painel_Carregar";
            this.painel_Carregar.Size = new System.Drawing.Size(1206, 54);
            this.painel_Carregar.TabIndex = 12;
            this.painel_Carregar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.painel_Carregar.VerticalScrollbarBarColor = true;
            this.painel_Carregar.VerticalScrollbarHighlightOnWheel = false;
            this.painel_Carregar.VerticalScrollbarSize = 10;
            // 
            // btn_CarregarTodos
            // 
            this.btn_CarregarTodos.Location = new System.Drawing.Point(430, 13);
            this.btn_CarregarTodos.Name = "btn_CarregarTodos";
            this.btn_CarregarTodos.Size = new System.Drawing.Size(112, 29);
            this.btn_CarregarTodos.TabIndex = 12;
            this.btn_CarregarTodos.Text = "Carregar Todos";
            this.btn_CarregarTodos.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_CarregarTodos.UseSelectable = true;
            this.btn_CarregarTodos.Click += new System.EventHandler(this.btn_CarregarTodos_Click);
            // 
            // label_Historico
            // 
            this.label_Historico.Location = new System.Drawing.Point(552, 17);
            this.label_Historico.Name = "label_Historico";
            this.label_Historico.Size = new System.Drawing.Size(331, 23);
            this.label_Historico.TabIndex = 11;
            this.label_Historico.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // label_Check
            // 
            this.label_Check.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.label_Check.Location = new System.Drawing.Point(1115, 13);
            this.label_Check.Name = "label_Check";
            this.label_Check.Size = new System.Drawing.Size(64, 20);
            this.label_Check.TabIndex = 10;
            this.label_Check.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.label_Check.UseCustomForeColor = true;
            // 
            // btn_Carregar
            // 
            this.btn_Carregar.Location = new System.Drawing.Point(335, 13);
            this.btn_Carregar.Name = "btn_Carregar";
            this.btn_Carregar.Size = new System.Drawing.Size(85, 29);
            this.btn_Carregar.TabIndex = 9;
            this.btn_Carregar.Text = "Carregar";
            this.btn_Carregar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_Carregar.UseSelectable = true;
            this.btn_Carregar.Click += new System.EventHandler(this.Carregar_Click);
            // 
            // txtbox_Acessar
            // 
            // 
            // 
            // 
            this.txtbox_Acessar.CustomButton.Image = null;
            this.txtbox_Acessar.CustomButton.Location = new System.Drawing.Point(101, 1);
            this.txtbox_Acessar.CustomButton.Name = "";
            this.txtbox_Acessar.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbox_Acessar.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbox_Acessar.CustomButton.TabIndex = 1;
            this.txtbox_Acessar.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbox_Acessar.CustomButton.UseSelectable = true;
            this.txtbox_Acessar.CustomButton.Visible = false;
            this.txtbox_Acessar.Lines = new string[0];
            this.txtbox_Acessar.Location = new System.Drawing.Point(198, 16);
            this.txtbox_Acessar.MaxLength = 32767;
            this.txtbox_Acessar.Name = "txtbox_Acessar";
            this.txtbox_Acessar.PasswordChar = '\0';
            this.txtbox_Acessar.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbox_Acessar.SelectedText = "";
            this.txtbox_Acessar.SelectionLength = 0;
            this.txtbox_Acessar.SelectionStart = 0;
            this.txtbox_Acessar.ShortcutsEnabled = true;
            this.txtbox_Acessar.Size = new System.Drawing.Size(123, 23);
            this.txtbox_Acessar.Style = MetroFramework.MetroColorStyle.Red;
            this.txtbox_Acessar.TabIndex = 8;
            this.txtbox_Acessar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtbox_Acessar.UseSelectable = true;
            this.txtbox_Acessar.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbox_Acessar.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtbox_Acessar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbox_Acessar_KeyPress);
            // 
            // labelAcessar
            // 
            this.labelAcessar.AutoSize = true;
            this.labelAcessar.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.labelAcessar.Location = new System.Drawing.Point(23, 14);
            this.labelAcessar.Name = "labelAcessar";
            this.labelAcessar.Size = new System.Drawing.Size(173, 25);
            this.labelAcessar.TabIndex = 2;
            this.labelAcessar.Text = "Bloco a ser acessado:";
            this.labelAcessar.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // dgv_Cache
            // 
            this.dgv_Cache.AllowUserToAddRows = false;
            this.dgv_Cache.AllowUserToDeleteRows = false;
            this.dgv_Cache.AllowUserToResizeColumns = false;
            this.dgv_Cache.AllowUserToResizeRows = false;
            this.dgv_Cache.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Cache.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dgv_Cache.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Cache.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Cache.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Cache.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Cache.Location = new System.Drawing.Point(649, 231);
            this.dgv_Cache.MultiSelect = false;
            this.dgv_Cache.Name = "dgv_Cache";
            this.dgv_Cache.ReadOnly = true;
            this.dgv_Cache.RowHeadersVisible = false;
            this.dgv_Cache.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_Cache.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Cache.Size = new System.Drawing.Size(389, 424);
            this.dgv_Cache.TabIndex = 13;
            // 
            // dgv_RAM
            // 
            this.dgv_RAM.AllowUserToAddRows = false;
            this.dgv_RAM.AllowUserToDeleteRows = false;
            this.dgv_RAM.AllowUserToResizeColumns = false;
            this.dgv_RAM.AllowUserToResizeRows = false;
            this.dgv_RAM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_RAM.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dgv_RAM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_RAM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_RAM.Location = new System.Drawing.Point(210, 231);
            this.dgv_RAM.MultiSelect = false;
            this.dgv_RAM.Name = "dgv_RAM";
            this.dgv_RAM.ReadOnly = true;
            this.dgv_RAM.RowHeadersVisible = false;
            this.dgv_RAM.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_RAM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_RAM.Size = new System.Drawing.Size(389, 424);
            this.dgv_RAM.TabIndex = 13;
            // 
            // lbl_dvgCache
            // 
            this.lbl_dvgCache.AutoSize = true;
            this.lbl_dvgCache.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbl_dvgCache.Location = new System.Drawing.Point(649, 198);
            this.lbl_dvgCache.Name = "lbl_dvgCache";
            this.lbl_dvgCache.Size = new System.Drawing.Size(132, 25);
            this.lbl_dvgCache.TabIndex = 15;
            this.lbl_dvgCache.Text = "Memória Cache";
            this.lbl_dvgCache.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lbl_dvgRAM
            // 
            this.lbl_dvgRAM.AutoSize = true;
            this.lbl_dvgRAM.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbl_dvgRAM.Location = new System.Drawing.Point(210, 198);
            this.lbl_dvgRAM.Name = "lbl_dvgRAM";
            this.lbl_dvgRAM.Size = new System.Drawing.Size(121, 25);
            this.lbl_dvgRAM.TabIndex = 16;
            this.lbl_dvgRAM.Text = "Memória RAM";
            this.lbl_dvgRAM.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // btn_Limpar
            // 
            this.btn_Limpar.Location = new System.Drawing.Point(1090, 604);
            this.btn_Limpar.Name = "btn_Limpar";
            this.btn_Limpar.Size = new System.Drawing.Size(85, 51);
            this.btn_Limpar.TabIndex = 17;
            this.btn_Limpar.Text = "Limpar";
            this.btn_Limpar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_Limpar.UseSelectable = true;
            this.btn_Limpar.Click += new System.EventHandler(this.Limpar_Click);
            // 
            // dgv_Blocos
            // 
            this.dgv_Blocos.AllowUserToAddRows = false;
            this.dgv_Blocos.AllowUserToDeleteRows = false;
            this.dgv_Blocos.AllowUserToResizeColumns = false;
            this.dgv_Blocos.AllowUserToResizeRows = false;
            this.dgv_Blocos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Blocos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dgv_Blocos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Blocos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Blocos.ColumnHeadersVisible = false;
            this.dgv_Blocos.Location = new System.Drawing.Point(24, 231);
            this.dgv_Blocos.MultiSelect = false;
            this.dgv_Blocos.Name = "dgv_Blocos";
            this.dgv_Blocos.ReadOnly = true;
            this.dgv_Blocos.RowHeadersVisible = false;
            this.dgv_Blocos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_Blocos.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Blocos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Blocos.Size = new System.Drawing.Size(106, 424);
            this.dgv_Blocos.TabIndex = 18;
            this.dgv_Blocos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Blocos_CellClick);
            // 
            // lbl_dgvBlocos
            // 
            this.lbl_dgvBlocos.AutoSize = true;
            this.lbl_dgvBlocos.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbl_dgvBlocos.Location = new System.Drawing.Point(24, 198);
            this.lbl_dgvBlocos.Name = "lbl_dgvBlocos";
            this.lbl_dgvBlocos.Size = new System.Drawing.Size(61, 25);
            this.lbl_dgvBlocos.TabIndex = 19;
            this.lbl_dgvBlocos.Text = "Blocos";
            this.lbl_dgvBlocos.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // btn_Acessar
            // 
            this.btn_Acessar.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_Acessar.Location = new System.Drawing.Point(146, 395);
            this.btn_Acessar.Name = "btn_Acessar";
            this.btn_Acessar.Size = new System.Drawing.Size(48, 63);
            this.btn_Acessar.TabIndex = 20;
            this.btn_Acessar.Text = " >";
            this.btn_Acessar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_Acessar.UseSelectable = true;
            this.btn_Acessar.Click += new System.EventHandler(this.Acessar_Click);
            // 
            // t_slide
            // 
            this.t_slide.Interval = 1;
            this.t_slide.Tick += new System.EventHandler(this.t_slide_Tick);
            // 
            // t_check
            // 
            this.t_check.Interval = 2000;
            this.t_check.Tick += new System.EventHandler(this.t_check_Tick);
            // 
            // btn_LimparBlocos
            // 
            this.btn_LimparBlocos.Location = new System.Drawing.Point(146, 464);
            this.btn_LimparBlocos.Name = "btn_LimparBlocos";
            this.btn_LimparBlocos.Size = new System.Drawing.Size(48, 26);
            this.btn_LimparBlocos.TabIndex = 21;
            this.btn_LimparBlocos.Text = "Limpar";
            this.btn_LimparBlocos.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_LimparBlocos.UseSelectable = true;
            this.btn_LimparBlocos.Click += new System.EventHandler(this.btn_LimparBlocos_Click);
            // 
            // Simulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 680);
            this.Controls.Add(this.btn_LimparBlocos);
            this.Controls.Add(this.btn_Acessar);
            this.Controls.Add(this.lbl_dgvBlocos);
            this.Controls.Add(this.dgv_Blocos);
            this.Controls.Add(this.btn_Limpar);
            this.Controls.Add(this.lbl_dvgRAM);
            this.Controls.Add(this.lbl_dvgCache);
            this.Controls.Add(this.dgv_RAM);
            this.Controls.Add(this.dgv_Cache);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.painel_Carregar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1200, 680);
            this.Name = "Simulador";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Simulador de Memória";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.Simulador_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.painel_Carregar.ResumeLayout(false);
            this.painel_Carregar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Cache)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RAM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Blocos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lbl_RAM;
        private MetroFramework.Controls.MetroComboBox cb_RAM;
        private MetroFramework.Controls.MetroComboBox cb_Bloco;
        private MetroFramework.Controls.MetroLabel lbl_Bloco;
        private MetroFramework.Controls.MetroLabel lbl_Cache;
        private MetroFramework.Controls.MetroLabel lbl_Tecnica;
        private MetroFramework.Controls.MetroLabel lbl_Algoritmo;
        private MetroFramework.Controls.MetroButton btn_Simular;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel painel_Carregar;
        private MetroFramework.Controls.MetroLabel labelAcessar;
        private MetroFramework.Controls.MetroTextBox txtbox_Acessar;
        private MetroFramework.Controls.MetroButton btn_Carregar;
        private System.Windows.Forms.DataGridView dgv_Cache;
        private System.Windows.Forms.DataGridView dgv_RAM;
        private MetroFramework.Controls.MetroLabel lbl_dvgCache;
        private MetroFramework.Controls.MetroLabel lbl_dvgRAM;
        private MetroFramework.Controls.MetroButton btn_Limpar;
        private MetroFramework.Controls.MetroLabel lbl_Linhas;
        private MetroFramework.Controls.MetroTextBox txtbox_Bloco;
        private MetroFramework.Controls.MetroTextBox txtbox_RAM;
        private MetroFramework.Controls.MetroComboBox cb_Tecnica;
        private MetroFramework.Controls.MetroTextBox txtbox_Cache;
        private MetroFramework.Controls.MetroComboBox cb_Algoritmo;
        private System.Windows.Forms.DataGridView dgv_Blocos;
        private MetroFramework.Controls.MetroLabel lbl_dgvBlocos;
        private MetroFramework.Controls.MetroButton btn_Acessar;
        private System.Windows.Forms.Timer t_slide;
        private System.Windows.Forms.Timer t_check;
        private MetroFramework.Controls.MetroLabel label_Historico;
        private MetroFramework.Controls.MetroLabel label_Check;
        private MetroFramework.Controls.MetroButton btn_CarregarTodos;
        private MetroFramework.Controls.MetroLabel lbl_nPos;
        private MetroFramework.Controls.MetroTextBox txtbox_nPos;
        private MetroFramework.Controls.MetroButton btn_LimparBlocos;
    }
}

