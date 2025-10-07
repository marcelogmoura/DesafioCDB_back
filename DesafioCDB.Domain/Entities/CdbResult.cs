namespace DesafioCDB.Domain.Entities
{
    public class CdbResult
    {
        // Propriedade para o valor final sem a dedução do IR.
        public decimal ValorBruto { get; private set; }

        // Propriedade para o valor final após a dedução do IR.
        public decimal ValorLiquido { get; private set; }

        // Propriedade para o valor do imposto deduzido.
        public decimal ValorIR { get; private set; }

        // Construtor privado para forçar a criação via método estático ou factory,
        // garantindo que os resultados sejam calculados antes da criação do objeto.
        private CdbResult(decimal valorBruto, decimal valorLiquido, decimal valorIr)
        {
            ValorBruto = valorBruto;
            ValorLiquido = valorLiquido;
            ValorIR = valorIr;
        }

        // Método estático de fábrica para criar a entidade com os valores calculados.
        public static CdbResult Create(decimal valorBruto, decimal valorLiquido, decimal valorIr)
        { 
            return new CdbResult(valorBruto, valorLiquido, valorIr);
        }
    }
}