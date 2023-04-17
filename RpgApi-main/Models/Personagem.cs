using RpgApi.Models.Enuns;

namespace RpgApi.Models
{
    public class Personagem
    {
        public int Id { get; set; }
        private string nome = "Desconhecido";
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        
        public int PontosVida { get; set; }
        public int Forca { get; set; }
        public int Defesa { get; set; }
        public int Inteligencia { get; set; }
        public ClasseEnum Classe { get; set; }

    }
}