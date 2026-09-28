using System;

namespace SimuladorCalor
{
    public class Simulador
    {
        public Corpo[,] Corpos { get; private set; } // a matriz de cubos 
        public int N { get; private set; } // o tamanho da matriz (N linhas e N coluans)
        public double TempoSimulado { get; private set; } // tempo da simulação em segundos 

        public Simulador(int n, Material material, double lado, double temperatura) // cria a matriz com todos os cubos iguais 
        {
            N = n; // guarda o tamanho 
            Corpos = new Corpo[n, n]; // cria a matriz vazia 
            for (int i = 0; i < n; i++) // um percorre as linhas e outro as colunas 
            {
                for (int j = 0; j < n; j++) 
                {
                    Corpos[i, j] = new Corpo(material, lado, temperatura); // cria um cubo em cada posicao 
                }
            }
        }

        public static double CalcularFluxo(Corpo a, Corpo b) // Lei de Fourrier,  retorna em W (Joules/segundo)
        {
            double k = Math.Min(a.Material.K, b.Material.K); // usa o menor k dos dois 
            double lado = Math.Min(a.Lado, b.Lado); // se os tamanhos sao diferentes, pega o lado do menor 
            double area = lado * lado; // A = L²
            double deltaT = a.Temperatura - b.Temperatura; // diferenca de temperatura entre os dois cubos em K 
            return k * area * deltaT; // o sinal define o sentido - Positivo: calor vai de A pra B.  Negativo de B pra A 
        }

        public void Passo(double dt) // avanca a simulacao em segundos (dt = Δt)
        {
            double[,] energia = new double[N, N]; // matriz que antoa quanto cada cubo ganha ou perde no passo em J 

            for (int i = 0; i < N; i++) //percorrem todos os cubos
            {
                for (int j = 0; j < N; j++) 
                {
                    if (j + 1 < N) // checa se existe cubo a direita 
                    {
                        double e = CalcularFluxo(Corpos[i, j], Corpos[i, j + 1]) * dt;
                        energia[i, j] -= e;
                        energia[i, j + 1] += e;
                    }
                    if (i + 1 < N) // checa se existe cubo a baixo  -para nao calcular o mesmo par de cubo duas vezes 
                    {
                        double e = CalcularFluxo(Corpos[i, j], Corpos[i + 1, j]) * dt; // a equacao da Joules/segundo, multiplicando pelo tempo do passo, tem a energia em Joule 
                        energia[i, j] -= e; // um cubom perde energia, o outroi ganha energia, assim a energia se conserva 
                        energia[i + 1, j] += e;
                    }
                }
            }

            for (int i = 0; i < N; i++) // aplica a energia em cada cubo apenas no final, pra nao influenciar no resultado da simualcao
                for (int j = 0; j < N; j++)
                    Corpos[i, j].ReceberCalor(energia[i, j]);

            TempoSimulado += dt; // soma o tempo que durou o experimento 
        }

        public double MenorTemperatura() // retorna a menor temperatura da matriz em K 
        {
            double menor = double.MaxValue; // comeca com o maior valor possivel 
            foreach (Corpo c in Corpos) // percorre todos os cubos da matriz 
                menor = Math.Min(menor, c.Temperatura); // compara e guarda sempre a menor encontrada 
            return menor; // retorna a menor temperatura 
        }

        public double MaiorTemperatura() // retorna a maior temperatura da matriz em K
        {
            double maior = double.MinValue; // comeca com o menor valor possivel 
            foreach (Corpo c in Corpos) // percorre todos os cubos da matriz 
                maior = Math.Max(maior, c.Temperatura); // compara e guarda a maior encontrada 
            return maior; // retorna a maior temperatura 
        }

        public double CalorTotal() // soma o calor sensivel de todos os cubos e devolve em Joules 
        {
            double total = 0; // comeca a soma com 0
            foreach (Corpo c in Corpos) // percorre todos os cubos 
                total += c.CalorSensivel; // soma o calor sensivel de cada cubo
            return total; // retorna o total 
        }
    }
}