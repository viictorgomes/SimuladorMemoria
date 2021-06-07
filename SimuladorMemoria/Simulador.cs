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
            // valores de input do caso de teste
            // blocos a carregar: 3, 11, 19, 3, 27, 11, 35, 9, 11
            txtbox_RAM.Text = "2048";
            txtbox_Bloco.Text = "32";
            txtbox_Cache.Text = "32";
            txtbox_nPos.Text = "4";

            cb_RAM.SelectedIndex = 0;
            cb_Bloco.SelectedIndex = 0;

            cb_Tecnica.SelectedIndex = 0;
            cb_Algoritmo.SelectedIndex = 0;

            txtbox_RAM.Focus();
        }
        #endregion

        #region --- Tecnica ---
        private void TecnicaAssociativaConjuntoNPos(Cache bloco, string algoritmo, int nPos)
        {
            var quantidadeConjuntos = Convert.ToInt32(txtbox_Cache.Text) / nPos;
            int conjuntoDestino = Convert.ToInt32(bloco.Bloco) % quantidadeConjuntos; // descobrir o conjunto destino, bloco % quantidade de conjuntos

            int linhaSelecionada = 0;

            Dictionary<int, Cache> cacheEmUso = new Dictionary<int, Cache>(); // Variavel para armazenar dados do conjunto destino que estão em uso na cache

            List<int> blocosVazios = new List<int>();

            bool Adicionado = false; // Utilizado posteriormente para saber se um conjunto está cheio ou não, para determinar se é necessário o uso de algoritmo de substituição

            for (int j = 0; j < nPos; j++) // Passar por cada elemento de 1 conjunto de nPos elementos
            {
                int indexConjuntoDestino = (conjuntoDestino * nPos); // Obter o indice em que o conjunto começa
                int indiceDoBlocoNoConjunto = indexConjuntoDestino + j; // Indice do bloco dentro do conjunto

                if (indiceDoBlocoNoConjunto > MemoriaCache.Count)
                    throw new Exception("Overflow: IndiceDoElementoNoConjunto > MemoriaCache.Count");

                if (string.IsNullOrEmpty(MemoriaCache[indiceDoBlocoNoConjunto].Dado)) // Se o indice do bloco dentro do conjunto estiver vazio, incluir este indice na lista blocosVazios
                {
                    blocosVazios.Add(indiceDoBlocoNoConjunto);
                }

                cacheEmUso[indiceDoBlocoNoConjunto] = MemoriaCache[indiceDoBlocoNoConjunto]; // Armazena dados que estão atualmente na cache no dicionario cacheEmUso para depois
                                                                                             // atualizar a cache com as informações contidas em cacheEmUso
            }

            if (blocosVazios.Count != 0)
            {
                var blocosVaziosShuffle = blocosVazios.OrderBy(a => random.Next()).ToList(); // Cria uma nova lista e popula essa lista com os elementos de blocoVazios de forma aleatoria
                int indiceAleatorioDoBlocoNoConjunto = blocosVaziosShuffle.First();         // após gerado a lista acima, obter o indice do primeiro elemento da lista

                MemoriaCache[indiceAleatorioDoBlocoNoConjunto] = bloco;  // Armazena o bloco desejado no indice acima
                linhaSelecionada = indiceAleatorioDoBlocoNoConjunto;

                Adicionado = true; // Se o bloco for armazenado, não há necessidade de algoritmo de substituição

                blocosVazios.Remove(indiceAleatorioDoBlocoNoConjunto); // Remover indice do bloco vazio utilizado, para este não estar mais incluído nos blocos vazios nas proximas buscas
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
            if (String.IsNullOrEmpty(txtbox_RAM.Text.ToString()) || String.IsNullOrEmpty(txtbox_Bloco.Text.ToString()) || String.IsNullOrEmpty(txtbox_Cache.Text.ToString()) ||
                !txtbox_RAM.Text.ToString().All(char.IsDigit) || !txtbox_Bloco.Text.ToString().All(char.IsDigit) || !txtbox_Cache.Text.ToString().All(char.IsDigit)){
                
                MetroMessageBox.Show(this, "É necessário preenchimento de todos os campos com valores numéricos não negativos", "Valores inválidos!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //pega o valor em bytes da ram e bloco
            double ram = Convert.ToInt32(txtbox_RAM.Text);
            double bloco = Convert.ToInt32(txtbox_Bloco.Text);

            //verifica se o bloco é maior que a ram
            if (bloco > ram)
            {
                MetroMessageBox.Show(this, "A memória RAM deve ser maior que o tamanho do bloco.", "Valores inválidos!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbox_Bloco.Focus();
                return false;
            }

            string nPos = txtbox_nPos.Text;

            if (!nPos.All(char.IsDigit) || !PotenciaDe2(Convert.ToInt32(nPos)))
            {
                MetroMessageBox.Show(this, "O valor de N Pos precisa ser uma potência de 2", "Impossível realizar a simulação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbox_nPos.Focus();
                return false;
            }

            return true;
        }

        private bool PotenciaDe2(int x)
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

        private int ObterIndicePorBloco(int bloco, DataGridView dgv)
        {
            return (dgv.Rows.Cast<DataGridViewRow>()
                                   .Where(r => Convert.ToInt32(r.Cells[0].Value) == bloco)
                                   .Select(r => r.Index)).First();
        }

        private void PropriedadeGrid(string algoritmo = "")
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

            switch (algoritmo)
            {
                case Algoritmo.LRU:
                    dgv_Cache.Columns[1].Width = 200;
                    break;
                case Algoritmo.LFU:
                    dgv_Cache.Columns[1].Width = 230;
                    break;
                case Algoritmo.FIFO:
                    dgv_Cache.Columns[1].Width = 175;
                    break;
            }

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

        private bool CachePossuiDado(Cache cache)
        {
            //Verifica se Memoria Cache já possui o dado recebido pelo parametro(com base no bloco), e caso positivo, altera o contador e hora usada
            var dadoJaExistenteNaCache = MemoriaCache.Where(d => d.Bloco == cache.Bloco).FirstOrDefault();

            if (dadoJaExistenteNaCache != null) // Se encontrar o dado recebido por parametro, atualizar o bloco e selecionar a linha do bloco
            {
                dadoJaExistenteNaCache.HoraUsada = DateTime.Now;
                dadoJaExistenteNaCache.Contador++;
                dgv_Cache.DataSource = null;
                dgv_Cache.DataSource = MemoriaCache;
                dgv_Cache.Focus();

                PropriedadeGrid(ObterAlgoritmo());

                dgv_Cache.Rows[ObterIndicePorBloco(Convert.ToInt32(dadoJaExistenteNaCache.Bloco), dgv_Cache)].Selected = true;
                return true;
            }

            PropriedadeGrid(ObterAlgoritmo());

            return false;
        }

        private string ObterAlgoritmo()
        {
            //retorna qual o algoritmo de substituição está sendo usado
            string algoritmo = "";

            switch (cb_Algoritmo.SelectedIndex)
            {
                case 0: { algoritmo = Algoritmo.LRU; } break;
                case 1: { algoritmo = Algoritmo.LFU; } break;
                case 2: { algoritmo = Algoritmo.FIFO; } break;
            }

            return algoritmo;
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

            double qtdRAM = ram / bloco;  // Conversão das entradas de dados (Bytes/KBytes..)
            int qtdCache = Convert.ToInt32(txtbox_Cache.Text);

            for (int i = 0; i < qtdRAM; i++)             //
            {                                            //
                MemoriaRAM.Add(new RAM()                 //  
                {                                        //
                    Bloco = i,                           //
                    Dado = GerarDadoAleatorio(bloco),    // 
                    Endereço = i * bloco                 //  Criação das Memoria RAM e Cache vazias
                });                                      //
            }                                            //
                                                         //
            for (int i = 0; i < qtdCache; i++)           //
            {                                            //
                MemoriaCache.Add(new Cache());           //
            }                                            //

            dgv_RAM.DataSource = MemoriaRAM;        // popular datagridviews
            dgv_Cache.DataSource = MemoriaCache;

            PropriedadeGrid(ObterAlgoritmo());     // Aplicar customização dos datagridview's de acordo com tipo de algoritmo ou técnica

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
            // validação do bloco a ser carregado
            if (String.IsNullOrEmpty(txtbox_Acessar.Text))
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

            var bloco = Blocos[dgv_Blocos.CurrentCell.RowIndex].ToString();

            Blocos.Remove(bloco);

            var blocos = (from i in Blocos select new { Value = i }).ToArray();
            dgv_Blocos.DataSource = null;
            dgv_Blocos.DataSource = blocos;

            dgv_RAM.Rows[ObterIndicePorBloco(Convert.ToInt32(bloco), dgv_RAM)].Selected = true;

            var temp = new RAM()
            {
                Bloco = Convert.ToInt32(dgv_RAM.SelectedCells[0].Value),
                Dado = dgv_RAM.SelectedCells[1].Value.ToString(),
                Endereço = Convert.ToInt32(dgv_RAM.SelectedCells[2].Value)
            };

            var cache = new Cache()
            {
                Bloco = temp.Bloco,
                Dado = temp.Dado,
                HoraCarregada = DateTime.Now,
                HoraUsada = DateTime.Now,
                Contador = 1
            };

            // Histórico de acessos
            StringBuilder str = new StringBuilder();
            str.Append($" - {bloco}{label_Historico.Text}");
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

            
            string algoritmo = ObterAlgoritmo();
            int tecnica = Tecnica.AssociativaConjuntoNPos;

            int nPos = Convert.ToInt32(txtbox_nPos.Text);

            TecnicaAssociativaConjuntoNPos(cache, algoritmo, nPos);
            PropriedadeGrid(algoritmo);

            dgv_Blocos.Focus();
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