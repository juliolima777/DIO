namespace DIO.Series


{
    public class Serie : Classes.EntidadeBase
    {

               //Atributos

        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }

        private bool Excluido { get; set; }

      
       
        //Metodos

        public Serie(int id, Genero Genero, string Titulo, int Ano, string Descricao)
        {
            Id = id;
            this.Genero = Genero;
            this.Titulo = Titulo;
            this.Ano = Ano;
            this.Descricao = Descricao;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero: " + this.Genero + System.Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + System.Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + System.Environment.NewLine;
            retorno += "Ano de Inicio: " + this.Ano + System.Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;

            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public string retornaId()
        {
            return this.Id.ToString();
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir() {
            this.Excluido = true;
        }

    






    }
}