using System;

namespace proyectoindicadores2.Models
{
    public class RepresenVisualPorIndicador
    {
        private int fkIdIndicador;
        private int fkIdRepresenVisual;

        public int FkIdIndicador { get => fkIdIndicador; set => fkIdIndicador = value; }
        public int FkIdRepresenVisual { get => fkIdRepresenVisual; set => fkIdRepresenVisual = value; }

        public RepresenVisualPorIndicador(int fkIdIndicador, int fkIdRepresenVisual)
        {
            this.fkIdIndicador = fkIdIndicador;
            this.fkIdRepresenVisual = fkIdRepresenVisual;
        }

        public RepresenVisualPorIndicador()
        {
            this.fkIdIndicador = 0;
            this.fkIdRepresenVisual = 0;
        }
    }
}
