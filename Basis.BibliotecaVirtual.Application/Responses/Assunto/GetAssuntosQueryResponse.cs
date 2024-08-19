using System.ComponentModel.DataAnnotations;

namespace Basis.BibliotecaVirtual.Application.Responses.Assunto;

public class GetAssuntosQueryResponse
{
    public int CodAs { get; set; }
    public string Descricao { get; set; }
}