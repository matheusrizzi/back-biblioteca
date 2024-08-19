namespace Basis.BibliotecaVirtual.Domain.Entities
{
    public class Livro_Assunto
    {
        public Livro_Assunto()
        {
        }

        public Livro_Assunto(int livroCodL, int assuntoCodAs)
        {
            LivroCodL = livroCodL;
            AssuntoCodAs = assuntoCodAs;
        }

        public int LivroCodL { get; set; }
        public int AssuntoCodAs { get; set; }
        public Livro Livro { get; set; }
        public Assunto Assunto { get; set; }
    }
}
