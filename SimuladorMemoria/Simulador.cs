using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;

namespace SimuladorMemoria
{
    public partial class Simulador : MetroForm
    {
        private Random random = new Random();
        List<Cache> MemoriaCache = new List<Cache>();
        List<RAM> MemoriaRAM = new List<RAM>();
        List<string> Blocos = new List<string>();

        #region --- Inicialização ---
        public Simulador()
        {
            InitializeComponent();
        }

        private void Simulador_Load(object sender, EventArgs e)
        {
            // seleciona os valores iniciais dos combo box
            txtbox_RAM.Text = "1024";
            txtbox_Bloco.Text = "128";

            cb_RAM.SelectedIndex = 0;
            cb_Bloco.SelectedIndex = 0;

            cb_Tecnica.SelectedIndex = 2;
            cb_Algoritmo.SelectedIndex = 0;

            txtbox_RAM.Focus();
        }

        #endregion

        #region --- Tecnicas ---
        private void TecnicaDireta(Cache bloco, int linha)
        {
            //insere o bloco na linha correspondente
            MemoriaCache[linha] = bloco;
            dgv_Cache.DataSource = null;
            dgv_Cache.DataSource = MemoriaCache;
            dgv_Cache.Focus();
            dgv_Cache.Rows[linha].Selected = true;
        }

        private void TecnicaAssociativa(Cache bloco, string algoritmo)
        {
            int qtdCache = Convert.ToInt32(txtbox_Cache.Text);
            int linhasCheias = 0;
            string menor = "";
            switch (algoritmo)
            {
                case Algoritmo.LRU: { menor = MemoriaCache[0].HoraUsada.ToString(); } break;
                case Algoritmo.LFU: { menor = MemoriaCache[0].Contador.ToString(); } break;
                case Algoritmo.FIFO: { menor = MemoriaCache[0].HoraCarregada.ToString(); } break;
            }
            int indexMenor = 0;
            var celulasVazias = new List<int>();
            var equalCount = new List<int>();
            var random = new Random();
            int linhaSelecionada = 0;

            //verifica todas as linhas que estão vazias, seleciona os menores valores e seus indices
            for (int i = 0; i < qtdCache; i++)
            {
                if (MemoriaCache[i].Tag != null)
                {
                    switch (algoritmo)
                    {
                        case Algoritmo.LRU:
                            {
                                if (MemoriaCache[i].HoraUsada < Convert.ToDateTime(menor))
                                {
                                    menor = MemoriaCache[i].HoraUsada.ToString();
                                    indexMenor = i;
                                }
                            }
                            break;
                        case Algoritmo.LFU:
                            {
                                if (MemoriaCache[i].Contador < Convert.ToInt32(menor))
                                {
                                    equalCount.Clear();
                                    equalCount.Add(i);
                                    menor = MemoriaCache[i].Contador.ToString();
                                    indexMenor = i;
                                }
                                else if (MemoriaCache[i].Contador == Convert.ToInt32(menor))
                                {
                                    equalCount.Add(i);
                                }
                            }
                            break;
                        case Algoritmo.FIFO:
                            {
                                if (MemoriaCache[i].HoraCarregada < Convert.ToDateTime(menor))
                                {
                                    menor = MemoriaCache[i].HoraCarregada.ToString();
                                    indexMenor = i;
                                }
                            }
                            break;
                    }
                    linhasCheias++;
                }
                else
                {
                    celulasVazias.Add(i);
                }
            }

            if (linhasCheias < qtdCache)
            {
                //se ainda tiver linha vazia, insere o bloco em uma das linhas vazias
                MemoriaCache[celulasVazias[0]] = bloco;
                linhaSelecionada = celulasVazias[0];
            }
            else
            {
                //se não tiver linha vazia, substitui o bloco com menor indice, caso LFU, substitui em qualquer um que tiver o contador com menor valor
                switch (algoritmo)
                {
                    case Algoritmo.LFU:
                        {
                            int line = equalCount[random.Next(equalCount.Count)];
                            MemoriaCache[line] = bloco;
                            linhaSelecionada = line;
                        }
                        break;
                    default:
                        {
                            MemoriaCache[indexMenor] = bloco;
                            linhaSelecionada = indexMenor;
                        }
                        break;
                }

            }
            //atualiza o grid da memoria cache
            dgv_Cache.DataSource = null;
            dgv_Cache.DataSource = MemoriaCache;
            dgv_Cache.Focus();
            dgv_Cache.Rows[linhaSelecionada].Selected = true;
        }

