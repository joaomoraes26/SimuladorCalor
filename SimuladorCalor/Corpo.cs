namespace SimuladorCalor
{
    public class Corpo
    {
        public Material Material { get; set; } // o material do cubo, que pode ser trocado depois
        public double Lado { get; set; } // o tamanhoda aresta do cubo em metros (m)
        public double Temperatura { get; set; } // temperatura atual em Kelvin

        public Corpo(Material material, double lado, double temperatura) // obrigatorio informar material, lado e temperatura 
        { // guarda na propriedade, o valor que veio do parametro
            Material = material;
            Lado = lado;
            Temperatura = temperatura;
        }


        // => faz com que o valor seja recaulculado sempre, assim, sempre que mudar o lado ou o material, vai se atualizando automatico 
        public double Volume => Lado * Lado * Lado; // fórmula do volume (V = L³, em m³)
        public double Massa => Material.Densidade * Volume; // formula da massa, onde (M = P * V) em kg
        public double AreaFace => Lado * Lado; // Area da face,  fórmula (A = L²): e a area de contato com o cubo vizinho 
        public double CalorSensivel => Massa * Material.CalorEspecifico * Temperatura; // formula: (Q = m * c * T) em Joules - E a energia guardada no cubo, de 0 K a temperatura atual 

        public void ReceberCalor(double energia) // metodo para receber o calor de um cubo para o outro. o cubo recebe positivo ou cede negativo em Joules 
        {
            Temperatura += energia / (Massa * Material.CalorEspecifico); // atualiza a temperatura do cubo 

            // formula do calor sensivel , isolando o ΔT
        }
    }
}
