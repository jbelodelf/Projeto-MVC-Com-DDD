
using JoseBeloDelfino.DTOs;
using System.Collections.Generic;

namespace JoseBeloDelfino.Data.Interfaces
{
    public interface IAmigoRepositorio
    {
        IList<AmigoDTO> ListarAmigos(double latitude, double longitude);

        AmigoDTO ObterAmigos(int id);
    }
}