        private void TecnicaAssociativaConjuntoNPos(Cache bloco, string algoritmo, int nPos)
        {
            var quantidadeConjuntos = Convert.ToInt32(txtbox_Cache.Text) / nPos;
            int conjuntoDestino = Convert.ToInt32(bloco.Tag) % quantidadeConjuntos;

            int linhaSelecionada = 0;

            Dictionary<int, Cache> cacheEmUso = new Dictionary<int, Cache>(); // Variavel para armazenar dados do conjunto destino que estão em uso na cache

            List<int> blocosVazios = new List<int>();

            bool Adicionado = false;
            for (int j = 0; j < nPos; j++) // Passar por cada elemento de 1 conjunto de N elementos(nPos)
            {
                int indexConjuntoDestino = (conjuntoDestino * nPos); // Obter o indice em que o conjunto começa
                int indiceDoElementoNoConjunto = indexConjuntoDestino + j; // Indice do elemento dentro do conjunto

                if (indiceDoElementoNoConjunto > MemoriaCache.Count)
                    throw new Exception("Overflow: IndiceDoElementoNoConjunto > MemoriaCache.Count");

                if (string.IsNullOrEmpty(MemoriaCache[indiceDoElementoNoConjunto].Bloco)) // Se o indice do elemento dentro do conjunto estiver vazio, armazena o bloco no indice
                {
                    blocosVazios.Add(indiceDoElementoNoConjunto);
                }

                cacheEmUso[indiceDoElementoNoConjunto] = MemoriaCache[indiceDoElementoNoConjunto]; // Armazena dados que estão em uso na cache do conjunto destino
            }

            if (blocosVazios != null)
            {
                var blocosVaziosShuffle = blocosVazios.OrderBy(a => random.Next()).ToList();    // Cria uma nova lista e popula essa lista com os elementos de blocoVazios de forma aleatoria
                int indiceAleatorioDoElementoNoConjunto = blocosVaziosShuffle.First();

                MemoriaCache[indiceAleatorioDoElementoNoConjunto] = bloco;
                linhaSelecionada = indiceAleatorioDoElementoNoConjunto;

                Adicionado = true; // Se o bloco for armazenado, não há necessidade de algoritmo de substituição

                blocosVazios.Remove(indiceAleatorioDoElementoNoConjunto); // Remover indice do bloco vazio utilizado, para este não estar mais incluído nos blocos vazios nas proximas buscas
            }

            if (!Adicionado) // Se o bloco não tiver sido armazenado anteriormente, o conjunto nao possui indices vazios, então há necessidade de algoritmo de substituição
            {
                switch (algoritmo)
                {
                    case Algoritmo.LRU:
                        {
                            var val = cacheEmUso.OrderBy(x => x.Value.HoraUsada).FirstOrDefault(); // Obter o indice dentro de cacheEmUso que tenha a menor Hora Usada
                            MemoriaCache[val.Key] = bloco; // Substitui o bloco no indice obtido
                            linhaSelecionada = val.Key;
                            break;
                        }
                    case Algoritmo.LFU:
                        {
                            var val = cacheEmUso.OrderBy(x => x.Value.Contador).FirstOrDefault(); // Obter o item dentro de cacheEmUso que tenha o menor Contador
                            MemoriaCache[val.Key] = bloco; // Substitui o bloco no indice obtido
                            linhaSelecionada = val.Key;
                            break;
                        }
                    case Algoritmo.FIFO:
                        {
                            var val = cacheEmUso.OrderBy(x => x.Value.HoraCarregada).FirstOrDefault(); // Obter o item dentro de cacheEmUso que tenha a menor Hora Carregada
                            MemoriaCache[val.Key] = bloco; // Substitui o bloco no indice obtido
                            linhaSelecionada = val.Key;
                            break;
                        }
                }
            }

            // Atualizar datagridview
            dgv_Cache.DataSource = null;
            dgv_Cache.DataSource = MemoriaCache;
            dgv_Cache.Focus();
            dgv_Cache.Rows[linhaSelecionada].Selected = true;
        }
        #endregion

