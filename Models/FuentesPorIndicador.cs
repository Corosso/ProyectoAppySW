using System;

namespace proyectoindicadores2.Models
{
    public class FuentesPorIndicador
    {
        private int fkIdFuente;
        private int fkIdIndicador;

        public int FkIdFuente { get => fkIdFuente; set => fkIdFuente = value; }
        public int FkIdIndicador { get => fkIdIndicador; set => fkIdIndicador = value; }

        public FuentesPorIndicador(int fkIdFuente, int fkIdIndicador)
        {
            this.fkIdFuente = fkIdFuente;
            this.fkIdIndicador = fkIdIndicador;
        }

        public FuentesPorIndicador()
        {
            this.fkIdFuente = 0;
            this.fkIdIndicador = 0;
        }
    }
}
