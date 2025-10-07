using DesafioCDB.Domain.Dtos.Requests;
using DesafioCDB.Domain.Dtos.Responses;
using DesafioCDB.Domain.Interfaces.Services;

namespace DesafioCDB.Domain.Services
{    
    public class CdbService : ICdbService
    {
        // Valores fixos para o exercício.
        private const decimal TB = 1.08M; // 108% (1.08)
        private const decimal CDI = 0.009M; // 0,9% (0.009)

        public CdbResponse CalcularCDB(CdbRequest request)
        {
            // 1. Cálculo do Valor Bruto (VF) - Capitalização Composta Mês a Mês
            decimal valorFinalBruto = CalcularValorBruto(request.ValorInicial, request.PrazoEmMeses);

            // 2. Cálculo do Imposto de Renda (IR)
            decimal rendimentoBruto = valorFinalBruto - request.ValorInicial;
            decimal irPorcentagem = ObterAliquotaIR(request.PrazoEmMeses);
            decimal valorIR = rendimentoBruto * irPorcentagem;

            // 3. Cálculo do Valor Líquido
            decimal valorFinalLiquido = valorFinalBruto - valorIR;
                        
            return new CdbResponse
            {
                ResultadoBruto = valorFinalBruto,
                ResultadoLiquido = valorFinalLiquido
            };

            
            
        }
               

        private decimal CalcularValorBruto(decimal valorInicial, int prazoEmMeses)
        {
            // A fórmula aplicada a cada mês, usando o resultado anterior 
            decimal valorAcumulado = valorInicial;

            for (int mes = 0; mes < prazoEmMeses; mes++)
            {
                // VF = VI * [1 + (CDI * TB)]
                valorAcumulado = valorAcumulado * (1 + (CDI * TB));
            }

            // duas casas decimais
            return Math.Round(valorAcumulado, 2);
        }

        private decimal ObterAliquotaIR(int prazoEmMeses)
        {
            // Tabela regressiva de IR.
            if (prazoEmMeses <= 6)
            {
                return 0.225M; // 22,5%
            }
            else if (prazoEmMeses <= 12)
            {
                return 0.20M; // 20%
            }
            else if (prazoEmMeses <= 24)
            {
                return 0.175M; // 17,5%
            }
            else // +24 meses
            {
                return 0.15M; // 15%
            }
        }
    }
}