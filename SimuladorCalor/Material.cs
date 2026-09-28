using System.Collections.Generic;

namespace SimuladorCalor
{
    public class Material
    {
        public string Nome { get; set; } // o nome do material 
        public double K { get; set; } // é a condutividade térmica em W/(m . K). O quão rapido o calor passa no material 
        public double Densidade { get; set; } // Densidade (p), serve para calcular a massa, ja que o usuario informa apenas o lado do cubo kg/m³
        public double CalorEspecifico { get; set; } // calor especifico (c) em J/(kg . K): energia necessaria pra esquentar 1kg de material em 1 K. usado no calor sensivel ( Q = m . c . ΔT) 

        public Material(string nome, double k , double densidade, double calorEspecifico) // construtor do material 
        {
            Nome = nome; // guarda na propriedade o valor que veio do parametro 
            K = k;
            Densidade = densidade;
            CalorEspecifico = calorEspecifico;
        }

        public override string ToString() // responsavel por mostrar o nome do material 
        {
            return Nome;
        }

        public static List<Material> Todos = new List<Material> // é a lista com todos os materiais disponiveis 
        {
            //            Nome       k      ρ      c                          
            new Material("Cobre",   401,  8960,  385),
            new Material("Madeira", 0.15,  600, 1700),
            new Material("Granito", 2.8,  2700,  790),
            new Material("Concreto", 1.4, 2300,  880),
            new Material("Chumbo",   35,  11340,  129),
            new Material("Prata",   429,  10490,  235),
            new Material("Ouro",    318,  19300,  129),
            new Material("Tungstenio", 173,  19300, 134),
            new Material("Aluminio", 237,  2700,  897),
            new Material("Latao",   109,  8530,  380),
        };
    }
}