        #region --- Métodos Auxiliares ---
        private bool Valida()
        {
            //vericia se possui campo vazio
            if (String.IsNullOrEmpty(txtbox_RAM.Text.ToString()) || String.IsNullOrEmpty(txtbox_Bloco.Text.ToString()) || String.IsNullOrEmpty(txtbox_Cache.Text.ToString()))
            {
                MetroMessageBox.Show(this, "É necessário preencher todos os campos corretamente.", "Valores inválidos!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //pega o valor em bytes da ram e bloco
            int indexRam = cb_RAM.SelectedIndex;
            double ram = indexRam == 0 ? Convert.ToInt32(txtbox_RAM.Text) : Convert.ToInt32(txtbox_RAM.Text) * Math.Pow(2, (indexRam * 10));
            int indexBloco = cb_Bloco.SelectedIndex;
            double bloco = indexBloco == 0 ? Convert.ToInt32(txtbox_Bloco.Text) : Convert.ToInt32(txtbox_Bloco.Text) * Math.Pow(2, (indexBloco * 10));

            //verifica se o bloco é maior que a ram
            if (bloco > ram)
            {
                MetroMessageBox.Show(this, "A memória RAM deve ser maior que o tamanho do bloco.", "Valores inválidos!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbox_Bloco.Focus();
                return false;
            }

            if (GetTecnica() == Tecnica.AssociativaConjuntoNPos)
            {
                string nInput = txtbox_nPos.Text;

                if (!nInput.All(char.IsDigit) || !IsPowerOfTwo(Convert.ToInt32(nInput)))
                {
                    MetroMessageBox.Show(this, "O valor de N Pos precisa ser uma potência de 2", "Impossível realizar a simulação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtbox_nPos.Focus();
                    return false;
                }
            }

            return true;
        }

        private bool IsPowerOfTwo(int x)
        {
            return (x != 0) && (x & (x - 1)) == 0;
        }

        private void Limpar()
        {
            //limpa grid e listas
            MemoriaCache.Clear();
            MemoriaRAM.Clear();
            Blocos.Clear();

            label_Historico.Text = "";
            txtbox_Acessar.Text = null;

            dgv_Cache.DataSource = null;
            dgv_RAM.DataSource = null;
            dgv_Blocos.DataSource = null;
        }

        private string GerarDadoAleatorio(int tamanho)
        {
            //gera bloco aleatorio
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

        // Metodo para obter um indice de dado em uma gridview a partir da tag de um bloco
        private int ObterIndicePorTag(int tag, DataGridView dgv)
        {
            return (dgv.Rows.Cast<DataGridViewRow>()
                                   .Where(r => Convert.ToInt32(r.Cells[0].Value) == tag)
                                   .Select(r => r.Index)).First();
        }

        private void PropriedadeGrid(string algoritmo = "", int tecnica = 0)
        {
            //Método feito para realizar alinhamento e customização das colunas
            //seleciona o tamanho e quais colunas a serem apresentadas de acordo com a tecnica e algoritmo
            dgv_RAM.Columns[0].Width = 30;
            dgv_RAM.Columns[1].Width = 180;
            dgv_RAM.Columns[2].Width = 70;

            dgv_Cache.Columns[0].Width = 20;
            dgv_Cache.Columns[4].Width = 45;
            dgv_Cache.Columns[5].Width = 35;
            dgv_Cache.Columns[6].Width = 30;
            dgv_Cache.Columns[2].Visible = false;
            dgv_Cache.Columns[3].Visible = false;
            dgv_Cache.Columns[4].HeaderText = "Horário de Carregamento";
            dgv_Cache.Columns[5].HeaderText = "Horário de Acesso";

            dgv_Cache.Columns[4].Visible = algoritmo == Algoritmo.FIFO;
            dgv_Cache.Columns[5].Visible = algoritmo == Algoritmo.LRU;
            dgv_Cache.Columns[6].Visible = algoritmo == Algoritmo.LFU;

            if (tecnica != Tecnica.AssociativaConjuntoNPos)
            {
                switch (algoritmo)
                {
                    case Algoritmo.LRU:
                        dgv_Cache.Columns[1].Width = 210;
                        break;
                    case Algoritmo.LFU:
                        dgv_Cache.Columns[1].Width = 245;
                        break;
                    case Algoritmo.FIFO:
                        dgv_Cache.Columns[1].Width = 190;
                        break;
                }
            }
            else
            {
                dgv_Cache.Columns[1].Width = 200;

                int linha = 0;
                bool colorir = false;
                foreach (DataGridViewRow row in dgv_Cache.Rows)
                {
                    int nPos = Convert.ToInt32(txtbox_nPos.Text);

                    if (linha % nPos == 0) // Alterar a cor para iniciar um conjunto
                    {
                        colorir = !colorir;
                    }

                    if (colorir)
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                    else
                        row.DefaultCellStyle.BackColor = Color.White;

                    linha += 1;
                }
            }
        }

        private bool CachePossuiDado(Cache cache)
        {
            //Verifica se Memoria Cache já possui o dado recebido pelo parametro(com base na tag), e caso positivo, altera o contador e hora usada
            var dadoJaExistenteNaCache = MemoriaCache.Where(d => d.Tag == cache.Tag).FirstOrDefault();

            if (dadoJaExistenteNaCache != null) // Se encontrar o dado recebido por parametro, atualizar o bloco e selecionar a linha do bloco
            {
                dadoJaExistenteNaCache.HoraUsada = DateTime.Now;
                dadoJaExistenteNaCache.Contador++;
                dgv_Cache.DataSource = null;
                dgv_Cache.DataSource = MemoriaCache;
                dgv_Cache.Focus();

                PropriedadeGrid(GetAlgoritmo(), GetTecnica());

                dgv_Cache.Rows[ObterIndicePorTag(Convert.ToInt32(dadoJaExistenteNaCache.Tag), dgv_Cache)].Selected = true;
                return true;
            }

            PropriedadeGrid(GetAlgoritmo(), GetTecnica());

            return false;
        }

        private string GetAlgoritmo()
        {
            //retorna qual o algoritmo de substituição está sendo usado
            string algoritmo = "";
            if (cb_Tecnica.SelectedIndex != 0)
            {
                switch (cb_Algoritmo.SelectedIndex)
                {
                    case 0: { algoritmo = Algoritmo.LRU; } break;
                    case 1: { algoritmo = Algoritmo.LFU; } break;
                    case 2: { algoritmo = Algoritmo.FIFO; } break;
                }
            }
            return algoritmo;
        }

        private int GetTecnica()
        {
            //retorna qual tecnica está sendo usada
            int tecnica = 0;

            switch (cb_Tecnica.SelectedIndex)
            {
                case 0: { tecnica = Tecnica.Direta; } break;
                case 1: { tecnica = Tecnica.Associativa; } break;
                case 2: { tecnica = Tecnica.AssociativaConjuntoNPos; } break;
            }
            return tecnica;
        }

        private void selecionarLinhaRAM(int linha)
        {
            int linhaParaSelecionar = 0;

            if (dgv_RAM.DataSource != null && (linha > 0 && linha <= Convert.ToInt32(dgv_RAM.Rows[dgv_RAM.Rows.Count - 1].Cells[0].Value)))
            {
                linhaParaSelecionar = linha;

                dgv_RAM.Rows[linhaParaSelecionar].Selected = true;
            }
        }
        #endregion

        #region  --- Clique ---
        private void Simular_Click(object sender, EventArgs e)
        {
            if (!Valida()) return;
            Limpar();

            int bloco = Convert.ToInt32(txtbox_Bloco.Text);
            int ram = Convert.ToInt32(txtbox_RAM.Text);
            int index = cb_RAM.SelectedIndex;

            double qtdRAM = index == 0 ? (ram / bloco) : (ram * Math.Pow(2, (index * 10)) / bloco);  // Conversão das entradas de dados (Bytes/KBytes..)
            int qtdCache = Convert.ToInt32(txtbox_Cache.Text);

            for (int i = 0; i < qtdRAM; i++)                                                         //
            {                                                                                        //
                MemoriaRAM.Add(new RAM()                                                             //  
                {                                                                                    //
                    Bloco = i,                                                                       //
                    Dado = GerarDadoAleatorio(bloco),                                                         // 
                    Endereço = i * bloco                                                             //  Criação das Memoria RAM e Cache vazias
                });                                                                                  //
            }                                                                                        //
                                                                                                     //
            for (int i = 0; i < qtdCache; i++)                                                       //
            {                                                                                        //
                MemoriaCache.Add(new Cache());                                                       //
            }                                                                                        //

            dgv_RAM.DataSource = MemoriaRAM;
            dgv_Cache.DataSource = MemoriaCache;

            PropriedadeGrid(GetAlgoritmo(), GetTecnica());     // Aplicar customização dos datagridview's de acordo com tipo de algoritmo ou técnica

            txtbox_Acessar.Focus();

            if (!AcessarBlocos)  // Alterar visibilidade do campo de acessar blocos, iniciando animação da posição vertical                                
            {
                AcessarBlocos = true;
                Y_atual = 85;
                t_slide.Start();
            }
        }

        private void Carregar_Click(object sender, EventArgs e)
        {
            // verifica se possui bloco a ser carregado 
            if (txtbox_Acessar.Text == null || txtbox_Acessar.Text == "")
            {
                MetroMessageBox.Show(this, "Não existem blocos para serem carregados", "Impossível carregar o(s) bloco(s)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbox_RAM.Focus();
                return;
            }

            string[] numeros = txtbox_Acessar.Text.Split(',');

            List<string> falhas = new List<string>();
            foreach (var numero in numeros)
            {
                if (string.IsNullOrWhiteSpace(numero))
                    continue;

                if (Convert.ToInt32(numero) < (MemoriaRAM.Count))
                {

                    Blocos.Add(numero.Trim());
                }
                else
                {
                    falhas.Add(numero.Trim());
                }
            }

            if (falhas.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                var plural = falhas.Count > 1 ? "s" : "";
                sb.Append($"Falha ao carregar bloco{plural} ");

                foreach (var num in falhas)
                {
                    sb.Append(num + ",");
                }

                var msgStr = sb.ToString();
                var msg = msgStr.Substring(0, msgStr.Length - 1);
                //MessageBox.Show(final);

                MetroMessageBox.Show(this, msg, $"Tentativa de carregar bloco{plural} não existente{plural}", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbox_RAM.Focus();
            }

            var blocos = (from i in Blocos select new { Value = i }).ToArray();

            dgv_Blocos.DataSource = null;
            dgv_Blocos.DataSource = blocos;
            dgv_Blocos.Focus();

            txtbox_Acessar.Text = null;

            if (blocos.Length > 0)
                selecionarLinhaRAM(Convert.ToInt32(blocos.FirstOrDefault().Value));
        }

        private void btn_CarregarTodos_Click(object sender, EventArgs e)
        {
            int[] quantidade = Enumerable.Range(0, MemoriaRAM.Count).ToArray();

            foreach (var numero in quantidade)
            {
                Blocos.Add($"{numero}");
            }

            var blocos = (from i in Blocos select new { Value = i }).ToArray();

            dgv_Blocos.DataSource = null;
            dgv_Blocos.DataSource = blocos;
            dgv_Blocos.Focus();

            txtbox_Acessar.Text = null;
        }

        private void Acessar_Click(object sender, EventArgs e)
        {
            // verifica se possui bloco a ser carregado
            if (Blocos.Count < 1)
            {
                MetroMessageBox.Show(this, "Não é possível realizar o acesso pois não há blocos carregados", "Impossível realizar o acesso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtbox_RAM.Focus();
                return;
            }

            var tag = Blocos[dgv_Blocos.CurrentCell.RowIndex].ToString();

            Blocos.Remove(tag);

            var blocos = (from i in Blocos select new { Value = i }).ToArray();
            dgv_Blocos.DataSource = null;
            dgv_Blocos.DataSource = blocos;

            dgv_RAM.Rows[ObterIndicePorTag(Convert.ToInt32(tag), dgv_RAM)].Selected = true;

            var temp = new RAM()
            {
                Bloco = Convert.ToInt32(dgv_RAM.SelectedCells[0].Value),
                Dado = dgv_RAM.SelectedCells[1].Value.ToString(),
                Endereço = Convert.ToInt32(dgv_RAM.SelectedCells[2].Value)
            };

            var cache = new Cache()
            {
                Tag = temp.Bloco,
                Bloco = temp.Dado,
                HoraCarregada = DateTime.Now,
                HoraUsada = DateTime.Now,
                Contador = 1
            };

            // Histórico de acessos
            StringBuilder str = new StringBuilder();
            str.Append($" - {tag}{label_Historico.Text}");
            label_Historico.Text = str.ToString();

            // Verifica se o bloco a ser carergado já está armazenado na cache
            // e caso já exista, atualiza os valores de contagem, horario acessado etc e da return por não ter necessidade de aplicar técnica
            if (CachePossuiDado(cache))
            {
                label_Check.ForeColor = System.Drawing.Color.Red;
                Notificar("HIT");
                return;
            }
            else
            {
                label_Check.ForeColor = System.Drawing.Color.Silver;
                Notificar("MISS");
            }

            switch (cb_Tecnica.SelectedIndex)
            {
                case Tecnica.Direta:
                    {
                        string algoritmo = GetAlgoritmo();
                        int tecnica = Tecnica.Direta;

                        int linha = temp.Bloco % Convert.ToInt32(txtbox_Cache.Text);
                        TecnicaDireta(cache, linha);
                        PropriedadeGrid(algoritmo, tecnica);
                    }
                    break;
                case Tecnica.Associativa:
                    {
                        string algoritmo = GetAlgoritmo();
                        int tecnica = Tecnica.Associativa;

                        TecnicaAssociativa(cache, algoritmo);
                        PropriedadeGrid(algoritmo, tecnica);
                    }
                    break;
                case Tecnica.AssociativaConjuntoNPos:
                    {
                        string algoritmo = GetAlgoritmo();
                        int tecnica = Tecnica.AssociativaConjuntoNPos;

                        int nPos = Convert.ToInt32(txtbox_nPos.Text);

                        TecnicaAssociativaConjuntoNPos(cache, algoritmo, nPos);
                        PropriedadeGrid(algoritmo, tecnica);
                    }
                    break;
            }

            dgv_Blocos.Focus();
        }

        private void Tecnica_Select(object sender, EventArgs e)
        {
            if (cb_Tecnica.SelectedIndex == Tecnica.Direta)
            {
                cb_Algoritmo.Enabled = false;
            }
            else
            {
                cb_Algoritmo.Enabled = true;
            }

            if (cb_Tecnica.SelectedIndex == Tecnica.AssociativaConjuntoNPos)
            {
                txtbox_nPos.Visible = true;
                lbl_nPos.Visible = true;
            }
            else
            {
                txtbox_nPos.Visible = false;
                lbl_nPos.Visible = false;
            }
        }

        private void Limpar_Click(object sender, EventArgs e)
        {
            Limpar();

            txtbox_RAM.Focus();

            if (AcessarBlocos)
            {
                AcessarBlocos = false;
                Y_atual = 142;
                t_slide.Start();
            }
        }

        private void dgv_Blocos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selecionarLinhaRAM(Convert.ToInt32(dgv_Blocos.Rows[e.RowIndex].Cells[0].Value));
        }

        private void btn_LimparBlocos_Click(object sender, EventArgs e)
        {
            Blocos.Clear();
            dgv_Blocos.DataSource = null;
        }
        #endregion

        #region --- Animações ---
        bool AcessarBlocos;
        int Y_atual;
        private void t_slide_Tick(object sender, EventArgs e)
        {
            if (AcessarBlocos)
            {
                Y_atual += 2;
                if (Y_atual <= 142)
                    painel_Carregar.Location = new Point(painel_Carregar.Location.X, Y_atual);
                else
                    t_slide.Stop();

                return;
            }

            Y_atual -= 2;
            if (Y_atual >= 70)
                painel_Carregar.Location = new Point(painel_Carregar.Location.X, Y_atual);
            else
                t_slide.Stop();

        }

        private void Notificar(string notify)
        {
            if (t_check.Enabled)
                t_check.Stop();

            label_Check.Text = notify;
            t_check.Start();
        }

        private void t_check_Tick(object sender, EventArgs e)
        {
            label_Check.Text = "";
            t_check.Stop();
        }

        private void txtbox_nPos_Click(object sender, EventArgs e)
        {
            if (txtbox_nPos.Text == "N")
                txtbox_nPos.Text = "";
        }

        private void txtbox_nPos_Leave(object sender, EventArgs e)
        {
            if (txtbox_nPos.Text == "")
                txtbox_nPos.Text = "N";
        }
        #endregion

    }
}