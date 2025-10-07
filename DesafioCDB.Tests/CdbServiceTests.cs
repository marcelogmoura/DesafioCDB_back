using DesafioCDB.Domain.Dtos.Requests;
using DesafioCDB.Domain.Services;
using Xunit; 

namespace DesafioCDB.Tests.Domain.Services
{    
    public class CdbServiceTests
    {
        private readonly CdbService _cdbService;
                
        public CdbServiceTests()
        {
            _cdbService = new CdbService();
        }
        
        [Fact]
        [Trait("Categoria", "Cálculo Completo")]
        public void CalcularCDB_PrazoAcimaDe24Meses_DeveAplicarAliquotaDe15Porcento()
        {            
            var request = new CdbRequest { ValorInicial = 1000.00M, PrazoEmMeses = 30 };

            var response = _cdbService.CalcularCDB(request);

            Assert.True(response.ResultadoBruto > 1279.10M && response.ResultadoBruto < 1279.20M);
            Assert.True(response.ResultadoLiquido > 1237.20M && response.ResultadoLiquido < 1237.35M);
                        
            Assert.Equal(1279.16M, response.ResultadoBruto);
            Assert.Equal(1237.29M, response.ResultadoLiquido);
        }       

        [Theory]
        [InlineData(6, 22.50)] 
        [InlineData(7, 20.00)] 
        [InlineData(12, 20.00)]
        [InlineData(13, 17.50)]
        [InlineData(24, 17.50)]
        [InlineData(25, 15.00)]
        [Trait("Categoria", "Imposto de Renda")]
        public void CalcularCDB_DiferentesPrazos_DeveAplicarAliquotaIRCorreta(int prazoEmMeses, decimal aliquotaEsperada)
        {
            var request = new CdbRequest { ValorInicial = 1000.00M, PrazoEmMeses = prazoEmMeses };

            var response = _cdbService.CalcularCDB(request);

            decimal rendimentoBruto = response.ResultadoBruto - request.ValorInicial;
            decimal irCalculado = response.ResultadoBruto - response.ResultadoLiquido;
            decimal aliquotaCalculada = Math.Round((irCalculado / rendimentoBruto) * 100, 2);

            Assert.Equal(aliquotaEsperada, aliquotaCalculada);
        }       

        [Fact]
        [Trait("Categoria", "Validação")]
        public void CalcularCDB_PrazoMenorOuIgualAUm_DeveSerValidadoNoControllerOuRequest()
        {
            var requestComPrazo1 = new CdbRequest { ValorInicial = 1000.00M, PrazoEmMeses = 1 };
            
            var response = _cdbService.CalcularCDB(requestComPrazo1);
            Assert.Equal(22.50M, Math.Round(((response.ResultadoBruto - response.ResultadoLiquido) / (response.ResultadoBruto - 1000.00M)) * 100, 2));
        }

        
    }
}