namespace SimuladorCalor
{
    public partial class Form1 : Form
    {
        private Simulador simulador;
        private int linhaSelecionada = -1;
        private int colunaSelecionada = -1;
        private double escalaMin;
        private double escalaMax;
        private Random aleatorio = new Random();

        public Form1()
        {
            InitializeComponent();
        }


        private void btnCriar_Click(object sender, EventArgs e)
        {
            timer1.Stop(); // se a simulacao estiver rodando e o usuario quiser uma nova matriz, o timer para
            btnIniciar.Text = "Iniciar";

            int n = (int)numN.Value; // o valor  do NumericUpDown é decimal, o (int) converte pra inteiro, do jeito que o simuladorp precisa 
            double lado = (double)numLado.Value; // mesma coisa, mas agora convertendo para double
            Material material = (Material)cmbMaterial.SelectedItem; // a box guarda os itens como generico. o (Material) serve para puxar um material colocado na box 
            double temperatura = (double)numTemp.Value;

            simulador = new Simulador(n, material, lado, temperatura); // cria uma nova matriz com os cubos iguais 

            if (chkAleatorio.Checked) // checa se o usuario pediu temperaturas aleatorias 
            {
                foreach (Corpo c in simulador.Corpos) // percorre todos os cubos e soma um numero entre -100 e 100 na temperatura 
                {
                    c.Temperatura = Math.Max(1, temperatura + aleatorio.Next(-100, 101)); // o Math.max garante que nao tenha nenhum numero abaixo de 1K, porque em kelvin a temperatura nao e negativa nem 0 
                }
            }

            linhaSelecionada = -1; // limpa a linha e mostra que nenhum cubo foi selecionado 
            colunaSelecionada = -1; // mesma coisa para a coluna 
            escalaMin = simulador.MenorTemperatura(); // guarda a menor temperatura da matriz
            escalaMax = simulador.MaiorTemperatura(); // guarda a maior temperatura da matriz 
            picGrade.Invalidate(); // avisa o picture box para redesenhar uma nova matriz 
            AtualizarStatus();
        }


        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (simulador == null || linhaSelecionada < 0) // se nenhum cubo foi clicado, avisa ao usuario e sai 
            {
                MessageBox.Show("Clique em um cubo primeiro.");
                return;
            }

            Corpo c = simulador.Corpos[linhaSelecionada, colunaSelecionada]; // pega o cubo selecionado
            c.Material = (Material)cmbMaterialCorpo.SelectedItem; // troca o material do cubo
            c.Temperatura = (double)numTempCorpo.Value; // troca a temperatura, convertendo para double 

            escalaMin = simulador.MenorTemperatura(); // recalcula a escala das cores 
            escalaMax = simulador.MaiorTemperatura();
            AtualizarInfo(); // atualiza 
            picGrade.Invalidate(); // redesenha 
            AtualizarStatus();
        }
        

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (simulador == null) // se a matriz nao foi criada, sai 
            {
                MessageBox.Show("Crie a matriz primeiro.");
                return;
            }

