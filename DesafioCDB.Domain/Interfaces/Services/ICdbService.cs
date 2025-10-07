using DesafioCDB.Domain.Dtos.Requests;
using DesafioCDB.Domain.Dtos.Responses;

namespace DesafioCDB.Domain.Interfaces.Services
{
    public interface ICdbService
    {
        CdbResponse CalcularCDB(CdbRequest request);
    }
}
