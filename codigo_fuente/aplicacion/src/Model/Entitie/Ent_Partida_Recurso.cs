namespace Model.Entitie
{
    public class Ent_Partida_Recurso
    {
        public int DetParRec_Id { get; set; }
        public Ent_Partida? ePartida { get; set; } = new();
        public Ent_Recurso? eRecurso { get; set; }
        public decimal? Rec_Cantidad { get; set; }
        public decimal? Rec_Cuadrilla { get; set; }
        public decimal? DetParRec_Precio_HM { get; set; }
        public decimal? DetParRec_PrecioUnitario { get; set; }
    }
}