            if (timer1.Enabled) // verifica se a simulacao ja esta rodfando
            {
                timer1.Stop(); // se estava rodando, pausa, e o botao diz Iniciar 
                btnIniciar.Text = "Iniciar";
            }
            else
            {
                timer1.Start();
                btnIniciar.Text = "Pausar"; // se estiver parado, aciona o botao, e ele diz Pausar  
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Material m in Material.Todos)
            {
                cmbMaterial.Items.Add(m);
                cmbMaterialCorpo.Items.Add(m);
            }
            cmbMaterial.SelectedIndex = 0;
            cmbMaterialCorpo.SelectedIndex = 0;
        }

        private void picGrade_Paint(object sender, PaintEventArgs e)
        {
            if (simulador == null) return; // se a matriz ainda nao foi criada, ele sai do metodo 

            float tamanho = Math.Min(picGrade.Width, picGrade.Height) / (float)simulador.N; // o tamanho de cada quadrado em pixel. pega o menor lado da pagina e divide por N

            for (int i = 0; i < simulador.N; i++) // percorrem a matriz
            {
                for (int j = 0; j < simulador.N; j++)
                {
                    Corpo c = simulador.Corpos[i, j];
                    float x = j * tamanho; //posicao do quadrado na tela ---- x = horizontal,  y = vertical 
                    float y = i * tamanho;

                    using (SolidBrush pincel = new SolidBrush(CorDaTemperatura(c.Temperatura))) // pinta o quadrado de acordo com a cor da temperatura -- using solid brush libera o pincel da memoria depois de usado 
                        e.Graphics.FillRectangle(pincel, x, y, tamanho, tamanho);
                    e.Graphics.DrawRectangle(Pens.Black, x, y, tamanho, tamanho); // desenha a borda do retangulo

                    string texto = c.Material.Nome + "\n" + c.Temperatura.ToString("F1") + " K";
                    e.Graphics.DrawString(texto, Font, Brushes.White, x + 3, y + 3); // escreve o nome do material e a temperatura -- "F1" = 1 casa decimal
                }
            }

            if (linhaSelecionada >= 0)
            {
                using (Pen caneta = new Pen(Color.Yellow, 4))
                    e.Graphics.DrawRectangle(caneta, colunaSelecionada * tamanho, linhaSelecionada * tamanho, tamanho, tamanho); // se tiver um cubo selecionado, desenha uma borda em volta para dar contraste e mopstrar que foi selecionadop 
            }
        }
        private Color CorDaTemperatura(double temperatura)
        {
            double t = 0.5; // transforma a temperatura em um numero de 0 a 1 , sendo 0 a mais fria e 1 a mais quente 
            if (escalaMax > escalaMin) // se tiver temperaturas iguais, ocorreria um erro, assim ele mantem no 0.5 
                t = (temperatura - escalaMin) / (escalaMax - escalaMin);
            t = Math.Max(0, Math.Min(1, t)); // garante que o t fica entre o 0 e 1

            int vermelho = (int)(255 * t);
            int azul = (int)(255 * (1 - t));
            return Color.FromArgb(vermelho, 0, azul); // retorna a cor das temperaturas 
        }

        private void picGrade_MouseClick(object sender, MouseEventArgs e)
        {
            if (simulador == null) return; // se a matriz nao foi criada, sai do metodo 

            float tamanho = Math.Min(picGrade.Width, picGrade.Height) / (float)simulador.N; // tamanho de cada quadrado em pixel
            int coluna = (int)(e.X / tamanho); // descobre a coluna em que foi clicada dividindo o X do mouse pelo tamanho do quadrado
            int linha = (int)(e.Y / tamanho);
            if (linha >= simulador.N || coluna >= simulador.N) return; // se o clique foi fora da grade, ignora 

            linhaSelecionada = linha; // guarda qual cubo foi selecionado 
            colunaSelecionada = coluna;

            Corpo c = simulador.Corpos[linha, coluna]; // pega o cubo clicado na matriz 
            cmbMaterialCorpo.SelectedItem = c.Material; // mostra na caixa o material atual do cubo
            numTempCorpo.Value = (decimal)Math.Min(5000, c.Temperatura); // mostra a temperatura atual

            AtualizarInfo(); // atualiza o texto com dados do cubo
            picGrade.Invalidate(); // redesenha a grade pra aparecer a borda amarela 
        }
        private void AtualizarInfo() // mostra os dados do cubo
        {
            if (simulador == null || linhaSelecionada < 0) // se nao tem cubo selecionado, devolve ao usuario que nao tem nenhum cubo selecionado
            {
                lblInfo.Text = "Nenhum cubo selecionado";
                return;
            }

            Corpo c = simulador.Corpos[linhaSelecionada, colunaSelecionada]; // pega o cubo selecionado
            lblInfo.Text = "Posição: linha " + (linhaSelecionada + 1) + ", coluna " + (colunaSelecionada + 1) + "\n" // monta o texto com a posicao, o material, a temperatura, a massa e o calor sensivel 
                         + "Material: " + c.Material.Nome + "\n"
                         + "Temperatura: " + c.Temperatura.ToString("F2") + " K\n"
                         + "Massa: " + c.Massa.ToString("F3") + " kg\n"
                         + "Calor sensível: " + c.CalorSensivel.ToString("N0") + " J";
        }

        private void timer1_Tick(object sender, EventArgs e) // executado automatico a cada 50ms enquanto o timer esta ligado 
        {
            int passos = (int)numPassos.Value; // le a velocidade escolhida
            for (int p = 0; p < passos; p++) // roda varios passos de 1 segundo para poder atualizar - os passos pequenos facilitam os calculos 
                simulador.Passo(1.0);
            
            // atualiza os textos, desenhos e cores 
            AtualizarInfo();
            AtualizarStatus();
            picGrade.Invalidate();

            if (simulador.MaiorTemperatura() - simulador.MenorTemperatura() < 0.01) // se a diferenca entre a maior e a menor temperatura for menor que 0,01 K, o equilibrio termico foi atingido
            {
                timer1.Stop();
                btnIniciar.Text = "Iniciar";
                MessageBox.Show("Equilíbrio térmico atingido em " + simulador.TempoSimulado.ToString("N0") + " s simulados."); // para a simulacao e mostra quanto tempo demorou
            }
        }
        private void AtualizarStatus() // mostra o resumo da simulacao 
        {
            lblStatus.Text = "Tempo simulado: " + simulador.TempoSimulado.ToString("N0") + " s\n"
                           + "Menor temperatura: " + simulador.MenorTemperatura().ToString("F2") + " K\n"
                           + "Maior temperatura: " + simulador.MaiorTemperatura().ToString("F2") + " K\n"
                           + "Calor total: " + simulador.CalorTotal().ToString("N0") + " J";
        }
    }
}
